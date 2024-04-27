package com.kiku.javalangprogproject;

import com.kiku.javalangprogproject.config.Paths;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.paint.Color;

import javafx.stage.Stage;


import java.util.Objects;

import static com.kiku.javalangprogproject.Utils.NotificationUtils.showErrorNotification;


public class SceneConfigurator {

    private static final String CSS = Objects.requireNonNull(SceneConfigurator.class.getResource("Styles.css")).toExternalForm();

    private static double xOffset = 0, yOffset = 0;


    private static void setWindowDragged(Stage stage, Parent windowFXML) {
        try {

        windowFXML.setOnMousePressed(ev -> {
            xOffset = ev.getSceneX();
            yOffset = ev.getSceneY();
        });

        windowFXML.setOnMouseDragged(ev -> {
            stage.setX(ev.getScreenX() - xOffset);
            stage.setY(ev.getScreenY() - yOffset);
        });
    } catch (Exception ex) {
        showErrorNotification(ex.getMessage());
    }
    }


    public static Scene createScene(Stage stage, String filePath)  {
        try {
        Parent windowFXML = FXMLLoader.load(Objects.requireNonNull(SceneConfigurator.class.getResource(Paths.PATH_FXML + filePath)));
        var scene = new Scene(windowFXML);

        setWindowDragged(stage, windowFXML);


        if (stage.getScene() == null) {
            stage.setScene(scene);
        }


        scene.setFill(Color.TRANSPARENT);

        scene.getStylesheets().add(CSS);


        return scene;
    } catch (Exception ex) {
        showErrorNotification(ex.getMessage());
    }
        return null;
    }

}