package com.kiku.javalangprogproject;

import com.kiku.javalangprogproject.Database.DbConnect;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.scene.Node;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.*;
import javafx.scene.control.cell.PropertyValueFactory;
import javafx.stage.Stage;

import java.io.IOException;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.Objects;

public class StockController {
    public TableView<Stock> stocksTable = new TableView<>();
    public TableColumn<Stock, Integer> idStock;
    public TableColumn<Stock, String> nameStock;
    public TableColumn<Stock, Integer> quantityStock;
    public TableColumn<Stock, Integer> costStock;
    public TableColumn<Stock, Integer> totalStock;

    public Button ButtonSuppliers;
    public Button buttonReturn;
    public Button ButtonComplain;
    public Button ButtonReport;
    public Button ButtonTaxService;
    public Button ButtonDisposal;

    public Button ButtonStock;
    public Button ButtonAssortment;
    public Button ButtonShops;
    public Button ButtonMainMenu;
    public Button ButtonRefresh;
    public Button ButtonAddStock;
    public Button ButtonRemoveStock;
    public TextField idField;
    public TextField nameField;
    public TextField quantityField;
    public TextField costField;

    public Label exceptionLabel;
    public Button ButtonEditStock;



    private Stage stage;
    private Scene scene;

    String query = null;
    Connection connection = null;
    PreparedStatement preparedStatement = null;
    ResultSet resultSet = null;



    ObservableList<Stock> StockList = FXCollections.observableArrayList();

    @FXML
    public void switchToLoginPage(ActionEvent event) throws IOException {
        Parent root = FXMLLoader.load(Objects.requireNonNull(getClass().getResource("loginPage.fxml")));
        stage = (Stage) ((Node) event.getSource()).getScene().getWindow();
        scene = new Scene(root);
        stage.setScene(scene);
        stage.show();
    }

    public void switchToReportPage(ActionEvent actionEvent) {
    }


    public void switchToAssortmentPage(ActionEvent actionEvent) throws IOException {
        Parent root = FXMLLoader.load(Objects.requireNonNull(getClass().getResource("assortiment.fxml")));
        stage = (Stage) ((Node) actionEvent.getSource()).getScene().getWindow();
        scene = new Scene(root);
        stage.setScene(scene);
        stage.show();
    }

    public void switchToShopsPage(ActionEvent actionEvent) throws IOException {
        Parent root = FXMLLoader.load(Objects.requireNonNull(getClass().getResource("shops.fxml")));
        stage = (Stage)((Node)actionEvent.getSource()).getScene().getWindow();
        scene = new Scene(root);
        stage.setScene(scene);
        stage.show();
    }

    public void switchToStockPage(ActionEvent event) throws IOException {
        Parent root = FXMLLoader.load(Objects.requireNonNull(getClass().getResource("stock.fxml")));
        stage = (Stage)((Node)event.getSource()).getScene().getWindow();
        scene = new Scene(root);
        stage.setScene(scene);
        stage.show();
    }

    public void switchToSuppliersPage(ActionEvent actionEvent) throws IOException {
        Parent root = FXMLLoader.load(Objects.requireNonNull(getClass().getResource("suppliers.fxml")));
        stage = (Stage)((Node)actionEvent.getSource()).getScene().getWindow();
        scene = new Scene(root);
        stage.setScene(scene);
        stage.show();
    }

    public void switchToDisposalPage(ActionEvent actionEvent) {
    }

    public void switchToTaxServicePage(ActionEvent actionEvent) {
    }

    public void switchToComplainPage(ActionEvent actionEvent) {
    }

    public void switchToMainMenu(ActionEvent actionEvent) throws IOException {
        Parent root = FXMLLoader.load(Objects.requireNonNull(getClass().getResource("mainMenu.fxml")));
        stage = (Stage) ((Node) actionEvent.getSource()).getScene().getWindow();
        scene = new Scene(root);
        stage.setScene(scene);
        stage.show();
    }



    public void addNewStock(ActionEvent actionEvent) {
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
            exceptionLabel.setText("Сырье не было добавлено. Причина: " + e.getMessage());
        }
    }

    public void removeStock(ActionEvent actionEvent) {
        try {
            Connection connection = DbConnect.getConnect();
            int id = Integer.parseInt(idField.getText());
            String query = "DELETE FROM stock WHERE id = " + id;
            connection.prepareStatement(query).executeUpdate();
            exceptionLabel.setText("Сырье успешно удалено.");
            refreshTable();
        } catch (Exception e) {
            exceptionLabel.setText("Сырье не было удалено. Причина: " + e.getMessage());
        }
    }

    public void EditStock(ActionEvent actionEvent) {
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
            throw new RuntimeException(ex);
        }

    }

    public void initialize() throws SQLException {
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
    }


    @FXML
    private void refreshTable() throws SQLException {

        StockList.clear();

        preparedStatement = connection.prepareStatement("SELECT * FROM stock");
        resultSet = preparedStatement.executeQuery();

        while (resultSet.next()) {
            StockList.add(new Stock(
                    resultSet.getInt("id"),
                    resultSet.getString("name"),
                    resultSet.getInt("quantity"),
                    resultSet.getInt("cost"),
                    resultSet.getInt("total")));

            stocksTable.setItems(StockList);

        }


    }

    private void loadDate() throws SQLException {
        connection = DbConnect.getConnect();

        refreshTable();

        idStock.setCellValueFactory(new PropertyValueFactory<>("idStock"));

        nameStock.setCellValueFactory(new PropertyValueFactory<>("nameStock"));
        quantityStock.setCellValueFactory(new PropertyValueFactory<>("quantityStock"));
        costStock.setCellValueFactory(new PropertyValueFactory<>("costStock"));
        totalStock.setCellValueFactory(new PropertyValueFactory<>("totalStock"));



    }
}