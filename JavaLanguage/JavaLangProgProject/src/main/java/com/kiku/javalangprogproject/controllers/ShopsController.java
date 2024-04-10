package com.kiku.javalangprogproject.controllers;

import com.kiku.javalangprogproject.BaseController;
import com.kiku.javalangprogproject.Database.DbConnect;
import com.kiku.javalangprogproject.classes.Shop;
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

public class ShopsController extends BaseController {
    public TableView<Shop> shopsTable = new TableView<>();
    public TableColumn<Shop, Integer> idShop;
    public TableColumn<Shop, String> nameShop;
    public TableColumn<Shop, String> locationsShop;
    public TableColumn<Shop, String> emailShop;
    public TableColumn<Shop, String> numberShop;
    public TableColumn<Shop, String> fioShop;
    public Button buttonReturn;
    public Button ButtonComplain;
    public Button ButtonReport;
    public Button ButtonTaxService;
    public Button ButtonDisposal;
    public Button ButtonSuppliers;
    public Button ButtonStock;
    public Button ButtonAssortment;
    public Button ButtonShops;
    public Button ButtonMainMenu;
    public Button ButtonRefresh;
    public Button ButtonAddShop;
    public Button ButtonRemoveShop;
    public TextField idField;
    public TextField nameField;
    public TextField locationFIeld;
    public TextField emailField;
    public Label exceptionLabel;
    public Button ButtonEditShop;
    public TextField numberField;
    public TextField fioField;
    public Button exitAppButton;

    private Stage stage;
    private Scene scene;

    String query = null;
    Connection connection = null;
    PreparedStatement preparedStatement = null;
    ResultSet resultSet = null;



    ObservableList<Shop> ShopList = FXCollections.observableArrayList();



    public void addNewShop(ActionEvent actionEvent) {
        try {
            Connection connection = DbConnect.getConnect();


            String query = "INSERT INTO shops (id, name, location, email, number, fio) VALUES (?, ?, ?, ?, ?, ?)";

            PreparedStatement preparedStatement = connection.prepareStatement(query);
            preparedStatement.setString(1, idField.getText());
            preparedStatement.setString(2, nameField.getText());
            preparedStatement.setString(3, locationFIeld.getText());
            preparedStatement.setString(4, emailField.getText());
            preparedStatement.setString(5, numberField.getText());
            preparedStatement.setString(6, fioField.getText());

            preparedStatement.executeUpdate();

            exceptionLabel.setText("Магазин успешно добавлен.");
            refreshTable();
        } catch (Exception e) {
            exceptionLabel.setText("Магазин не был добавлен. Причина: " + e.getMessage());
        }
    }

    public void removeShop(ActionEvent actionEvent) {
        try {
            Connection connection = DbConnect.getConnect();
            int id = Integer.parseInt(idField.getText());
            String query = "DELETE FROM shops WHERE id = " + id;
            connection.prepareStatement(query).executeUpdate();
            exceptionLabel.setText("Магазин успешно удален.");
            refreshTable();
        } catch (Exception e) {
            exceptionLabel.setText("Магазин не был удален. Причина: " + e.getMessage());
        }
    }

    public void EditShop(ActionEvent actionEvent) {
        try {
            Connection connection = DbConnect.getConnect();

            String query = "UPDATE shops SET name = ?, location = ?, email = ?, number = ?, fio = ? where id = ?";

            PreparedStatement preparedStatement = connection.prepareStatement(query);
            preparedStatement.setString(1, nameField.getText());
            preparedStatement.setString(2, locationFIeld.getText());
            preparedStatement.setString(3, emailField.getText());
            preparedStatement.setString(4, numberField.getText());
            preparedStatement.setString(5, fioField.getText());
            preparedStatement.setString(6, idField.getText());


            preparedStatement.executeUpdate();
            refreshTable();
        } catch (SQLException ex) {
            throw new RuntimeException(ex);
        }

    }

    public void onInitialize() throws SQLException {
        loadDate();
        shopsTable.setOnMouseClicked(event -> {
            if (event.getClickCount() == 1) {
                if (shopsTable.getSelectionModel().getSelectedItem() != null) {
                    Shop selectedItem = shopsTable.getSelectionModel().getSelectedItem();

                    idField.setText(selectedItem.getIdShop());
                    nameField.setText(selectedItem.getNameShop());
                    locationFIeld.setText(selectedItem.getLocationsShop());
                    emailField.setText(selectedItem.getEmailShop());
                    numberField.setText(selectedItem.getNumberShop());
                    fioField.setText(selectedItem.getFioShop());


                    // И так далее
                }
            }
        });
    }


    @FXML
    private void refreshTable() throws SQLException {

        ShopList.clear();

        preparedStatement = connection.prepareStatement("SELECT * FROM shops");
        resultSet = preparedStatement.executeQuery();

        while (resultSet.next()) {
            ShopList.add(new Shop(
                    resultSet.getInt("id"),
                    resultSet.getString("name"),
                    resultSet.getString("location"),
                    resultSet.getString("email"),
                    resultSet.getString("number"),
                    resultSet.getString("fio")));

            shopsTable.setItems(ShopList);

        }


    }

    private void loadDate() throws SQLException {
        connection = DbConnect.getConnect();

        refreshTable();

        idShop.setCellValueFactory(new PropertyValueFactory<>("idShop"));

        nameShop.setCellValueFactory(new PropertyValueFactory<>("nameShop"));
        locationsShop.setCellValueFactory(new PropertyValueFactory<>("locationsShop"));
        emailShop.setCellValueFactory(new PropertyValueFactory<>("emailShop"));
        numberShop.setCellValueFactory(new PropertyValueFactory<>("numberShop"));
        fioShop.setCellValueFactory(new PropertyValueFactory<>("fioShop"));



    }
}
