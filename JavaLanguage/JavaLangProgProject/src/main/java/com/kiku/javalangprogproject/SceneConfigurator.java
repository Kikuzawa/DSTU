package com.kiku.javalangprogproject;

import com.kiku.javalangprogproject.config.Paths;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.paint.Color;
import javafx.scene.shape.Rectangle;
import javafx.stage.Stage;

import java.io.IOException;
import java.util.Objects;

/**
 * Класс, который нужен, чтобы настраивать Scene.
 */
public class SceneConfigurator {

    private static final String CSS = Objects.requireNonNull(SceneConfigurator.class.getResource("Styles.css")).toExternalForm();

    private static double xOffset = 0, yOffset = 0;

    /**
     * Метод, который нужен, чтобы можно было передвигать окно
     *
     * @param windowFXML окно, которое мы хотим перетаскивать
     */
    private static void setWindowDragged(Stage stage, Parent windowFXML) {
        // Возможность, чтобы окно могло передвигаться при зажатии мышки
        windowFXML.setOnMousePressed(ev -> {
            xOffset = ev.getSceneX();
            yOffset = ev.getSceneY();
        });

        // Когда зажатое окно
        windowFXML.setOnMouseDragged(ev -> {
            stage.setX(ev.getScreenX() - xOffset);
            stage.setY(ev.getScreenY() - yOffset);
        });
    }

    /**
     * @param filePath Путь к файлу
     * @return Возвращает созданную сцену
     */
    public static Scene createScene(Stage stage, String filePath) throws IOException {
        Parent windowFXML = FXMLLoader.load(Objects.requireNonNull(SceneConfigurator.class.getResource(Paths.PATH_FXML + filePath)));
        var scene = new Scene(windowFXML);

        setWindowDragged(stage, windowFXML);

        // Проверяем, установлена ли сцена для stage
        if (stage.getScene() == null) {
            stage.setScene(scene);
        }

        // Костыль, чтобы убрать углы у приложения, которые видны в SceneBuilder
        scene.setFill(Color.TRANSPARENT);

        scene.getStylesheets().add(CSS);


        return scene;
    }

}