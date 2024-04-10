package com.kiku.javalangprogproject.config;


import com.kiku.javalangprogproject.SceneController;

public interface ActionMainMenu {

    ButtonConfigurator buttonConfigurator = ButtonConfigurator.getInstance();
    SceneController controller = SceneController.getInstance();

    void execute();
}
