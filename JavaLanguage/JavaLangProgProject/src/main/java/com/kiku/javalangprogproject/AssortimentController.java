package com.kiku.javalangprogproject;

import com.kiku.javalangprogproject.Database.DbConnect;
import com.kiku.javalangprogproject.Database.Shoe;
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
import javafx.stage.StageStyle;

import java.io.IOException;
import java.sql.*;
import java.util.Objects;


@SuppressWarnings("ALL")
public class AssortimentController {
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


    String query = null;
    Connection connection = null;
    PreparedStatement preparedStatement = null;
    ResultSet resultSet = null;
    Shoe shoe = null;

    ObservableList<Shoe> ShoeList = FXCollections.observableArrayList();

    public Button ButtonRefresh;


    private Stage stage;
    private Scene scene;


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

    public void switchToStockPage(ActionEvent actionEvent) {
    }

    public void switchToSuppliersPage(ActionEvent actionEvent) {
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
            System.out.println(e);
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
            System.out.println(e);
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
            System.out.println(e);
        }
    }

    public void initialize() throws SQLException {
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

                    // И так далее
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
        } catch (Exception e) {
            exceptionLabel.setText("Обувь не была добавлена. Причина: " + e.getMessage());
        }
    }

    public void removeShoe() {
        try {
            Connection connection = DbConnect.getConnect();
            int id = Integer.parseInt(idAddShoe.getText());
            String query = "DELETE FROM shoes WHERE id = " + id;
            connection.prepareStatement(query).executeUpdate();
            exceptionLabel.setText("Обувь успешно удалена.");
            refreshTable();
        } catch (Exception e) {
            exceptionLabel.setText("Обувь не была удалена. Причина: " + e.getMessage());
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
            throw new RuntimeException(ex);
        }
    }
}

