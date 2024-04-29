package com.kiku.javalangprogproject;

import com.kiku.javalangprogproject.config.ButtonConfigurator;

import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Button;
import javafx.scene.control.TextField;
import javafx.scene.layout.AnchorPane;

import java.net.URL;
import java.util.ResourceBundle;

import static com.kiku.javalangprogproject.Utils.NotificationUtils.showErrorNotification;

public abstract class BaseController implements Initializable {
    @FXML
    private Button wordButton, PdfButton, ButtonOpenMap, excelButton, ButtonEdit, ButtonAdd, ButtonRemove,
            ButtonRefresh, buttonReturn, ButtonComplain, ButtonReport, ButtonTaxService, ButtonDisposal,
            ButtonSuppliers, ButtonStock, ButtonAssortment, ButtonShops, ButtonMainMenu, buttonLogin,
            exitAppButton;

    protected final SceneController controller = SceneController.getInstance();
    @FXML
    protected TextField searchField;
    @FXML
    public AnchorPane pane;


    protected void onInitialize(){

    }


    @Override
    public void initialize(URL url, ResourceBundle resourceBundle) {
        try {
            onInitialize();

        } catch (Exception ex) {
            showErrorNotification(ex.getMessage());
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



            ButtonConfigurator.setupButtonEvent(
                    ButtonOpenMap
            );

            ButtonConfigurator.setupButtonEvent(
                    ButtonReport
            );

            ButtonConfigurator.setupButtonEvent(
                    ButtonEdit
            );

            ButtonConfigurator.setupButtonEvent(
                    ButtonAdd
            );

            ButtonConfigurator.setupButtonEvent(
                    ButtonRemove
            );

            ButtonConfigurator.setupButtonEvent(
                    ButtonRefresh
            );

            ButtonConfigurator.setupButtonEvent(
                    wordButton
            );

            ButtonConfigurator.setupButtonEvent(
                    PdfButton
            );

            ButtonConfigurator.setupButtonEvent(
                    excelButton
            );



        } catch (RuntimeException ignored) {
        }
    }

}