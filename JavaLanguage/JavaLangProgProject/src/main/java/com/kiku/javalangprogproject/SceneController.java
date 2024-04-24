package com.kiku.javalangprogproject;


import com.kiku.javalangprogproject.Database.DbConnect;
import javafx.animation.ParallelTransition;
import javafx.animation.ScaleTransition;
import javafx.animation.TranslateTransition;
import javafx.scene.Scene;
import javafx.scene.layout.Pane;
import javafx.stage.Stage;
import javafx.stage.StageStyle;
import javafx.util.Duration;

import java.io.IOException;
import java.sql.Connection;
import java.util.Stack;

public class SceneController {
    private final Stage stage;
    private static SceneController instance;
    private final Stack<Scene> sceneHistory = new Stack<>();

    Connection connection = DbConnect.getConnect();

    public void exitApp() {
        System.exit(0);
    }


    enum Scenes {
        ;

        public static Scene SHOPS = null;
        private static Scene MAIN_MENU = null;
        private static Scene LOGIN_PAGE = null;
        private static Scene ASSORTIMENT = null;
        private static Scene STOCK = null;
        private static Scene DISPOSAL = null;

        private static Scene SUPPLIERS_REPORT = null;
        private static Scene REPORT = null;
        private static Scene FAX = null;
    }

    private enum ScenePath {
        ;
        private static final String MAIN_MENU_FXML_PATH = "mainMenu.fxml";
        private static final String LOGIN_PAGE_FXML_PATH = "loginPage.fxml";
        private static final String ASSORTIMENT_FXML_PATH = "assortiment.fxml";
        private static final String SHOPS_FXML_PATH = "shops.fxml";
        private static final String STOCK_FXML_PATH = "stock.fxml";
        private static final String DISPOSAL_FXML_PATH = "disposal.fxml";
        private static final String SUPPLIERS_FXML_PATH = "suppliers.fxml";
        private static final String REPORT_FXML_PATH = "reportFormatSelectionWindow.fxml";
        private static final String FAX_FXML_PATH = "fax.fxml";

    }

    /**
     * Конструктор сделал приватным, чтобы реализовать Singleton - гугл в помощь
     *
     * @param stage окно Stage, к которому мы хотим прикрепить наш SceneController
     */
    private SceneController(Stage stage) {
        this.stage = stage;
    }

    /**
     * Данный метод как раз и есть реализация паттерна Singleton на Java. Тут нет метода __new__, как в Python, чтобы
     * работать не зная действие под капотом.
     *
     * @param stage окно Stage, к которому мы хотим прикрепить наш SceneController
     * @return возвращает SceneController
     */
    public static SceneController getInstance(Stage stage) {
        if (instance == null) {
            instance = new SceneController(stage);
        }
        return instance;
    }

    /**
     * Метод больше как костыль, потому что в
     *
     * @return SceneController, который используется в BaseController.
     */
    public static SceneController getInstance() {
        if (instance == null) {
            throw new IllegalStateException("SceneController не был инициализирован");
        }
        return instance;
    }


    /**
     * Переключение с меню на проект
     */
    public void switchToMainMenu() {
        animationSlideWindow(Scenes.MAIN_MENU);
        sceneHistory.push(Scenes.LOGIN_PAGE);
    }

    public void switchToLoginPage() {
        animationSlideWindow(Scenes.LOGIN_PAGE);
        sceneHistory.push(Scenes.LOGIN_PAGE);
    }

    public void switchToAssortimentPage() {
        animationSlideWindow(Scenes.ASSORTIMENT);
        sceneHistory.push(Scenes.MAIN_MENU);
    }

    public void switchToShopsPage() {
        animationSlideWindow(Scenes.SHOPS);
        sceneHistory.push(Scenes.MAIN_MENU);
    }

    public void switchToStockPage() {
        animationSlideWindow(Scenes.STOCK);
        sceneHistory.push(Scenes.MAIN_MENU);
    }

    public void switchToSuppliersPage() {
        animationSlideWindow(Scenes.SUPPLIERS_REPORT);
        sceneHistory.push(Scenes.MAIN_MENU);
    }

    public void switchToDisposalPage() {
        animationSlideWindow(Scenes.DISPOSAL);
        sceneHistory.push(Scenes.MAIN_MENU);
    }

    public void switchToFaxPage() {
        animationSlideWindow(Scenes.FAX);
        sceneHistory.push(Scenes.MAIN_MENU);
    }


    public void createReportWindow() throws IOException {
        createAnimatedWindow(Scenes.REPORT);
        sceneHistory.push(Scenes.MAIN_MENU);
    }


    /**
     * Переключение с любого окна на меню.
     * Здесь используется для удобства взаимодействия с самого начала приложения.
     * При первом запуске
     */
    public void setStartMenu() throws IOException {


        Scenes.LOGIN_PAGE = SceneConfigurator.createScene(stage, ScenePath.LOGIN_PAGE_FXML_PATH);
        Scenes.MAIN_MENU = SceneConfigurator.createScene(stage, ScenePath.MAIN_MENU_FXML_PATH);
        Scenes.ASSORTIMENT = SceneConfigurator.createScene(stage, ScenePath.ASSORTIMENT_FXML_PATH);
        Scenes.SHOPS = SceneConfigurator.createScene(stage, ScenePath.SHOPS_FXML_PATH);
        Scenes.STOCK = SceneConfigurator.createScene(stage, ScenePath.STOCK_FXML_PATH);
        Scenes.DISPOSAL = SceneConfigurator.createScene(stage, ScenePath.DISPOSAL_FXML_PATH);
        Scenes.SUPPLIERS_REPORT = SceneConfigurator.createScene(stage, ScenePath.SUPPLIERS_FXML_PATH);
        Scenes.REPORT = SceneConfigurator.createScene(stage, ScenePath.REPORT_FXML_PATH);
        Scenes.FAX = SceneConfigurator.createScene(stage, ScenePath.FAX_FXML_PATH);

        stage.setScene(Scenes.LOGIN_PAGE);

    }


    /**
     * Метод, чтобы была анимация переключения между окнами приложения.
     *
     * @param scene окно, на которое мы хотим переключиться.
     */
    private void animationSlideWindow(Scene scene) {
        var oldSceneRoot = this.stage.getScene().getRoot();
        var newSceneRoot = scene.getRoot();

        // Создание анимации изменения масштаба для старой сцены
        var scaleOut = new ScaleTransition(Duration.millis(500), oldSceneRoot);
        scaleOut.setToX(0.8);
        scaleOut.setToY(0.8);

        // Создание анимации изменения масштаба для новой сцены
        var scaleIn = new ScaleTransition(Duration.millis(500), newSceneRoot);
        scaleIn.setFromX(1.2);
        scaleIn.setFromY(1.2);
        scaleIn.setToX(1.0);
        scaleIn.setToY(1.0);

        // Создание анимации смещения для новой сцены
        var translateIn = new TranslateTransition(Duration.millis(500), newSceneRoot);
        translateIn.setToX(0);

        // Комбинирование анимаций
        var parallelTransition = new ParallelTransition(scaleOut, scaleIn, translateIn);

        // Установка обработчика завершения анимации
        parallelTransition.setOnFinished(e -> {
            this.stage.setScene(scene);
        });

        // Запуск комбинированной анимации
        parallelTransition.play();
    }

    public void createAnimatedWindow(Scene newScene) {
        Stage newStage = new Stage();

        newStage.setScene(newScene);
        newStage.initStyle(StageStyle.UNDECORATED);
        Pane root = (Pane) newScene.getRoot();
        root.setOnMousePressed(event -> {
            newStage.setUserData(new double[]{event.getScreenX() - newStage.getX(), event.getScreenY() - newStage.getY()});
        });

        root.setOnMouseDragged(event -> {
            double[] userData = (double[]) newStage.getUserData();
            newStage.setX(event.getScreenX() - userData[0]);
            newStage.setY(event.getScreenY() - userData[1]);
        });
        newStage.show();
    }


}