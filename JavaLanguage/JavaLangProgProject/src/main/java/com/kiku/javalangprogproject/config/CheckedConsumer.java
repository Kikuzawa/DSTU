package com.kiku.javalangprogproject.config;

import javafx.scene.input.MouseEvent;

/**
 * Функциональный интерфейс, который может генерировать исключение.
 */

@FunctionalInterface
public interface CheckedConsumer {
    void accept(MouseEvent t) throws Exception;
}