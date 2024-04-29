package com.kiku.javalangprogproject.config;

import javafx.stage.Stage;
import javafx.stage.StageStyle;


public class StageConfigurator {


    /**
     * Конфигурирует основное окно приложения.
     *
     * @param  primaryStage	Основная сцена для настройки
     * @return         		Настроенная сцена
     */

    public static Stage configureStage(Stage primaryStage) {

        primaryStage.setTitle("Котелевец Кирилл ВКБ21");


        primaryStage.setResizable(false);


        primaryStage.initStyle(StageStyle.TRANSPARENT);

        return primaryStage;
    }
}