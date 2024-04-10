package com.kiku.javalangprogproject.config;

import javafx.scene.control.Button;

public class ButtonLabsActionMainMenu implements ActionMainMenu {

    private final Button ButtonLoginPage;

    public ButtonLabsActionMainMenu(Button buttonLogin) {
        this.ButtonLoginPage = buttonLogin;
    }

    @Override
    public void execute() {
        ButtonConfigurator.setupButtonEvent(
                ButtonLoginPage,
                event -> controller.switchToMainMenu(),
                "Не получилось переключиться с меню на лабораторные работы"
        );
    }
}
