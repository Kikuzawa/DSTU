package com.kiku.javalangprogproject.controllers;

import com.kiku.javalangprogproject.BaseController;
import com.kiku.javalangprogproject.Database.DbConnect;
import com.kiku.javalangprogproject.SceneController;
import com.kiku.javalangprogproject.Utils.TableSearchUtil;
import com.kiku.javalangprogproject.classes.Shop;
import com.kiku.javalangprogproject.config.Paths;
import com.kiku.javalangprogproject.reportGenerators.CreateJsonFromTable;
import javafx.application.Platform;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.scene.Group;
import javafx.scene.Scene;
import javafx.scene.control.*;
import javafx.scene.control.cell.PropertyValueFactory;
import javafx.scene.web.WebEngine;
import javafx.scene.web.WebView;
import javafx.stage.Stage;

import java.io.BufferedWriter;
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.net.URISyntaxException;
import java.net.URL;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;
import java.util.Objects;

import static com.kiku.javalangprogproject.Utils.NotificationUtils.showErrorNotification;

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
    public Button ButtonOpenMap;

    Connection connection = null;
    PreparedStatement preparedStatement = null;
    ResultSet resultSet = null;


    ObservableList<Shop> ShopList = FXCollections.observableArrayList();


    public void addNewShop() {
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
            showErrorNotification(e.getMessage());
        }
    }

    public void removeShop() {
        try {
            Connection connection = DbConnect.getConnect();
            int id = Integer.parseInt(idField.getText());
            String query = "DELETE FROM shops WHERE id = " + id;
            int result = connection.prepareStatement(query).executeUpdate();
            if (result > 0) {
                exceptionLabel.setText("Магазин успешно удален.");
                refreshTable();
            } else {
                showErrorNotification("Failed to delete shop. No shop found with ID: " + id);
            }

            exceptionLabel.setText("Магазин успешно удален.");
            refreshTable();
        } catch (Exception e) {
            showErrorNotification(e.getMessage());
        }
    }

    public void EditShop() {
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
            showErrorNotification(ex.getMessage());
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
        TableSearchUtil.setupSearch(shopsTable, searchField);
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

        CreateJsonFromTable.jsonCreateShops(shopsTable);
        try {
            generateCommonTSFile();
        } catch (IOException | URISyntaxException e) {
            showErrorNotification(e.getMessage());
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

    public void generateReport(ActionEvent actionEvent) throws IOException {
        ReportFormatSelectionWindow.help();
        SceneController.getInstance().createReportWindow();
    }

    public void openMap(ActionEvent actionEvent) throws IOException {
        // Получить URL для файла openstreetmap.html
        URL url = getClass().getResource(Paths.MAP_HTML);

        // Открыть новое окно браузера и загрузить карту
        Platform.runLater(() -> {
            WebView webView = new WebView();
            WebEngine webEngine = webView.getEngine();
            webEngine.load(Objects.requireNonNull(url).toExternalForm());

            Stage stage = new Stage();
            Scene scene = new Scene(new Group(webView));

            // Set the initial size of the scene
            stage.setWidth(800);

            stage.setHeight(600);

            // Add a listener to resize the scene when the stage is resized
            stage.widthProperty().addListener((obs, oldVal, newVal) -> {
                stage.setWidth((double) newVal);
                webView.setPrefWidth((double) newVal);
                webView.setMaxWidth((double) newVal);
            });

            stage.heightProperty().addListener((obs, oldVal, newVal) -> {
                stage.setHeight((double) newVal);
                webView.setPrefHeight((double) newVal);
                webView.setMaxHeight((double) newVal);
            });

            stage.setScene(scene);
            stage.show();
        });
    }

    public void generateCommonTSFile() throws IOException, SQLException, URISyntaxException {
        StringBuilder commonTsContent = new StringBuilder();

            Connection connection = DbConnect.getConnect();
            PreparedStatement preparedStatement = connection.prepareStatement("SELECT name, coordinates, fio FROM shops");
            ResultSet resultSet = preparedStatement.executeQuery();

            List<String> shopData = new ArrayList<>();
            while (resultSet.next()) {
                String name = resultSet.getString("name");
                String coordinates = resultSet.getString("coordinates");
                String fio = resultSet.getString("fio");

                shopData.add("{coordinates: [" + coordinates + "],\ntitle: '" + name + "',\nsubtitle: '" + fio + "',\ncolor: '#00CC00'\n}");
            }

            commonTsContent.append("const markersGeoJsonSourc = [").append(String.join(", \n", shopData)).append(" ];");

            // Specify the path for the common.ts file
            URL commonTsFilePath = getClass().getResource(Paths.PATH_TS);
            File file = new File(Objects.requireNonNull(commonTsFilePath).toURI());

            try (BufferedWriter writer = new BufferedWriter(new FileWriter(Paths.PATH_SAVE_TS))) {
                writer.write(commonTsContent.toString());
            }

            try (BufferedWriter writer = new BufferedWriter(new FileWriter(file))) {
                writer.write(commonTsContent.toString());
            }


    }

}


