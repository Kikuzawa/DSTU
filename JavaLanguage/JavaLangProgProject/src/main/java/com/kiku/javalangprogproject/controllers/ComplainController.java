package com.kiku.javalangprogproject.controllers;

import com.kiku.javalangprogproject.BaseController;
import com.kiku.javalangprogproject.Database.DbConnect;
import com.kiku.javalangprogproject.SceneController;
import com.kiku.javalangprogproject.Utils.TableSearchUtil;
import com.kiku.javalangprogproject.classes.Complain;
import com.kiku.javalangprogproject.reportGenerators.CreateJsonFromTable;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.scene.control.TableColumn;
import javafx.scene.control.TableView;
import javafx.scene.control.TextArea;
import javafx.scene.control.TextField;
import javafx.scene.control.cell.PropertyValueFactory;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;

import static com.kiku.javalangprogproject.Utils.NotificationUtils.showErrorNotification;

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

    Connection connection = null;
    PreparedStatement preparedStatement = null;
    ResultSet resultSet = null;
    ObservableList<Complain> ComplainList = FXCollections.observableArrayList();


    public void onInitialize() {
        try {


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
        } catch (Exception ex) {
            showErrorNotification(ex.getMessage());
        }

    }

    public void refreshTable() {
        try {

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
        } catch (Exception ex) {
            showErrorNotification(ex.getMessage());
        }

    }

    private void loadDate() {
        connection = DbConnect.getConnect();

        refreshTable();


        id.setCellValueFactory(new PropertyValueFactory<>("id"));
        number.setCellValueFactory(new PropertyValueFactory<>("number"));
        sender.setCellValueFactory(new PropertyValueFactory<>("sender"));
        type.setCellValueFactory(new PropertyValueFactory<>("type"));


        complainTable.setItems(ComplainList);


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
