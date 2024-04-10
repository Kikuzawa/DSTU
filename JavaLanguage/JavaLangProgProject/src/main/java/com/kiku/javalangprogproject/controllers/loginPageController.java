package com.kiku.javalangprogproject.controllers;


import com.kiku.javalangprogproject.config.ActionMainMenu;
import com.kiku.javalangprogproject.BaseController;
import com.kiku.javalangprogproject.config.ButtonLabsActionMainMenu;
import com.kiku.javalangprogproject.Database.ConnectionFactory;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.TextField;


import java.io.IOException;
import java.net.URL;
import java.util.ResourceBundle;
import java.util.stream.Stream;


public class loginPageController extends BaseController {
    @FXML
    public Button buttonLogin;
    public Button buttonClear;
    public TextField loginField;
    public TextField passwordField;
    public Label exceptionLabel;
    public Button exitAppButton;


    @FXML
    public void switchToMainMenu(ActionEvent event) throws IOException {
        String login = loginField.getText();
        String password = passwordField.getText();
        String userType = "ADMINISTRATOR";
        if (new ConnectionFactory().checkLogin(login, password, userType)){
            controller.switchToMainMenu();}
        else{exceptionLabel.setText("Invalid username or password.");}
    }

    public void clearAllFileds() {
        loginField.clear();
        passwordField.clear();
    }


    public void initialize(ResourceBundle resourceBundle, URL url){


        super.initialize(url, resourceBundle);



        Stream.of(
                new ButtonLabsActionMainMenu(buttonLogin)
        ).parallel().forEach(ActionMainMenu::execute);

    }


    public void exitApp(ActionEvent actionEvent) {
        System.exit(0);
    }
}