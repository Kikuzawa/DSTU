package com.kiku.javalangprogproject.controllers;

import com.kiku.javalangprogproject.BaseController;
import com.kiku.javalangprogproject.Database.DbConnect;
import com.kiku.javalangprogproject.classes.Supplier;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.scene.Scene;
import javafx.scene.control.*;
import javafx.scene.control.cell.PropertyValueFactory;
import javafx.stage.Stage;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

public class SuppliersController extends BaseController {
    public TableView<Supplier> suppliersTable = new TableView<>();
    public TableColumn<Supplier, Integer> idSupplier;
    public TableColumn<Supplier, String> nameSupplier;
    public TableColumn<Supplier, String> numberSupplier;
    public TableColumn<Supplier, String> locationsSupplier;
    public TableColumn<Supplier, String> stockSupplier;

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
    public Button ButtonAddSupplier;
    public Button ButtonRemoveSupplier;
    public TextField idField;
    public TextField nameField;
    public TextField locationFIeld;

    public Label exceptionLabel;
    public Button ButtonEditSupplier;
    public TextField numberField;
    public TextField stockField;
    public Button exitAppButton;

    private Stage stage;
    private Scene scene;

    String query = null;
    Connection connection = null;
    PreparedStatement preparedStatement = null;
    ResultSet resultSet = null;



    ObservableList<Supplier> SupplierList = FXCollections.observableArrayList();



    public void addNewSupplier(ActionEvent actionEvent) {
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

            exceptionLabel.setText("Магазин успешно добавлен.");
            refreshTable();
        } catch (Exception e) {
            exceptionLabel.setText("Магазин не был добавлен. Причина: " + e.getMessage());
        }
    }

    public void removeSupplier(ActionEvent actionEvent) {
        try {
            Connection connection = DbConnect.getConnect();
            int id = Integer.parseInt(idField.getText());
            String query = "DELETE FROM suppliers WHERE \uFEFFid = " + id;
            connection.prepareStatement(query).executeUpdate();
            exceptionLabel.setText("Магазин успешно удален.");
            refreshTable();
        } catch (Exception e) {
            exceptionLabel.setText("Магазин не был удален. Причина: " + e.getMessage());
        }
    }

    public void EditSupplier(ActionEvent actionEvent) {
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
            throw new RuntimeException(ex);
        }

    }

    public void onInitialize() throws SQLException {
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
    }


    @FXML
    private void refreshTable() throws SQLException {

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


    }

    private void loadDate() throws SQLException {
        connection = DbConnect.getConnect();

        refreshTable();

        idSupplier.setCellValueFactory(new PropertyValueFactory<>("idSupplier"));

        nameSupplier.setCellValueFactory(new PropertyValueFactory<>("nameSupplier"));
        numberSupplier.setCellValueFactory(new PropertyValueFactory<>("numberSupplier"));
        locationsSupplier.setCellValueFactory(new PropertyValueFactory<>("locationsSupplier"));
        stockSupplier.setCellValueFactory(new PropertyValueFactory<>("stockSupplier"));



    }
}
