package com.kiku.javalangprogproject.controllers;

import com.kiku.javalangprogproject.BaseController;
import javafx.event.ActionEvent;
import javafx.geometry.Insets;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.layout.Pane;
import javafx.scene.layout.VBox;
import javafx.stage.Stage;
import javafx.stage.StageStyle;

public class ReportFormatSelectionWindow extends BaseController {

    public Button excelButton;



    public Button PdfButton;
    public Button wordButton;

    public void closeWindow(ActionEvent actionEvent) {
        Stage stage = (Stage) this.excelButton.getScene().getWindow();
        stage.close();
    }
}