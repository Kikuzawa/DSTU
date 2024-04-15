package com.kiku.javalangprogproject.controllers;
import com.kiku.javalangprogproject.SOUND;
import javafx.scene.control.Alert;
import javafx.scene.control.Alert.AlertType;
import javafx.application.Platform;
public class NotificationUtils {

    public static void showErrorNotification(String message) {
        Platform.runLater(() -> {
            // Воспроизводим звук уведомления
            SOUND.ERROR.play();

            // Показываем всплывающее окно с ошибкой
            Alert alert = new Alert(AlertType.ERROR);
            alert.setTitle("Ошибка!");
            alert.setHeaderText(null);
            alert.setContentText(message);
            alert.showAndWait();
        });
    }}




