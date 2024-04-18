package com.kiku.javalangprogproject.controllers;

import com.kiku.javalangprogproject.BaseController;
import com.kiku.javalangprogproject.Database.DbConnect;
import com.kiku.javalangprogproject.classes.Shoe;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.scene.Scene;
import javafx.scene.control.*;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.TextField;
import javafx.scene.control.cell.PropertyValueFactory;
import javafx.stage.Stage;
import org.apache.poi.xwpf.usermodel.XWPFDocument;
import org.apache.poi.xwpf.usermodel.XWPFTable;
import org.apache.poi.xwpf.usermodel.XWPFTableCell;


import java.awt.*;
import java.io.File;
import java.io.FileOutputStream;
import java.sql.*;

import static com.kiku.javalangprogproject.controllers.NotificationUtils.showErrorNotification;


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
    public Button ButtonAddShoe;
    public Button ButtonRemoveShoe;
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
    public Button ButtonEditShoe;
    public Button helpbtn;
    public Button exitAppButton;


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

    protected void onInitialize() throws SQLException {
        loadDate();

        shoesTable.setOnMouseClicked(event -> {
            if (event.getClickCount() == 1) {
                if (shoesTable.getSelectionModel().getSelectedItem() != null) {
                    Shoe selectedItem = shoesTable.getSelectionModel().getSelectedItem();

                    String range = selectedItem.getSize();
                    String[] parts = range.split("-");
                    idAddShoe.setText(selectedItem.getId());
                    nameAddShoe.setText(selectedItem.getName());
                    costAddShoe.setText(Double.toString(selectedItem.getCost()));
                    colorAddShoe.setValue(selectedItem.getColor());
                    stackAddShoe.setText(selectedItem.getStock());
                    size1AddShoe.setText(parts[0]);
                    size2AddShoe.setText(parts[1]);
                    complectionAddShoe.setValue(selectedItem.getComplection());
                    seasonAddShoe.setValue(selectedItem.getSeason());
                }
            }
        });
        getColours();
        getComplection();
        getSeason();
    }


    @FXML
    private void refreshTable() throws SQLException {


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

    }

    private void loadDate() throws SQLException {
        connection = DbConnect.getConnect();

        refreshTable();


        idShoe.setCellValueFactory(new PropertyValueFactory<>("id"));
        nameShoe.setCellValueFactory(new PropertyValueFactory<>("name"));
        costShoe.setCellValueFactory(new PropertyValueFactory<>("cost"));
        colorShoe.setCellValueFactory(new PropertyValueFactory<>("color"));
        stockShoe.setCellValueFactory(new PropertyValueFactory<>("stock"));
        sizeShoe.setCellValueFactory(new PropertyValueFactory<>("size"));
        seasonShoe.setCellValueFactory(new PropertyValueFactory<>("season"));
        complectionShoe.setCellValueFactory(new PropertyValueFactory<>("complection"));


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

    public void generateReport(ActionEvent actionEvent) {
        try {
            XWPFDocument document = new XWPFDocument();
            FileOutputStream out = new FileOutputStream("report.docx");

            // Создание таблицы
            XWPFTable table = document.createTable(ShoeList.size() + 1, 8); // +1 для заголовка

// Заполнение заголовка таблицы
            String[] headers = {"ID", "Name", "Cost", "Color", "Stock", "Size", "Season", "Complection"};
            for (int i = 0; i < headers.length; i++) {
                table.getRow(0).getCell(i).setText(headers[i]);
            }

// Заполнение данных из таблицы в таблицу Word
            for (int i = 0; i < ShoeList.size(); i++) {
                Shoe shoe = ShoeList.get(i);
                for (int j = 0; j < 8; j++) {
                    XWPFTableCell cell = table.getRow(i + 1).getCell(j);
                    if (cell == null) {
                        cell = table.getRow(i + 1).createCell();
                    }
                    switch (j) {
                        case 0:
                            cell.setText(shoe.getId());
                            break;
                        case 1:
                            cell.setText(shoe.getName());
                            break;
                        case 2:
                            cell.setText(String.valueOf(shoe.getCost()));
                            break;
                        case 3:
                            cell.setText(shoe.getColor());
                            break;
                        case 4:
                            cell.setText(String.valueOf(shoe.getStock()));
                            break;
                        case 5:
                            cell.setText(String.valueOf(shoe.getSize()));
                            break;
                        case 6:
                            cell.setText(shoe.getSeason());
                            break;
                        case 7:
                            cell.setText(shoe.getComplection());
                            break;
                        default:
                            break;
                    }
                }
            }

            // Сохранение документа
            document.write(out);


            // Открыть файл для просмотра или печати
            Desktop.getDesktop().open(new File("report.docx"));
        } catch (Exception e) {
            showErrorNotification("Error generating Word report: " + e.getMessage());
            System.out.println("Error generating Word report: " + e.getMessage());
        }

    }
}

