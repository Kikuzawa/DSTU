package com.kiku.javalangprogproject.controllers;

import com.kiku.javalangprogproject.BaseController;
import com.kiku.javalangprogproject.Utils.TableSearchUtil;
import com.kiku.javalangprogproject.reportGenerators.CreateJsonFromTable;
import com.kiku.javalangprogproject.Database.DbConnect;
import com.kiku.javalangprogproject.SceneController;
import com.kiku.javalangprogproject.classes.Stock;
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

public class StockController extends BaseController {
    public TableView<Stock> stocksTable = new TableView<>();
    public TableColumn<Stock, Integer> idStock;
    public TableColumn<Stock, String> nameStock;
    public TableColumn<Stock, Integer> quantityStock;
    public TableColumn<Stock, Integer> costStock;
    public TableColumn<Stock, Integer> totalStock;



    public Button ButtonAddStock;
    public Button ButtonRemoveStock;
    public TextField idField;
    public TextField nameField;
    public TextField quantityField;
    public TextField costField;

    public Label exceptionLabel;
    public Button ButtonEditStock;
    public Button exitAppButton;


    Connection connection = null;
    PreparedStatement preparedStatement = null;
    ResultSet resultSet = null;



    ObservableList<Stock> StockList = FXCollections.observableArrayList();



    public void addNewStock() {
        try {
            Connection connection = DbConnect.getConnect();


            String query = "INSERT INTO stock (id, name, quantity, cost) VALUES (?, ?, ?, ?)";

            PreparedStatement preparedStatement = connection.prepareStatement(query);
            preparedStatement.setString(1, idField.getText());
            preparedStatement.setString(2, nameField.getText());
            preparedStatement.setString(3, quantityField.getText());
            preparedStatement.setString(4, costField.getText());

            preparedStatement.executeUpdate();

            exceptionLabel.setText("Сырье успешно добавлено.");
            refreshTable();
        } catch (Exception e) {
            showErrorNotification(e.getMessage());
        }
    }

    public void removeStock() {
        try {
            Connection connection = DbConnect.getConnect();
            int id = Integer.parseInt(idField.getText());
            String query = "DELETE FROM stock WHERE id = " + id;
            int result = connection.prepareStatement(query).executeUpdate();
            if (result > 0) {
                exceptionLabel.setText("Сырье успешно удалено.");
                refreshTable();
            } else {
                showErrorNotification("Failed to delete stock. No stock found with ID: " + id);
            }
        } catch (Exception e) {
            showErrorNotification(e.getMessage());
        }
    }

    public void EditStock() {
        try {
            Connection connection = DbConnect.getConnect();

            String query = "UPDATE stock SET name = ?, quantity = ?, cost = ? where id = ?";

            PreparedStatement preparedStatement = connection.prepareStatement(query);
            preparedStatement.setString(1, nameField.getText());
            preparedStatement.setString(2, quantityField.getText());
            preparedStatement.setString(3, costField.getText());
            preparedStatement.setString(4, idField.getText());


            preparedStatement.executeUpdate();
            refreshTable();
        } catch (SQLException ex) {
            showErrorNotification(ex.getMessage());
        }

    }

    public void onInitialize()  {
        try {
        loadDate();
        stocksTable.setOnMouseClicked(event -> {
            if (event.getClickCount() == 1) {
                if (stocksTable.getSelectionModel().getSelectedItem() != null) {
                    Stock selectedItem = stocksTable.getSelectionModel().getSelectedItem();

                    idField.setText(String.valueOf(selectedItem.getIdStock()));
                    nameField.setText(selectedItem.getNameStock());
                    costField.setText(String.valueOf(selectedItem.getCostStock()));
                    quantityField.setText(String.valueOf(selectedItem.getQuantityStock()));




                    // И так далее
                }
            }
        });
        TableSearchUtil.setupSearch(stocksTable, searchField);
    } catch (Exception ex) {
        showErrorNotification(ex.getMessage());
    }
    }




    @FXML
    private void refreshTable() {
        try {

        StockList.clear();

        preparedStatement = connection.prepareStatement("SELECT * FROM stock");
        resultSet = preparedStatement.executeQuery();

        while (resultSet.next()) {
            StockList.add(new Stock(
                    resultSet.getInt("id"),
                    resultSet.getString("name"),
                    resultSet.getInt("quantity"),
                    resultSet.getInt("cost")));

            stocksTable.setItems(StockList);

        }
        CreateJsonFromTable.jsonCreateStock(stocksTable);
    } catch (Exception ex) {
        showErrorNotification(ex.getMessage());
    }
    }

    private void loadDate()  { try {
        connection = DbConnect.getConnect();

        refreshTable();

        idStock.setCellValueFactory(new PropertyValueFactory<>("idStock"));

        nameStock.setCellValueFactory(new PropertyValueFactory<>("nameStock"));
        quantityStock.setCellValueFactory(new PropertyValueFactory<>("quantityStock"));
        costStock.setCellValueFactory(new PropertyValueFactory<>("costStock"));
        totalStock.setCellValueFactory(new PropertyValueFactory<>("totalStock"));

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
