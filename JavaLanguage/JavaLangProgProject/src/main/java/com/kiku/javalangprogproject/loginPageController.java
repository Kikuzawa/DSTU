package com.kiku.javalangprogproject;


import com.kiku.javalangprogproject.Database.ConnectionFactory;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.scene.Node;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.ComboBox;
import javafx.scene.control.Label;
import javafx.scene.control.TextField;
import javafx.stage.Stage;


import java.io.IOException;
import java.util.Objects;


public class loginPageController {
    @FXML
    public Button buttonLogin;
    public Button buttonClear;
    public TextField loginField;
    public TextField passwordField;
    public Label exceptionLaber;

    public ComboBox<String> comboBoxLoginPage;


    @FXML
    public void switchToMainMenu(ActionEvent event) throws IOException {
        String login = loginField.getText();
        String password = passwordField.getText();
        String userType = (String)comboBoxLoginPage.getSelectionModel().getSelectedItem();
        if (new ConnectionFactory().checkLogin(login, password, userType)){
            Parent root = FXMLLoader.load(Objects.requireNonNull(getClass().getResource("mainMenu.fxml")));
            Stage stage = (Stage) ((Node) event.getSource()).getScene().getWindow();
            Scene scene = new Scene(root);
            stage.setScene(scene);
            stage.show();}
        else{exceptionLaber.setText("Invalid username or password.");}
    }

    public void clearAllFileds() {
        loginField.clear();
        passwordField.clear();
    }

    public void initialize(){
        ObservableList<String> items = FXCollections.observableArrayList("ADMINISTRATOR", "EMPLOYEE");
        comboBoxLoginPage.setItems(items);
        comboBoxLoginPage.setValue(items.get(0));
    }


}