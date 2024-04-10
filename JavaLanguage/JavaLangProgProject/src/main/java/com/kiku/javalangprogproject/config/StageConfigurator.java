package com.kiku.javalangprogproject.config;

import javafx.scene.image.Image;
import javafx.stage.Stage;
import javafx.stage.StageStyle;

/**
 * Класс, который позволяет конфигурировать отдельный stage под мои требования.
 */
public class StageConfigurator {

    /**
     * Метод, который и производит настройку всего
     * @param primaryStage Stage, который мы хотим настроить
     * @return отформатированный Stage
     */
    public static Stage configureStage(Stage primaryStage) {
        // Название приложения
        primaryStage.setTitle("Котелевец Кирилл ВКБ21");

        // Установка неизменяемости по размеру, так как я немного криво располагаю элементы.
        // Не умею в масштабируемое приложение, поэтому так.
        primaryStage.setResizable(false);


        // Определяю так, чтобы не было системных Windows компонентов, так как с ними выглядит ужасно.
        primaryStage.initStyle(StageStyle.TRANSPARENT);

        return primaryStage;
    }
}