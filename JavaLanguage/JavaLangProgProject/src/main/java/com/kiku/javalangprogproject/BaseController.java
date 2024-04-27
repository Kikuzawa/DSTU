package com.kiku.javalangprogproject;

import com.kiku.javalangprogproject.config.ButtonConfigurator;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Button;
import javafx.scene.control.TextField;


import java.io.IOException;
import java.lang.reflect.Field;
import java.net.URL;
import java.sql.SQLException;
import java.util.ResourceBundle;

public abstract class BaseController implements Initializable {
    @FXML
    private Button buttonReturn, ButtonComplain, ButtonReport, ButtonTaxService, ButtonDisposal, ButtonSuppliers, ButtonStock, ButtonAssortment, ButtonShops, ButtonMainMenu, buttonLogin, exitAppButton, searchButton;
    protected final SceneController controller = SceneController.getInstance();
    @FXML
    private Button ButtonRefresh;
    @FXML
    protected TextField searchField;



    protected void onInitialize() throws SQLException, IOException {

    }


    @Override
    public void initialize(URL url, ResourceBundle resourceBundle) {
        try {
            onInitialize();
        } catch (SQLException | IOException e) {
            throw new RuntimeException(e);
        }


        try {

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
            ButtonConfigurator.setupButtonEvent(
                    ButtonTaxService,
                    event -> controller.switchToFaxPage(),
                    "Не получилось переключиться на прошлое окно"
            );

            ButtonConfigurator.setupButtonEvent(
                    ButtonComplain,
                    event -> controller.switchToComplainPage(),
                    "Не получилось переключиться на прошлое окно"
            );





        } catch (RuntimeException ignored) {}
    }

}