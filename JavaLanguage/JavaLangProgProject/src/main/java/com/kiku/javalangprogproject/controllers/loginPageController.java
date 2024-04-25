package com.kiku.javalangprogproject.controllers;


import com.kiku.javalangprogproject.BaseController;
import com.kiku.javalangprogproject.Database.ConnectionFactory;
import com.kiku.javalangprogproject.config.SOUND;
import javafx.fxml.FXML;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.TextField;



public class loginPageController extends BaseController {
    @FXML
    public Button buttonLogin;
    public Button buttonClear;
    public TextField loginField;
    public TextField passwordField;
    public Label exceptionLabel;
    public Button exitAppButton;


    @FXML
    public void switchToMainMenu() {
        String login = loginField.getText();
        String password = passwordField.getText();
        String userType = "ADMINISTRATOR";
        if (new ConnectionFactory().checkLogin(login, password, userType)) {
            controller.switchToMainMenu();
        } else {
            SOUND.ERROR.play();
            exceptionLabel.setText("Неправильный логин или пароль");
        }
    }

    public void clearAllFileds() {
        exceptionLabel.setText("");
        loginField.clear();
        passwordField.clear();
    }


    public void exitApp() {
        System.exit(0);
    }
}