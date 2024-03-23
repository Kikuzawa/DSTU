package com.kikuzawa.laboratoriesjava.Labs;

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
/*
   Класс, который выводит на поле condition информацию об условиях задачи в соответствии с лабораторной работой.
   Для построения текстов для вывода в поле используется StringBuilder и чтения текста из файлов - BufferedReader.
   Блоки делятся с помощью символов "#####", затем сравниваются по индексу LabID и задач и выводятся на экран
 */

public class SelectToCondition {
    public static String selectCondition(String lab, Integer task){
        int blockNumber = task;
        String desiredBlock;
        String fileName = switch (lab) {
            case "LabID-1" -> "src/main/java/com/kikuzawa/laboratoriesjava/Conditions/TasksLab1.txt";
            case "LabID-2" -> "src/main/java/com/kikuzawa/laboratoriesjava/Conditions/TasksLab1D1.txt";
            case "LabID-3" -> "src/main/java/com/kikuzawa/laboratoriesjava/Conditions/TasksLab2.txt";
            case "LabID-4" -> "src/main/java/com/kikuzawa/laboratoriesjava/Conditions/TasksLab3.txt";
            case "LabID-5" -> "src/main/java/com/kikuzawa/laboratoriesjava/Conditions/TasksLab3D1.txt";
            case "LabID-6" -> "src/main/java/com/kikuzawa/laboratoriesjava/Conditions/TasksLab4.txt";
            default -> "src/main/java/com/kikuzawa/laboratoriesjava/Conditions/TasksLab0.txt";
        };

        try (BufferedReader reader = new BufferedReader(new FileReader(fileName))){
            StringBuilder data = new StringBuilder();
            String line;

            // Читаем файл построчно
            while ((line = reader.readLine()) != null) {
                data.append(line).append("\n");
            }

            // Разделяем текст на блоки
            String[] blocks = data.toString().split("#####");

            // Извлекаем нужный блок
            if (blockNumber <= blocks.length) {
                desiredBlock = blocks[blockNumber - 1];
                return desiredBlock;
            } else {
                return "Задание не найдено";
            }

        } catch (IOException e) {
           return String.format("Ошибка при чтении файла: %s", e.getMessage());
        }
    }
}
