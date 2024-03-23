package com.kikuzawa.laboratoriesjava.classes;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

// класс односвязных списков
public class LinkedListOperations {
    List<Integer> list = new ArrayList<>();

    // Инициализация списка
    public void initializeList(String input) {
        String[] numberStrings = input.split(" ");

        for (String numberString : numberStrings) {
            int number = Integer.parseInt(numberString);
            list.add(number);
        }
    }

    // печать списка
    public String printList() {
        StringBuilder result = new StringBuilder("[ ");
        for (Integer element : list) {
            result.append(element).append(" ");
        }
        result.append(" ]");
        return result.toString();
    }

    // преобразование списка в строку
    public String ListToString() {
        StringBuilder result = new StringBuilder();
        for (Integer element : list) {
            result.append(element).append(" ");
        }
        result.delete(result.length() - 1, result.length());
        return result.toString();
    }

    // Добавление элемента в начало списка
    public void addElementToStart(int element) {
        list.addFirst(element);
    }

    // Добавление элемента в конец списка
    public void addElementToEnd(int element) {
        list.add(element);
    }


    // Удаление всех элементов списка
    public void deleteAllElements() {
        list.clear();
    }

    // Определение количества элементов списка
    public int countElements() {
        return list.size();
    }

    // Проверка списка на пустоту
    public boolean isListEmpty() {
        return list.isEmpty();
    }

    // Удаление первого элемента
    public void deleteFirstElement() {
        if (!list.isEmpty()) {
            list.removeFirst();
        }
    }

    // Удаление последнего элемента
    public void deleteLastElement() {
        if (!list.isEmpty()) {
            list.removeLast();
        }
    }

    // Поиск данного значения в списке
    public boolean searchElement(int element) {
        return list.contains(element);
    }

    // Поиск наибольшего значения в списке
    public int findMaximumValue() {
        if (!list.isEmpty()) {
            return Collections.max(list);
        }
        return Integer.MIN_VALUE;
    }

    // Поиск наименьшего значения в списке
    public int findMinimumValue() {
        if (!list.isEmpty()) {
            return Collections.min(list);
        }
        return Integer.MAX_VALUE;
    }

    // Удаление элемента списка с данным значением
    public void deleteElement(int element) {
        list.removeIf(e -> e == element);
    }

    // Удаление всех элементов списка с данным значением
    public void deleteAllElementsWithValue(int element) {
        list.removeIf(e -> e == element);
    }

    // Изменение всех элементов списка с данным значением на новое
    public void replaceElement(int oldValue, int newValue) {
        Collections.replaceAll(list, oldValue, newValue);
    }


    // Определение, является ли список симметричным
    public boolean isListSymmetric() {
        int size = list.size();
        for (int i = 0; i < size / 2; i++) {
            if (!list.get(i).equals(list.get(size - i - 1))) {
                return false;
            }
        }
        return true;
    }

    // Определение, можно ли удалить из списка каких-нибудь два элемента так, чтобы новый список оказался упорядоченным
    public boolean canRemoveTwoElementsToOrderedList() {
        List<Integer> sortedList = new ArrayList<>(list);
        Collections.sort(sortedList);

        for (int i = 0; i < sortedList.size() - 1; i++) {
            List<Integer> tempList = new ArrayList<>(sortedList);
            //noinspection SuspiciousListRemoveInLoop
            tempList.remove(i);
            //noinspection SuspiciousListRemoveInLoop
            tempList.remove(i);

            if (isListOrdered(tempList)) {
                return true;
            }
        }
        return false;
    }

    // Проверка списка на упорядоченность
    private boolean isListOrdered(List<Integer> tempList) {
        for (int i = 0; i < tempList.size() - 1; i++) {
            if (tempList.get(i) > tempList.get(i + 1)) {
                return false;
            }
        }
        return true;
    }

    // Определение, сколько различных значений содержится в списке
    public int countDistinctValues() {
        List<Integer> distinctValues = new ArrayList<>();
        for (int i : list) {
            if (!distinctValues.contains(i)) {
                distinctValues.add(i);
            }
        }
        return distinctValues.size();
    }

    // Удаление из списка элементов, значения которых уже встречались в предыдущих элементах
    public void deleteDuplicateElements() {
        List<Integer> distinctValues = new ArrayList<>();
        List<Integer> tempList = new ArrayList<>();

        for (int i : list) {
            if (!distinctValues.contains(i)) {
                distinctValues.add(i);
                tempList.add(i);
            }
        }

        list = tempList;
    }

    // Изменение порядка элементов на обратный
    public void reverseListOrder() {
        Collections.reverse(list);
    }


}
