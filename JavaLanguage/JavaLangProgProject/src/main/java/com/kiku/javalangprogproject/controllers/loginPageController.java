package com.kiku.javalangprogproject.controllers;


import com.kiku.javalangprogproject.BaseController;
import com.kiku.javalangprogproject.Database.ConnectionFactory;
import com.kiku.javalangprogproject.config.SOUND;
import javafx.fxml.FXML;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.TextField;

import static com.kiku.javalangprogproject.Utils.NotificationUtils.showErrorNotification;


public class loginPageController extends BaseController {
    @FXML
    public Button buttonLogin;
    public Button buttonClear;
    public TextField loginField;
    public TextField passwordField;
    public Label exceptionLabel;
    public Button exitAppButton;

    /* Этот код на Java определяет метод switchToMainMenu,
     * который получает ввод логина и пароля, затем пытается
     * аутентифицировать пользователя с предоставленными учетными данными.
     * В случае успешной аутентификации происходит переход на главное меню;
     * в противном случае проигрывается звук ошибки и выводится соответствующее сообщение. */

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
        try {
            exceptionLabel.setText("");
            loginField.clear();
            passwordField.clear();
        } catch (Exception ex) {
            showErrorNotification(ex.getMessage());
        }
    }


    public void exitApp() {
        System.exit(0);
    }
}