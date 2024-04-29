package com.kiku.javalangprogproject.config;

import javafx.event.EventHandler;
import javafx.scene.control.ButtonBase;
import javafx.scene.input.MouseEvent;


public class ButtonConfigurator {

    private static ButtonConfigurator instance;

    public static ButtonConfigurator getInstance() {
        if (instance == null)
            instance = new ButtonConfigurator();
        return instance;
    }


    public static void setupButtonEvent(ButtonBase button, EventHandler<MouseEvent> eventHandler) {
        // Обработка того момента, когда мышка наводится на кнопку.
        button.setOnMouseEntered(event -> SOUND.HOVER.play());

        // Обработка того момента, когда нажали на кнопку.
        button.setOnMouseClicked(event -> {
            SOUND.CLICK.play();
            eventHandler.handle(event); // Передача объекта MouseEvent в обработчике события
        });
    }





    public static void setupButtonEvent(ButtonBase button, CheckedConsumer action, String errorMessage) {
        EventHandler<MouseEvent> eventHandler = event -> {
            try {
                action.accept(event);
            } catch (Exception e) {
                throw new RuntimeException(errorMessage, e);
            }
        };
        setupButtonEvent(button, eventHandler);
    }

    public static void setupButtonEvent(ButtonBase button) {
        EventHandler<MouseEvent> eventHandler = event -> {
            try {
                SOUND.CLICK.play(); // Воспроизведение звука щелчка
            } catch (Exception e) {
                throw new RuntimeException(e);
            }
        };

        // Настройка звука наведения
        button.setOnMouseEntered(event -> {
            SOUND.HOVER.play();
        });

        setupButtonEvent(button, eventHandler);
    }



}