package com.kiku.javalangprogproject.config;

import javafx.scene.control.Button;

public class ButtonProjectActionMainMenu implements ActionMainMenu {

    private Button ButtonProject;

    @Override
    public void execute() {
        ButtonConfigurator.setupButtonEvent(
                ButtonProject,
                event -> controller.switchToMainMenu(),
                "Не получилось переключиться с меню на проект"
        );
    }
}
