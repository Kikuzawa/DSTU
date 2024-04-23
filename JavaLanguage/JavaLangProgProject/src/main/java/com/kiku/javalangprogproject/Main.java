package com.kiku.javalangprogproject;

import com.kiku.javalangprogproject.config.StageConfigurator;
import javafx.application.Application;
import javafx.scene.image.Image;
import javafx.stage.Stage;

import java.io.IOException;
import java.util.Objects;

public class Main extends Application {
    @Override
    public void start(Stage stage) throws IOException {
        var stageInitialized = StageConfigurator.configureStage(stage);
        stageInitialized.getIcons().add(new Image(Objects.requireNonNull(getClass().getResourceAsStream("icon.png"))));

        SceneController.getInstance(stage).setStartMenu();
        stageInitialized.show();
    }

}