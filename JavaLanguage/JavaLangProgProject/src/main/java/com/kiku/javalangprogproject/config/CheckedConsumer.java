package com.kiku.javalangprogproject.config;

import javafx.scene.input.MouseEvent;

@FunctionalInterface
public interface CheckedConsumer {
    void accept(MouseEvent t) throws Exception;
}