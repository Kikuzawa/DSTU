package com.kiku.javalangprogproject;

import com.kiku.javalangprogproject.config.ButtonConfigurator;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Button;


import java.net.URL;
import java.sql.SQLException;
import java.util.ResourceBundle;

public abstract class BaseController implements Initializable {
    @FXML
    private Button ButtonComplain, ButtonReport, ButtonTaxService, ButtonDisposal, ButtonSuppliers, ButtonStock, ButtonAssortment, ButtonShops, buttonReturn, ButtonMainMenu, buttonLogin, exitAppButton;
    protected final SceneController controller = SceneController.getInstance();



    protected void onInitialize() throws SQLException {

    }


    /**
     * Точка запуска базового контролера, все методы точек запуска для ост. окон его обязательно должны переопределить.
     */
    @Override
    public void initialize(URL url, ResourceBundle resourceBundle) {
        try {
            onInitialize();
        } catch (SQLException e) {
            throw new RuntimeException(e);
        }

        // try - catch стоит, так как у нас в главном меню, где стоит выбор лабораторных и приложений
        // нет backButton. Ему важно, чтобы все ID были, поэтому вот такой костыль, чтобы убрать повторы кода.

        try {
            // Обработка событий для кнопки с выходом из приложения

            ButtonConfigurator.setupButtonEvent(
                    buttonReturn,
                    event -> controller.switchToLoginPage(),
                    "Не получилось переключиться на прошлое окно"
            );

            ButtonConfigurator.setupButtonEvent(
                    ButtonAssortment,
                    event -> controller.switchToAssortimentPage(),
                    "Не получилось переключиться на прошлое окно"
            );

            ButtonConfigurator.setupButtonEvent(
                    ButtonShops,
                    event -> controller.switchToShopsPage(),
                    "Не получилось переключиться на прошлое окно"
            );
            ButtonConfigurator.setupButtonEvent(
                    ButtonMainMenu,
                    event -> controller.switchToMainMenu(),
                    "Не получилось переключиться на прошлое окно"
            );
            ButtonConfigurator.setupButtonEvent(
                    ButtonStock,
                    event -> controller.switchToStockPage(),
                    "Не получилось переключиться на прошлое окно"
            );
            ButtonConfigurator.setupButtonEvent(
                    ButtonSuppliers,
                    event -> controller.switchToSuppliersPage(),
                    "Не получилось переключиться на прошлое окно"
            );

            ButtonConfigurator.setupButtonEvent(
                    exitAppButton,
                    event -> controller.exitApp(),
                    "Не получилось переключиться на прошлое окно"
            );
            ButtonConfigurator.setupButtonEvent(
                    ButtonDisposal,
                    event -> controller.switchToDisposalPage(),
                    "Не получилось переключиться на прошлое окно"
            );


        } catch (RuntimeException ignored) {}
    }

}