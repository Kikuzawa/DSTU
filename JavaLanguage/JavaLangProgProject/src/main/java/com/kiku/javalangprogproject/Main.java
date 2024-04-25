package com.kiku.javalangprogproject;

import com.kiku.javalangprogproject.config.Paths;
import com.kiku.javalangprogproject.config.SOUND;
import com.kiku.javalangprogproject.config.StageConfigurator;
import javafx.application.Application;
import javafx.scene.Node;
import javafx.scene.control.Button;
import javafx.scene.image.Image;
import javafx.stage.Stage;

import java.io.IOException;
import java.nio.file.Path;
import java.util.Objects;

public class Main extends Application {
    private Node primaryStage;

    @Override
    public void start(Stage stage) throws IOException {
        var stageInitialized = StageConfigurator.configureStage(stage);
        stageInitialized.getIcons().add(new Image(Objects.requireNonNull(getClass().getResourceAsStream(Paths.PATH_IMAGES + "icon.png"))));

        SceneController.getInstance(stage).setStartMenu();
//        for (Node node : stage.getScene().getRoot().getChildrenUnmodifiable()) {
//            if (node instanceof Button) {
//                Button button = (Button) node;
//                button.setOnMouseEntered(event -> SOUND.HOVER.play());
//                button.setOnMouseClicked(event -> SOUND.CLICK.play());
//            }
//        }
        stageInitialized.show();
    }

}