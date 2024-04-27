package com.kiku.javalangprogproject.controllers;

import com.kiku.javalangprogproject.BaseController;
import com.kiku.javalangprogproject.Database.DbConnect;
import com.kiku.javalangprogproject.SceneController;
import com.kiku.javalangprogproject.Utils.TableSearchUtil;
import com.kiku.javalangprogproject.classes.Complain;
import com.kiku.javalangprogproject.reportGenerators.CreateJsonFromTable;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.scene.control.*;
import javafx.scene.control.cell.PropertyValueFactory;

import java.io.IOException;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

public class ComplainController extends BaseController {

    public TextField idField;
    public TextField numberField;
    public TextField senderField;
    public TextField typeFIeld;
    public TableView<Complain> complainTable;
    public TableColumn<Complain, Integer> id;
    public TableColumn<Complain, String> number;
    public TableColumn<Complain, String> sender;
    public TableColumn<Complain, String> type;

    public TextArea commentArea;
    String query = null;
    Connection connection = null;
    PreparedStatement preparedStatement = null;
    ResultSet resultSet = null;
    Complain complain = null;
    ObservableList<Complain> ComplainList = FXCollections.observableArrayList();


    public void onInitialize() throws SQLException {
        loadDate();
        complainTable.setOnMouseClicked(event -> {
            if (event.getClickCount() == 1) {
                if (complainTable.getSelectionModel().getSelectedItem() != null) {
                    Complain selectedItem = complainTable.getSelectionModel().getSelectedItem();

                    idField.setText(String.valueOf(selectedItem.getId()));
                    numberField.setText(selectedItem.getNumber());
                    senderField.setText(selectedItem.getSender());
                    typeFIeld.setText(selectedItem.getType());
                    commentArea.setText(selectedItem.getComment());
                }
            }
        });
        TableSearchUtil.setupSearch(complainTable, searchField);

    }

    public void refreshTable() throws SQLException {

        ComplainList.clear();

        preparedStatement = connection.prepareStatement("SELECT * FROM complain");
        resultSet = preparedStatement.executeQuery();

        while (resultSet.next()) {
            ComplainList.add(new Complain(
                    resultSet.getInt("id"),
                    resultSet.getString("number"),
                    resultSet.getString("sender"),
                    resultSet.getString("type"),
                    resultSet.getString("comment")
            ));
            complainTable.setItems(ComplainList);
        }

        CreateJsonFromTable.jsonCreateComplain(complainTable);

    }

    private void loadDate() throws SQLException {
        connection = DbConnect.getConnect();

        refreshTable();


        id.setCellValueFactory(new PropertyValueFactory<>("id"));
        number.setCellValueFactory(new PropertyValueFactory<>("number"));
        sender.setCellValueFactory(new PropertyValueFactory<>("sender"));
        type.setCellValueFactory(new PropertyValueFactory<>("type"));


        complainTable.setItems(ComplainList);



    }

    public void generateReport(ActionEvent actionEvent) throws IOException {
        ReportFormatSelectionWindow.help();
        SceneController.getInstance().createReportWindow();
    }
}
