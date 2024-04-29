package com.kiku.javalangprogproject.controllers;

import com.kiku.javalangprogproject.BaseController;
import com.kiku.javalangprogproject.Database.DbConnect;
import com.kiku.javalangprogproject.SceneController;
import com.kiku.javalangprogproject.Utils.TableSearchUtil;
import com.kiku.javalangprogproject.classes.Shoe;
import com.kiku.javalangprogproject.reportGenerators.CreateJsonFromTable;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.fxml.FXML;
import javafx.scene.Scene;
import javafx.scene.control.*;
import javafx.scene.control.cell.PropertyValueFactory;
import javafx.stage.Stage;

import java.sql.*;

import static com.kiku.javalangprogproject.Utils.NotificationUtils.showErrorNotification;


@SuppressWarnings("ALL")
public class AssortimentController extends BaseController {
    @FXML
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

    public TableView<Shoe> shoesTable = new TableView<>();
    public TableColumn<Shoe, Integer> idShoe;
    public TableColumn<Shoe, String> nameShoe;
    public TableColumn<Shoe, Double> costShoe;
    public TableColumn<Shoe, String> colorShoe;
    public TableColumn<Shoe, String> stockShoe;
    public TableColumn<Shoe, String> sizeShoe;
    public TableColumn<Shoe, String> seasonShoe;
    public TableColumn<Shoe, String> complectionShoe;
    public ComboBox<String> complectionAddShoe;
    public TextField stackAddShoe;
    public ComboBox<String> seasonAddShoe;
    public Label exceptionLabel;
    public TextField idAddShoe;
    public TextField nameAddShoe;
    public TextField costAddShoe;
    public ComboBox<String> colorAddShoe;
    public TextField size1AddShoe;
    public TextField size2AddShoe;



    String query = null;
    Connection connection = null;
    PreparedStatement preparedStatement = null;
    ResultSet resultSet = null;
    Shoe shoe = null;

    ObservableList<Shoe> ShoeList = FXCollections.observableArrayList();

    public Button ButtonRefresh;


    private Stage stage;
    private Scene scene;


    public void getColours() {
        try {
            ObservableList<String> items = FXCollections.observableArrayList();
            Connection connection = DbConnect.getConnect();

            String sql = "SELECT * FROM colours";

            Statement statement = connection.createStatement();
            ResultSet resultSet = statement.executeQuery(sql);


            while (resultSet.next()) {
                String value = resultSet.getString("name");
                items.add(value);
            }

            colorAddShoe.setItems(items);
            colorAddShoe.setValue(items.getFirst());

        } catch (Exception e) {
            showErrorNotification(e.getMessage());
        }
    }

    public void getComplection() {
        try {
            ObservableList<String> items = FXCollections.observableArrayList();
            Connection connection = DbConnect.getConnect();

            String sql = "SELECT * FROM complection";
            Statement statement = connection.createStatement();
            ResultSet resultSet = statement.executeQuery(sql);

            while (resultSet.next()) {
                String value = resultSet.getString("name");
                items.add(value);
            }

            complectionAddShoe.setItems(items);
            complectionAddShoe.setValue(items.getFirst());

        } catch (Exception e) {
            showErrorNotification(e.getMessage());
        }
    }

    public void getSeason() {
        try {
            ObservableList<String> items = FXCollections.observableArrayList();
            Connection connection = DbConnect.getConnect();

            String sql = "SELECT * FROM season";
            Statement statement = connection.createStatement();
            ResultSet resultSet = statement.executeQuery(sql);

            while (resultSet.next()) {
                String value = resultSet.getString("name");
                items.add(value);
            }

            seasonAddShoe.setItems(items);
            seasonAddShoe.setValue(items.getFirst());

        } catch (Exception e) {
            showErrorNotification(e.getMessage());
        }
    }


    protected void onInitialize() {
        try {
            loadDate();

            shoesTable.setOnMouseClicked(event -> {
                if (event.getClickCount() == 1) {
                    if (shoesTable.getSelectionModel().getSelectedItem() != null) {
                        Shoe selectedItem = shoesTable.getSelectionModel().getSelectedItem();

                        String range = selectedItem.getSizeShoe();
                        String[] parts = range.split("-");
                        idAddShoe.setText(selectedItem.getIdShoe());
                        nameAddShoe.setText(selectedItem.getNameShoe());
                        costAddShoe.setText(Double.toString(selectedItem.getCostShoe()));
                        colorAddShoe.setValue(selectedItem.getColorShoe());
                        stackAddShoe.setText(selectedItem.getStockShoe());
                        size1AddShoe.setText(parts[0]);
                        size2AddShoe.setText(parts[1]);
                        complectionAddShoe.setValue(selectedItem.getComplection());
                        seasonAddShoe.setValue(selectedItem.getSeasonShoe());
                    }
                }
            });
            TableSearchUtil.setupSearch(shoesTable, searchField);
            getColours();
            getComplection();
            getSeason();
        } catch (Exception ex) {
            showErrorNotification(ex.getMessage());
        }
    }


    @FXML
    private void refreshTable() {

        try {


            ShoeList.clear();

            preparedStatement = connection.prepareStatement("SELECT * FROM shoes");
            resultSet = preparedStatement.executeQuery();

            while (resultSet.next()) {
                ShoeList.add(new Shoe(
                        resultSet.getInt("id"),
                        resultSet.getString("name"),
                        resultSet.getDouble("cost"),
                        resultSet.getString("color"),
                        resultSet.getString("stock"),
                        resultSet.getString("size"),
                        resultSet.getString("season"),
                        resultSet.getString("complection")));

                shoesTable.setItems(ShoeList);

            }

            CreateJsonFromTable.jsonCreateShoe(shoesTable);
            TableSearchUtil.setupSearch(shoesTable, searchField);
        } catch (Exception ex) {
            showErrorNotification(ex.getMessage());
        }
    }

    private void loadDate() {
        try {


            connection = DbConnect.getConnect();

            refreshTable();


            idShoe.setCellValueFactory(new PropertyValueFactory<>("idShoe"));
            nameShoe.setCellValueFactory(new PropertyValueFactory<>("nameShoe"));
            costShoe.setCellValueFactory(new PropertyValueFactory<>("costShoe"));
            colorShoe.setCellValueFactory(new PropertyValueFactory<>("colorShoe"));
            stockShoe.setCellValueFactory(new PropertyValueFactory<>("stockShoe"));
            sizeShoe.setCellValueFactory(new PropertyValueFactory<>("sizeShoe"));
            seasonShoe.setCellValueFactory(new PropertyValueFactory<>("seasonShoe"));
            complectionShoe.setCellValueFactory(new PropertyValueFactory<>("complection"));

        } catch (Exception ex) {
            showErrorNotification(ex.getMessage());
        }


    }

    public void addNewShoe() {
        try {
            Connection connection = DbConnect.getConnect();

            String sizeNew = size1AddShoe.getText() + "-" + size2AddShoe.getText();
            String query = "INSERT INTO shoes (id, name, cost, color, size, complection, stock, season) VALUES (?, ?, ?, ?, ?, ?, ?, ?)";

            PreparedStatement preparedStatement = connection.prepareStatement(query);
            preparedStatement.setString(1, idAddShoe.getText());
            preparedStatement.setString(2, nameAddShoe.getText());
            preparedStatement.setString(3, costAddShoe.getText());
            preparedStatement.setString(4, colorAddShoe.getSelectionModel().getSelectedItem());
            preparedStatement.setString(5, sizeNew);
            preparedStatement.setString(6, complectionAddShoe.getSelectionModel().getSelectedItem());
            preparedStatement.setString(7, stackAddShoe.getText());
            preparedStatement.setString(8, seasonAddShoe.getSelectionModel().getSelectedItem());

            preparedStatement.executeUpdate();

            exceptionLabel.setText("Обувь успешно добавлена.");
            refreshTable();
        } catch (Exception ex) {
            showErrorNotification(ex.getMessage());
        }
    }

    public void removeShoe() {
        try {
            Connection connection = DbConnect.getConnect();
            int id = Integer.parseInt(idAddShoe.getText());
            String query = "DELETE FROM shoes WHERE id = " + id;
            int result = connection.prepareStatement(query).executeUpdate();
            if (result > 0) {
                exceptionLabel.setText("Обувь успешно удалена.");
                refreshTable();
            } else {
                showErrorNotification("Failed to delete shoes. No shoes found with ID: " + id);
            }
        } catch (Exception e) {
            showErrorNotification(e.getMessage());
        }
    }

    public void EditShoe() {
        try {
            Connection connection = DbConnect.getConnect();

            String sizeNew = size1AddShoe.getText() + "-" + size2AddShoe.getText();
            String query = "UPDATE shoes SET name = ?, cost = ?, color = ?, size = ?, complection = ?, stock = ?, season = ? where id = ?";

            PreparedStatement preparedStatement = connection.prepareStatement(query);
            preparedStatement.setString(1, nameAddShoe.getText());
            preparedStatement.setString(2, costAddShoe.getText());
            preparedStatement.setString(3, colorAddShoe.getSelectionModel().getSelectedItem());
            preparedStatement.setString(4, sizeNew);
            preparedStatement.setString(5, complectionAddShoe.getSelectionModel().getSelectedItem());
            preparedStatement.setString(6, stackAddShoe.getText());
            preparedStatement.setString(7, seasonAddShoe.getSelectionModel().getSelectedItem());
            preparedStatement.setString(8, idAddShoe.getText());

            preparedStatement.executeUpdate();
            refreshTable();
        } catch (SQLException ex) {
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

