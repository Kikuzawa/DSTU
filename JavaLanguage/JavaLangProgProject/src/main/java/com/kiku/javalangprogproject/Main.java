package com.kiku.javalangprogproject;

import com.kiku.javalangprogproject.config.StageConfigurator;
import javafx.application.Application;
import javafx.stage.Stage;

import java.io.IOException;

public class Main extends Application {
    @Override
    public void start(Stage stage) throws IOException {
        var stageInitialized = StageConfigurator.configureStage(stage);

        SceneController.getInstance(stage).setStartMenu();
        stageInitialized.show();
    }

}