// Контроллер Поставщики

package com.kiku.javalangprogproject.controllers;

import com.kiku.javalangprogproject.BaseController;
import com.kiku.javalangprogproject.Utils.TableSearchUtil;
import com.kiku.javalangprogproject.reportGenerators.CreateJsonFromTable;
import com.kiku.javalangprogproject.Database.DbConnect;
import com.kiku.javalangprogproject.SceneController;
import com.kiku.javalangprogproject.classes.Supplier;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;


import javafx.fxml.FXML;
import javafx.scene.control.*;
import javafx.scene.control.cell.PropertyValueFactory;



import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

import static com.kiku.javalangprogproject.Utils.NotificationUtils.showErrorNotification;

public class SuppliersController extends BaseController {
    public TableView<Supplier> suppliersTable = new TableView<>();
    public TableColumn<Supplier, Integer> idSupplier;
    public TableColumn<Supplier, String> nameSupplier;
    public TableColumn<Supplier, String> numberSupplier;
    public TableColumn<Supplier, String> locationsSupplier;
    public TableColumn<Supplier, String> stockSupplier;



    public TextField idField;
    public TextField nameField;
    public TextField locationFIeld;

    public Label exceptionLabel;

    public TextField numberField;
    public TextField stockField;


    Connection connection = null;
    PreparedStatement preparedStatement = null;
    ResultSet resultSet = null;



    ObservableList<Supplier> SupplierList = FXCollections.observableArrayList();



    public void addNewSupplier() {
        try {
            Connection connection = DbConnect.getConnect();


            String query = "INSERT INTO suppliers (\uFEFFid, name, number, location, stock) VALUES (?, ?, ?, ?, ?)";

            PreparedStatement preparedStatement = connection.prepareStatement(query);
            preparedStatement.setString(1, idField.getText());
            preparedStatement.setString(2, nameField.getText());
            preparedStatement.setString(3, numberField.getText());
            preparedStatement.setString(4, locationFIeld.getText());
            preparedStatement.setString(5, stockField.getText());

            preparedStatement.executeUpdate();

            exceptionLabel.setText("Поставщик успешно добавлен.");
            refreshTable();
        } catch (Exception e) {
            showErrorNotification(e.getMessage());
        }
    }

    public void removeSupplier() {
        try {
            Connection connection = DbConnect.getConnect();
            int id = Integer.parseInt(idField.getText());
            String query = "DELETE FROM suppliers WHERE \uFEFFid = " + id;
            int result = connection.prepareStatement(query).executeUpdate();
            if (result > 0) {
                exceptionLabel.setText("Поставщик успешно добавлен.");
                refreshTable();
            } else {
                showErrorNotification("Failed to delete supplier. No supplier found with ID: " + id);
            }
        } catch (Exception e) {
            showErrorNotification(e.getMessage());
        }
    }

    public void EditSupplier() {
        try {
            Connection connection = DbConnect.getConnect();

            String query = "UPDATE suppliers SET name = ?, number = ?, location = ?, stock = ? where \uFEFFid = ?";

            PreparedStatement preparedStatement = connection.prepareStatement(query);
            preparedStatement.setString(1, nameField.getText());
            preparedStatement.setString(2, numberField.getText());
            preparedStatement.setString(3, locationFIeld.getText());
            preparedStatement.setString(4, stockField.getText());
            preparedStatement.setString(5, idField.getText());


            preparedStatement.executeUpdate();
            refreshTable();
        } catch (SQLException ex) {
            showErrorNotification(ex.getMessage());
        }

    }

    public void onInitialize()  {
        try {
        loadDate();
        suppliersTable.setOnMouseClicked(event -> {
            if (event.getClickCount() == 1) {
                if (suppliersTable.getSelectionModel().getSelectedItem() != null) {
                    Supplier selectedItem = suppliersTable.getSelectionModel().getSelectedItem();

                    idField.setText(selectedItem.getIdSupplier());
                    nameField.setText(selectedItem.getNameSupplier());
                    numberField.setText(selectedItem.getNumberSupplier());
                    locationFIeld.setText(selectedItem.getLocationsSupplier());
                    stockField.setText(selectedItem.getStockSupplier());



                    // И так далее
                }
            }
        });
        TableSearchUtil.setupSearch(suppliersTable, searchField);
        } catch (Exception ex) {
            showErrorNotification(ex.getMessage());
        }
    }



    @FXML
    private void refreshTable() { try {

        SupplierList.clear();

        preparedStatement = connection.prepareStatement("SELECT * FROM suppliers");
        resultSet = preparedStatement.executeQuery();

        while (resultSet.next()) {
            SupplierList.add(new Supplier(
                    resultSet.getInt("\uFEFFid"),
                    resultSet.getString("name"),
                    resultSet.getString("number"),
                    resultSet.getString("location"),
                    resultSet.getString("stock")));

            suppliersTable.setItems(SupplierList);

        }

        CreateJsonFromTable.jsonCreateSuppliers(suppliersTable);
    } catch (Exception ex) {
        showErrorNotification(ex.getMessage());
    }

    }

    private void loadDate(){try {
        connection = DbConnect.getConnect();

        refreshTable();

        idSupplier.setCellValueFactory(new PropertyValueFactory<>("idSupplier"));

        nameSupplier.setCellValueFactory(new PropertyValueFactory<>("nameSupplier"));
        numberSupplier.setCellValueFactory(new PropertyValueFactory<>("numberSupplier"));
        locationsSupplier.setCellValueFactory(new PropertyValueFactory<>("locationsSupplier"));
        stockSupplier.setCellValueFactory(new PropertyValueFactory<>("stockSupplier"));
    } catch (Exception ex) {
        showErrorNotification(ex.getMessage());
    }


    }

    public void generateReport() { try {
        ReportFormatSelectionWindow.help();
        SceneController.getInstance().createReportWindow();
    } catch (Exception ex) {
        showErrorNotification(ex.getMessage());
    }
    }
}
