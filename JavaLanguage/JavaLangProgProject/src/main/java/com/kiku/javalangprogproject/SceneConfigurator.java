package com.kiku.javalangprogproject;

import com.kiku.javalangprogproject.config.Paths;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.paint.Color;

import javafx.stage.Stage;


import java.util.Objects;

import static com.kiku.javalangprogproject.Utils.NotificationUtils.showErrorNotification;


// Конфигуратор сцен

public class SceneConfigurator {

    private static final String CSS = Objects.requireNonNull(SceneConfigurator.class.getResource("Styles.css")).toExternalForm();

    private static double xOffset = 0, yOffset = 0;

    /**
     * Устанавливает возможность перетаскивания окна в приложении.
     *
     * @param  stage      JavaFX сцена, которую нужно сделать перетаскиваемой
     * @param  windowFXML родительский узел содержимого окна в формате FXML
     */

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


    /**
     * Создает сцену для указанного Stage, используя указанный путь к файлу.
     *
     * @param  stage    Stage для создания сцены
     * @param  filePath путь к файлу FXML
     * @return          созданная сцена
     */
    public static Scene createScene(Stage stage, String filePath)  {
        try {
        Parent windowFXML = FXMLLoader.load(Objects.requireNonNull(SceneConfigurator.class.getResource(Paths.PATH_FXML + filePath)));
        var scene = new Scene(windowFXML);

        setWindowDragged(stage, windowFXML);


        if (stage.getScene() == null) {
            stage.setScene(scene);
        }


        // Заполняем сцену прозрачным фоном
        scene.setFill(Color.TRANSPARENT);

        // Подключаем стили
        scene.getStylesheets().add(CSS);


        return scene;
    } catch (Exception ex) {
        showErrorNotification(ex.getMessage());
    }
        return null;
    }

}