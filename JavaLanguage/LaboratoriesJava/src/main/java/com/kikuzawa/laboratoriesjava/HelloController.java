package com.kikuzawa.laboratoriesjava;

import com.kikuzawa.laboratoriesjava.Labs.*;
import javafx.fxml.FXML;
import javafx.scene.control.Button;
import javafx.scene.control.ComboBox;
import javafx.scene.control.TextArea;
import javafx.scene.control.TextField;

public class HelloController {
    /*
        Инициализация кнопок, Combobox, полей ввода и вывода интерфейса
     */
    @FXML
    private Button zeroButton, firstButton, firstDotFirstButton, secondButton, thirdButton, thirdDotFirstButton, fourthButton, exitButton, startQuestion;
    @FXML
    private ComboBox<Integer> combobox;
    @FXML
    private TextArea condition, output;
    @FXML
    private TextField inputArgs;

    // функция выхода из программы
    @FXML
    private void exitProgram() {
        System.exit(0);
    }

    public String selectLab;
    // номера задач, которые будут отображаться в Combobox в соотстветствии с лабораторной работой
    final Integer[][] tasks = {{1},
            {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25},
            {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13},
            {1, 2, 3, 4, 5, 6, 7, 8},
            {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18},
            {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13},
            {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11}};

    //инициализация кнопок и их задействие
    @FXML
    public void initialize() {
        zeroButton.setOnAction(event -> updateComboBox(0));
        firstButton.setOnAction(event -> updateComboBox(1));
        firstDotFirstButton.setOnAction(event -> updateComboBox(2));
        secondButton.setOnAction(event -> updateComboBox(3));
        thirdButton.setOnAction(event -> updateComboBox(4));
        thirdDotFirstButton.setOnAction(event -> updateComboBox(5));
        fourthButton.setOnAction(event -> updateComboBox(6));
        startQuestion.setOnAction(event -> {
            Integer selectedTask = combobox.getValue();
            if (selectedTask != null) {
                runSelectedTask(selectLab, selectedTask);
            }
        });
        combobox.setOnAction(event -> {
            Integer selectedTask = combobox.getValue();
            if (selectedTask != null) {
                runSelectedCondition(selectLab, selectedTask);
            }
        });
    }

    private void updateComboBox(int index) {
        combobox.getItems().clear();
        for (Integer task : tasks[index]) {
            combobox.getItems().add(task);
        }
        selectLab = "LabID-" + index;
    }

    //функция отображения в поле condition условия задачи
    private void runSelectedCondition(String Lab, Integer task) {
        condition.setText(SelectToCondition.selectCondition(Lab, task));
    }


    //функция запуска определенных задач в интерфейсе
    private void runSelectedTask(String Lab, Integer task) {
        String input = inputArgs.getText();
        switch (Lab) {
            case "LabID-1":
                output.setText(TaskExecutorLabOne.execute(input, task));
                break;
            case "LabID-2":
                output.setText(TaskExecutorLabOneDOne.execute(task));
                break;case "LabID-3":
                output.setText(TaskExecutorLabTwo.execute(task));
                break;
            case "LabID-4":
                output.setText(TaskExecutorLabThree.execute(input, task));
                break;
            case "LabID-5":
                output.setText(TaskExecutorLabThreeDThree.execute(input, task));
                break;
            case "LabID-6":
                output.setText(TaskExecutorLabFour.execute(input, task));
                break;
            default:
                break;
        }
    }
}
