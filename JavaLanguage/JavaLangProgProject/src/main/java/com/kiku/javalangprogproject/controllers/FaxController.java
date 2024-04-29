// Контроллер Налоговые отчисления

package com.kiku.javalangprogproject.controllers;

import com.kiku.javalangprogproject.BaseController;
import com.kiku.javalangprogproject.Database.DbConnect;
import com.kiku.javalangprogproject.SceneController;
import com.kiku.javalangprogproject.Utils.TableSearchUtil;
import com.kiku.javalangprogproject.classes.Tax;
import com.kiku.javalangprogproject.reportGenerators.CreateJsonFromTable;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.fxml.FXML;
import javafx.scene.control.*;
import javafx.scene.control.cell.PropertyValueFactory;
import javafx.scene.layout.AnchorPane;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.time.LocalDate;
import java.time.Month;
import java.time.Year;

import static com.kiku.javalangprogproject.Utils.NotificationUtils.showErrorNotification;


public class FaxController extends BaseController {


    public AnchorPane pane;
    public TextField yearField;
    public TextField incomeField;
    public TextField vatField;
    public TextField propertyTaxField;
    public ChoiceBox<String> monthChoiceBox;
    public TextField landTaxPercentageField;

    public TextField expensesField;

    public TableView<Tax> taxTable;

    public TextField idField;
    public TableColumn<Tax, String> idTax;
    public TableColumn<Tax, String> monthTax;
    public TableColumn<Tax, Integer> yearTax;
    public TableColumn<Tax, Double> totalIncomeTax;
    public TableColumn<Tax, Double> procentEarthTax;
    public TableColumn<Tax, Double> totalExpenseTax;
    public TableColumn<Tax, Double> HouseTax;
    public TableColumn<Tax, Double> NdsTax;
    public TableColumn<Tax, Double> finalTax;
    public TableColumn<Tax, Double> baseTax;
    public TableColumn<Tax, Double> taxWithNDS;
    public TableColumn<Tax, Double> taxWithNdsAndHouse;
    public Button ButtonRefresh;
    private Connection connection;
    private ObservableList<Tax> FaxList;


    public void onInitialize() {
        try {
            this.FaxList = FXCollections.observableArrayList();
            loadDate();
            Month currentMonth = Month.values()[LocalDate.now().getMonthValue() - 1];

            String russianMonth = switch (currentMonth) {
                case JANUARY -> "Январь";
                case FEBRUARY -> "Февраль";
                case MARCH -> "Март";
                case APRIL -> "Апрель";
                case MAY -> "Май";
                case JUNE -> "Июнь";
                case JULY -> "Июль";
                case AUGUST -> "Август";
                case SEPTEMBER -> "Сентябрь";
                case OCTOBER -> "Октябрь";
                case NOVEMBER -> "Ноябрь";
                case DECEMBER -> "Декабрь";
            };

            monthChoiceBox.setValue(russianMonth);

            Year currentYear = Year.now();
            int currentYearValue = currentYear.getValue();


            yearField.setText(String.valueOf(currentYearValue));

            taxTable.setOnMouseClicked(event -> {
                if (event.getClickCount() == 1) {
                    if (taxTable.getSelectionModel().getSelectedItem() != null) {
                        Tax selectedItem = taxTable.getSelectionModel().getSelectedItem();


                        idField.setText(String.valueOf(selectedItem.getIdTax()));
                        monthChoiceBox.setValue(selectedItem.getMonthTax());
                        yearField.setText(String.valueOf(selectedItem.getYearTax()));
                        incomeField.setText(String.valueOf(selectedItem.getTotalIncomeTax()));
                        expensesField.setText(String.valueOf(selectedItem.getTotalExpenseTax()));
                        vatField.setText(String.valueOf(selectedItem.getNdsTax()));
                        propertyTaxField.setText(String.valueOf(selectedItem.getHouseTax()));
                        landTaxPercentageField.setText(String.valueOf(selectedItem.getProcentEarthTax()));
                    }
                }
            });
            TableSearchUtil.setupSearch(taxTable, searchField);
        } catch (Exception ex) {
            showErrorNotification(ex.getMessage());
        }
    }

    private void loadDate() {
        try {
            connection = DbConnect.getConnect();

            refreshTable();

            idTax.setCellValueFactory(new PropertyValueFactory<>("idTax"));
            monthTax.setCellValueFactory(new PropertyValueFactory<>("monthTax"));
            yearTax.setCellValueFactory(new PropertyValueFactory<>("yearTax"));
            totalIncomeTax.setCellValueFactory(new PropertyValueFactory<>("totalIncomeTax"));
            procentEarthTax.setCellValueFactory(new PropertyValueFactory<>("procentEarthTax"));
            totalExpenseTax.setCellValueFactory(new PropertyValueFactory<>("totalExpenseTax"));
            HouseTax.setCellValueFactory(new PropertyValueFactory<>("HouseTax"));
            NdsTax.setCellValueFactory(new PropertyValueFactory<>("NdsTax"));
            finalTax.setCellValueFactory(new PropertyValueFactory<>("finalTax"));
            baseTax.setCellValueFactory(new PropertyValueFactory<>("baseTax"));
            taxWithNDS.setCellValueFactory(new PropertyValueFactory<>("taxWithNDS"));
            taxWithNdsAndHouse.setCellValueFactory(new PropertyValueFactory<>("taxWithNdsAndHouse"));
        } catch (Exception ex) {
            showErrorNotification(ex.getMessage());
        }
    }

    @FXML
    private void refreshTable() {
        try {

            FaxList.clear();

            PreparedStatement preparedStatement = connection.prepareStatement("SELECT * FROM tax");
            ResultSet resultSet = preparedStatement.executeQuery();


            while (resultSet.next()) {
                FaxList.add(new Tax(resultSet.getInt("id"),
                        resultSet.getString("month"),
                        resultSet.getInt("year"),
                        resultSet.getDouble("totalIncome"),
                        resultSet.getDouble("totalExpence"),
                        resultSet.getDouble("procentEarthTax"),
                        resultSet.getDouble("procentHouseTax"),
                        resultSet.getDouble("NDS")));

                taxTable.setItems(FaxList);
            }

            CreateJsonFromTable.jsonCreateTax(taxTable);
        } catch (Exception ex) {
            showErrorNotification(ex.getMessage());
        }
    }

    public void calculateTaxes() {

        try {
            Connection connection = DbConnect.getConnect();

            String query = "INSERT INTO tax (id, month, year, totalIncome, totalExpence, procentEarthTax, procentHouseTax, NDS, baseTax, taxWithNDS, taxWithNdsAndHouse, finalTax) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";


            PreparedStatement preparedStatement = connection.prepareStatement(query);
            Tax newTax = new Tax(Integer.parseInt(idField.getText()), monthChoiceBox.getValue(), Integer.parseInt(yearField.getText()), Double.parseDouble(incomeField.getText()), Double.parseDouble(expensesField.getText()), Double.parseDouble(landTaxPercentageField.getText()), Double.parseDouble(propertyTaxField.getText()), Double.parseDouble(vatField.getText()));
            PreparedStatement checkStatement = connection.prepareStatement("SELECT COUNT(*) FROM tax WHERE month = ? AND year = ?");
            checkStatement.setString(1, newTax.monthTax);
            checkStatement.setInt(2, newTax.yearTax);
            ResultSet resultSet = checkStatement.executeQuery();
            resultSet.next();
            int count = resultSet.getInt(1);
            if (count > 0) {
                showErrorNotification("Вы уже внесли данные за этот месяц");
            } else {
                preparedStatement.setInt(1, newTax.idTax);
                preparedStatement.setString(2, newTax.monthTax);
                preparedStatement.setInt(3, newTax.yearTax);
                preparedStatement.setDouble(4, newTax.totalIncomeTax);
                preparedStatement.setDouble(5, newTax.totalExpenseTax);
                preparedStatement.setDouble(6, newTax.procentEarthTax);
                preparedStatement.setDouble(7, newTax.HouseTax);
                preparedStatement.setDouble(8, newTax.NdsTax);
                preparedStatement.setDouble(9, newTax.baseTax);
                preparedStatement.setDouble(10, newTax.taxWithNDS);
                preparedStatement.setDouble(11, newTax.taxWithNdsAndHouse);
                preparedStatement.setDouble(12, newTax.finalTax);

                preparedStatement.executeUpdate();

                refreshTable();
            }
        } catch (Exception ex) {
            showErrorNotification(ex.getMessage());
        }
    }

    public void removeTaxes() {
        try {
            Connection connection = DbConnect.getConnect();

            String query = "DELETE FROM tax WHERE id = ?";

            PreparedStatement preparedStatement = connection.prepareStatement(query);
            preparedStatement.setInt(1, Integer.parseInt(idField.getText()));

            preparedStatement.executeUpdate();

            refreshTable();
        } catch (Exception ex) {
            showErrorNotification(ex.getMessage());
        }

    }

    public void generateReport() {
        try {
            ReportFormatSelectionWindow.help();
            SceneController.getInstance().createReportWindow();
        } catch (Exception ex) {
            showErrorNotification(ex.getMessage());
        }
    }

}
