package com.kiku.javalangprogproject;

import com.kiku.javalangprogproject.config.Paths;
import com.kiku.javalangprogproject.config.StageConfigurator;
import javafx.application.Application;

import javafx.scene.image.Image;
import javafx.stage.Stage;

import java.util.Objects;

public class Main extends Application {


    @Override
    public void start(Stage stage) {
        var stageInitialized = StageConfigurator.configureStage(stage);
        stageInitialized.getIcons().add(new Image(Objects.requireNonNull(getClass().getResourceAsStream(Paths.PATH_IMAGES + "icon.png"))));

        Objects.requireNonNull(SceneController.getInstance(stage)).setStartMenu();

        stageInitialized.show();
    }

}