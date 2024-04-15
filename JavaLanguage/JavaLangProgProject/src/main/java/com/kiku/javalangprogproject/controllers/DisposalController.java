package com.kiku.javalangprogproject.controllers;

import com.kiku.javalangprogproject.BaseController;
import com.kiku.javalangprogproject.Database.DbConnect;
import com.kiku.javalangprogproject.classes.Disposal;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.scene.control.*;
import javafx.scene.control.cell.PropertyValueFactory;
import java.sql.*;

import static com.kiku.javalangprogproject.controllers.NotificationUtils.showErrorNotification;

public class DisposalController extends BaseController {
    public TableView<Disposal> disposalTable = new TableView<>();
    public TableColumn<Disposal, Integer> idDisposal;
    public TableColumn<Disposal, String> nameDisposal;
    public TableColumn<Disposal, Double> quantityDisposal;
    public TableColumn<Disposal, String> reasonDisposal;
    public TableColumn<Disposal, Double> totalDisposal;


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
    public Button ButtonSuppliers;
    public Button ButtonAddDisposal;
    public Button ButtonRemoveDisposal;
    public TextField idField;
    public TextField nameField;
    public TextField quantityField;

    public Label exceptionLabel;
    public Button ButtonEditDisposal;
    public Button exitAppButton;
    public ComboBox<String> reasonCombo;


    Connection connection = null;
    PreparedStatement preparedStatement = null;
    ResultSet resultSet = null;


    ObservableList<Disposal> DisposalList = FXCollections.observableArrayList();


    public void addNewDisposal() {
        try {
            Connection connection = DbConnect.getConnect();


            String query = "INSERT INTO disposal (id, name, reason, quantity, total, cost) VALUES (?, ?, ?, ?, ?, ?)";

            PreparedStatement preparedStatement = connection.prepareStatement(query);
            preparedStatement.setString(1, idField.getText());
            preparedStatement.setString(2, nameField.getText());
            preparedStatement.setString(4, quantityField.getText());
            preparedStatement.setString(3, reasonCombo.getValue());
            preparedStatement.setString(5,"0");
            preparedStatement.setString(6,"0");


            preparedStatement.executeUpdate();

            exceptionLabel.setText("Пункт успешно добавлен.");
            refreshTable();
        } catch (Exception e) {
            showErrorNotification(e.getMessage());
        }
    }

    public void removeDisposal(ActionEvent actionEvent) {
        try {
            Connection connection = DbConnect.getConnect();
            int id = Integer.parseInt(idField.getText());
            String query = "DELETE FROM disposal WHERE id = " + id;
            int result = connection.prepareStatement(query).executeUpdate();
            if (result > 0) {
                exceptionLabel.setText("Пункт успешно удален.");
                refreshTable();
            } else {
                showErrorNotification("Failed to delete disposal. No disposal found with ID: " + id);
            }
        } catch (Exception e) {
            showErrorNotification(e.getMessage());
        }
    }

    public void EditDisposal() {
        try {
            Connection connection = DbConnect.getConnect();

            String query = "UPDATE disposal SET name = ?, quantity = ?, cost = 0, reason = ? where id = ?";

            PreparedStatement preparedStatement = connection.prepareStatement(query);
            preparedStatement.setString(1, nameField.getText());
            preparedStatement.setString(2, quantityField.getText());
            preparedStatement.setString(3, reasonCombo.getValue());
            preparedStatement.setString(4, idField.getText());


            preparedStatement.executeUpdate();
            refreshTable();
        } catch (SQLException ex) {
            showErrorNotification(ex.getMessage());
        }

    }

    public void getReason() {
        try {
            ObservableList<String> items = FXCollections.observableArrayList();
            Connection connection = DbConnect.getConnect();

            String sql = "SELECT * FROM reason";
            Statement statement = connection.createStatement();
            ResultSet resultSet = statement.executeQuery(sql);

            while (resultSet.next()) {
                String value = resultSet.getString("name");
                items.add(value);
            }

            reasonCombo.setItems(items);
            reasonCombo.setValue(items.getFirst());

        } catch (Exception ex) {
            showErrorNotification(ex.getMessage());
        }
    }

    public void onInitialize() throws SQLException {
        loadDate();
        getReason();
        disposalTable.setOnMouseClicked(event -> {
            if (event.getClickCount() == 1) {
                if (disposalTable.getSelectionModel().getSelectedItem() != null) {
                    Disposal selectedItem = disposalTable.getSelectionModel().getSelectedItem();

                    idField.setText(String.valueOf(selectedItem.getIdDisposal()));
                    nameField.setText(selectedItem.getNameDisposal());

                    quantityField.setText(String.valueOf(selectedItem.getQuantityDisposal()));
                    reasonCombo.setValue(selectedItem.getReasonDisposal());


                    // И так далее
                }
            }
        });
    }


    @FXML
    private void refreshTable() throws SQLException {

        DisposalList.clear();

        preparedStatement = connection.prepareStatement("SELECT * FROM disposal");
        resultSet = preparedStatement.executeQuery();
        Connection firstConnection = DbConnect.getConnect();
        Connection secondConnection = DbConnect.getConnect();


        while (resultSet.next()) {
            String name = resultSet.getString("name");
            double cost = 0.0; // Значение по умолчанию, если не найдено ни в одной базе данных
            double totalResult = 0.0;

            // Выполнить запрос к первой базе данных
            String query = "SELECT cost, quantity FROM stock WHERE name = ?";
            try (PreparedStatement firstStatement = firstConnection.prepareStatement(query)) {
                firstStatement.setString(1, name);
                ResultSet firstResultSet = firstStatement.executeQuery();

                if (firstResultSet.next()) {
                    cost = firstResultSet.getDouble("cost");
                    totalResult = cost * resultSet.getDouble("quantity");

                    // Создать объект Disposal с полученным значением cost
                    Disposal disposal = new Disposal(
                            resultSet.getInt("id"),
                            resultSet.getString("name"),
                            resultSet.getString("reason"),
                            resultSet.getDouble("quantity"),
                            cost,
                            totalResult
                    );



                    DisposalList.add(disposal);
                    disposalTable.setItems(DisposalList);
                } else {
                    // Если значение не найдено в первой базе данных, выполнить запрос ко второй базе данных
                    String querySecond = "SELECT cost FROM shoes WHERE name = ?";
                    try (PreparedStatement secondStatement = secondConnection.prepareStatement(querySecond)) {
                        secondStatement.setString(1, name);
                        ResultSet secondResultSet = secondStatement.executeQuery();

                        if (secondResultSet.next()) {
                            cost = secondResultSet.getDouble("cost");
                            totalResult = cost;

                            // Создать объект Disposal с полученным значением cost
                            Disposal disposal = new Disposal(
                                    resultSet.getInt("id"),
                                    resultSet.getString("name"),
                                    resultSet.getString("reason"),
                                    1,
                                    cost,
                                    totalResult
                            );

                            DisposalList.add(disposal);
                            disposalTable.setItems(DisposalList);
                        }
                    }
                }
            }
        }
        }

    private void loadDate() throws SQLException {
        connection = DbConnect.getConnect();

        refreshTable();

        idDisposal.setCellValueFactory(new PropertyValueFactory<>("idDisposal"));

        nameDisposal.setCellValueFactory(new PropertyValueFactory<>("nameDisposal"));
        reasonDisposal.setCellValueFactory(new PropertyValueFactory<>("reasonDisposal"));
        quantityDisposal.setCellValueFactory(new PropertyValueFactory<>("quantityDisposal"));
        totalDisposal.setCellValueFactory(new PropertyValueFactory<>("totalDisposal"));


    }
}
