package com.kiku.javalangprogproject.controllers;

import com.kiku.javalangprogproject.BaseController;
import com.kiku.javalangprogproject.SceneController;
import javafx.fxml.FXML;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.stage.Stage;

interface ElementMenu {
    void event();
}


public class MainMenuController extends BaseController {
    public Button exitAppButton;
    SceneController controller = SceneController.getInstance();
    @FXML
    public Button buttonReturn;
    public Button ButtonComplain;
    public Button ButtonReport;
    public Button ButtonTaxService;
    public Button ButtonDisposal;
    public Button ButtonSuppliers;
    public Button ButtonStock;
    public Button ButtonAssortment;
    public Button ButtonShops;

    private Stage stage;
    private Scene scene;


}