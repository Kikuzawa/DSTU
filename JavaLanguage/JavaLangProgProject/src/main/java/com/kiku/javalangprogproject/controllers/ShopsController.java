// Контроллер "Магазины"
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


    public TextField idField;
    public TextField nameField;
    public TextField locationFIeld;
    public TextField emailField;
    public Label exceptionLabel;
    public TextField numberField;
    public TextField fioField;
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

    public void onInitialize() {
        try {
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
    } catch (Exception ex) {
        showErrorNotification(ex.getMessage());
    }
    }


    @FXML
    private void refreshTable() {
        try {

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

            generateCommonTSFile();
        } catch (Exception ex) {
            showErrorNotification(ex.getMessage());
        }

    }

    private void loadDate(){
        try {
        connection = DbConnect.getConnect();

        refreshTable();

        idShop.setCellValueFactory(new PropertyValueFactory<>("idShop"));

        nameShop.setCellValueFactory(new PropertyValueFactory<>("nameShop"));
        locationsShop.setCellValueFactory(new PropertyValueFactory<>("locationsShop"));
        emailShop.setCellValueFactory(new PropertyValueFactory<>("emailShop"));
        numberShop.setCellValueFactory(new PropertyValueFactory<>("numberShop"));
        fioShop.setCellValueFactory(new PropertyValueFactory<>("fioShop"));
    } catch (Exception ex) {
        showErrorNotification(ex.getMessage());
    }


    }

    public void generateReport() {
        try {
            ReportFormatSelectionWindow.help();
            Objects.requireNonNull(SceneController.getInstance()).createReportWindow();
        } catch (Exception ex) {
            showErrorNotification(ex.getMessage());
        }
    }


    /**
     * Этот код на Java определяет метод openMap, который пытается загрузить HTML-файл
     * (openstreetmap.html) из ресурсов, открывает новое окно браузера и отображает карту
     * с помощью компонента WebView. Размер окна установлен на 800x600 пикселей.
     * Если происходит исключение во время этого процесса, отображается уведомление об ошибке.
     */
    public void openMap() {
        try {
            // Получить URL для файла openstreetmap.html
            URL url = getClass().getResource(Paths.MAP_HTML);

            // Открыть новое окно браузера и загрузить карту
            Platform.runLater(() -> {
                WebView webView = new WebView();
                WebEngine webEngine = webView.getEngine();
                webEngine.load(Objects.requireNonNull(url).toExternalForm());



                Stage stage = new Stage();
                Scene scene = new Scene(new Group(webView));

                // Установить название окна на "Карта магазинов"
                stage.setTitle("Карта магазинов");

                // Установить начальный размер сцены
                stage.setWidth(800);
                stage.setHeight(600);

                // Добавить слушатель для изменения размера сцены при изменении размера окна
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
        } catch (Exception ex) {
            showErrorNotification(ex.getMessage());
        }
    }

    // Этот код на Java генерирует файл TypeScript с именем common.ts, необходимый для карт. Он извлекает данные,
    // формирует строку определенного формата и записывает ее в два разных места:
    // по указанному пути и на основе пути к ресурсному файлу. Если в процессе возникают
    // исключения, то выводится уведомление об ошибке с сообщением об исключении.
    public void generateCommonTSFile() {
        try {
            StringBuilder commonTsContent = new StringBuilder();

            List<String> shopData = getStrings();

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


        } catch (Exception ex) {
            showErrorNotification(ex.getMessage());
        }
    }

    private static List<String> getStrings() throws SQLException {
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
        return shopData;
    }

}


