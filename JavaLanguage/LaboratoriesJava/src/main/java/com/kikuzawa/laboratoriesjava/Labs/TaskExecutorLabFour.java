/**
 * Класс TaskExecutorLabFour содержит реализации различных задач из лабораторной работы 4,
 * связанных с операциями над списками и работой со студентами и книгами.
 * Включает методы для выполнения конкретных задач, таких как инициализация списка,
 * добавление элементов, удаление, поиск, сортировка и другие операции.
 */
package com.kikuzawa.laboratoriesjava.Labs;

import com.kikuzawa.laboratoriesjava.classes.*;

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.util.*;
import java.util.stream.Collectors;
import java.util.stream.IntStream;


@SuppressWarnings({"CallToPrintStackTrace", "DuplicatedCode"})
public class TaskExecutorLabFour {

    static final LinkedListOperations list1 = new LinkedListOperations();
    static final DoublyLinkedList list2 = new DoublyLinkedList();
    static final List<Book> books = new ArrayList<>();

    static final List<Student1> students = new ArrayList<>();

    public static String execute(String input, int task) {
        return switch (task) {
            case 1 -> Task1From20(input);
            case 2 -> Task2From20(input);
            case 3 -> Task3(input);
            case 4 -> Task4(input);
            case 5 -> Task5(input);
            case 6 -> Task6(input);
            case 7 -> Task7(input);
            case 8 -> Task8();
            case 9 -> Task9();
            case 10 -> Task10();
            case 11 -> Task11(input);
            default -> "Пока не реализовано";
        };
    }

    private static String Task1From20(String input1) {
        try {
            //noinspection DuplicatedCode
            String[] numberStrings = input1.split(" ");
            String task = numberStrings[0];
            StringJoiner joiner = new StringJoiner(" ");

            for (int i = 1; i < numberStrings.length; i++) {
                joiner.add(numberStrings[i]);
            }

            String input = joiner.toString();

            return switch (task) {
                case "1*" -> Task1_1(input);
                case "2*" -> Task1_2(input);
                case "3*" -> Task1_3(input);
                case "4*" -> Task1_4();
                case "5*" -> Task1_5();
                case "6*" -> Task1_6();
                case "7*" -> Task1_7();
                case "8*" -> Task1_8();
                case "9*" -> Task1_9();
                case "10*" -> Task1_10(input);
                case "11*" -> Task1_11();
                case "12*" -> Task1_12(input);
                case "13*" -> Task1_13(input);
                case "14*" -> Task1_14(input);
                case "15*" -> Task1_15();
                case "16*" -> Task1_16();
                case "17*" -> Task1_17();
                case "18*" -> Task1_18();
                case "19*" -> Task1_19();
                case "20*" -> Task1_20();
                default -> throw new IllegalStateException("Unexpected value: " + task);
            };


        } catch (Exception e) {
            throw new RuntimeException(e);
        }


    }

    private static String Task1_1(String input) {
        try {
            list1.deleteAllElements();
            list1.initializeList(input);
            return "Инизиализация нового списка: " + list1.printList();
        } catch (Exception e) {
            return "Ошибка: " + e;
        }
    }

    private static String Task1_2(String input) {
        try {
            String oldResult = list1.printList();
            int num = Integer.parseInt(input);
            list1.addElementToStart(num);
            return String.format("Изначальный список: %s \n Добавление элемента %s \n Новый список: %s", oldResult, num, list1.printList());
        } catch (Exception e) {
            return "Ошибка: " + e;
        }
    }

    private static String Task1_3(String input) {
        try {
            String oldResult = list1.printList();
            int num = Integer.parseInt(input);
            list1.addElementToEnd(num);
            return String.format("Изначальный список: %s \n Добавление элемента %s \n Новый список: %s", oldResult, num, list1.printList());
        } catch (Exception e) {
            return "Ошибка: " + e;
        }
    }

    private static String Task1_4() {
        return list1.printList();
    }

    private static String Task1_5() {
        try {
            String oldResult = list1.printList();
            list1.deleteAllElements();
            return String.format("Изначальный список: %s \n Успешно очистен!", oldResult);
        } catch (Exception e) {
            return "Ошибка: " + e;
        }
    }

    private static String Task1_6() {
        return "В списке:\n" + list1.printList() + "\nЭлементов - " + list1.countElements();
    }

    private static String Task1_7() {
        return "Проверка списка на пустоту.\nРезультат: " + list1.isListEmpty();
    }

    private static String Task1_8() {
        try {
            String oldResult = list1.printList();
            list1.deleteFirstElement();
            return String.format("Изначальный список: %s \nУдаление первого элемента\nНовый список: %s", oldResult, list1.printList());
        } catch (Exception e) {
            return "Ошибка: " + e;
        }
    }

    private static String Task1_9() {
        try {
            String oldResult = list1.printList();
            list1.deleteLastElement();
            return String.format("Изначальный список: %s \nУдаление последнего элемента\nНовый список: %s", oldResult, list1.printList());
        } catch (Exception e) {
            return "Ошибка: " + e;
        }
    }

    private static String Task1_10(String input) {
        try {
            int num = Integer.parseInt(input);
            return String.format("Список: %s \nПринадлежность элемента %s к списку - %s", list1.printList(), num, list1.searchElement(num));
        } catch (Exception e) {
            return "Ошибка: " + e;
        }
    }

    private static String Task1_11() {
        return String.format("Список %s\nНаибольшее значение - %s\nНаименьшее значение - %s", list1.printList(), list1.findMaximumValue(), list1.findMinimumValue());
    }

    private static String Task1_12(String input) {
        try {
            String oldResult = list1.printList();
            int num = Integer.parseInt(input);
            list1.deleteElement(num);
            return String.format("Исходный список %s\nУдаление элемента со значением %s\nНовый список %s", oldResult, num, list1.printList());
        } catch (NumberFormatException e) {
            throw new RuntimeException(e);
        }
    }

    private static String Task1_13(String input) {
        try {
            String oldResult = list1.printList();
            int num = Integer.parseInt(input);
            list1.deleteAllElementsWithValue(num);
            return String.format("Исходный список %s\nУдаление всех элементов со значением %s\nНовый список %s", oldResult, num, list1.printList());
        } catch (NumberFormatException e) {
            throw new RuntimeException(e);
        }
    }

    private static String Task1_14(String input) {
        try {
            String oldResult = list1.printList();
            String[] srt = input.split(" ");
            int num1 = Integer.parseInt(srt[0]);
            int num2 = Integer.parseInt(srt[1]);
            list1.replaceElement(num1, num2);
            return String.format("Список: %s\nЗамена элемента %s на %s\nНовый список: %s", oldResult, num1, num2, list1.printList());

        } catch (NumberFormatException e) {
            throw new RuntimeException(e);
        }
    }

    private static String Task1_15() {
        return "Симметричность списка " + list1.printList() + " - " + list1.isListSymmetric();
    }

    private static String Task1_16() {
        return "Результат проверки списка " + list1.printList() + " - " + list1.canRemoveTwoElementsToOrderedList();
    }

    private static String Task1_17() {
        return "Различных значений содержится в списке: " + list1.countDistinctValues();
    }

    private static String Task1_18() {
        String oldResult = list1.printList();
        list1.deleteDuplicateElements();
        return "Старый список " + oldResult + "\nНовый список " + list1.printList();
    }

    private static String Task1_19() {
        String oldResult = list1.printList();
        list1.reverseListOrder();
        return "Старый список " + oldResult + "\nНовый список " + list1.printList();
    }

    //TODO
    private static String Task1_20() {
        String oldResult = list1.ListToString();

        DoublyLinkedList list = new DoublyLinkedList();
        list.clear();
        String[] numberStrings = oldResult.split(" ");

        for (String numberString : numberStrings) {
            int number = Integer.parseInt(numberString);
            list.addToEnd(number);
        }
        DoublyLinkedList listK = new DoublyLinkedList();
        listK.clone(list);

        list.sortLinkedListByPointers();
        listK.sortLinkedListByValues();


        return "Старый список " + oldResult + "\nНовый список с изменением указателей " + list.display() + "\nНовый список с изменением значения " + listK.display();

    }

    private static String Task2From20(String input1) {
        try {
            //noinspection DuplicatedCode
            String[] numberStrings = input1.split(" ");
            String task = numberStrings[0];
            StringJoiner joiner = new StringJoiner(" ");

            for (int i = 1; i < numberStrings.length; i++) {
                joiner.add(numberStrings[i]);
            }


            String input = joiner.toString();

            return switch (task) {
                case "1*" -> Task2_1(input);
                case "2*" -> Task2_2(input);
                case "3*" -> Task2_3(input);
                case "4*" -> Task2_4();
                case "5*" -> Task2_5();
                case "6*" -> Task2_6();
                case "7*" -> Task2_7();
                case "8*" -> Task2_8();
                case "9*" -> Task2_9();
                case "10*" -> Task2_10(input);
                case "11*" -> Task2_11();
                case "12*" -> Task2_12(input);
                case "13*" -> Task2_13(input);
                case "14*" -> Task2_14(input);
                case "15*" -> Task2_15();
                case "16*" -> Task2_16();
                case "17*" -> Task2_17();
                case "18*" -> Task2_18();
                case "19*" -> Task2_19();
                case "20*" -> Task2_20();
                default -> throw new IllegalStateException("Unexpected value: " + task);
            };


        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }

    private static String Task2_1(String input) {
        try {
            list2.clear();
            String[] numberStrings = input.split(" ");

            for (String numberString : numberStrings) {
                int number = Integer.parseInt(numberString);
                list2.addToEnd(number);
            }


            return "Инизиализация нового списка: " + list2.display();
        } catch (Exception e) {
            return "Ошибка: " + e;
        }
    }

    private static String Task2_2(String input) {
        try {
            String oldResult = list2.display();
            int num = Integer.parseInt(input);
            list2.addToFront(num);
            return String.format("Изначальный список: %s \n Добавление элемента %s \n Новый список: %s", oldResult, num, list2.display());
        } catch (Exception e) {
            return "Ошибка: " + e;
        }
    }

    private static String Task2_3(String input) {
        try {
            String oldResult = list2.display();
            int num = Integer.parseInt(input);
            list2.addToEnd(num);
            return String.format("Изначальный список: %s \n Добавление элемента %s \n Новый список: %s", oldResult, num, list2.display());
        } catch (Exception e) {
            return "Ошибка: " + e;
        }
    }

    private static String Task2_4() {
        return list2.display();
    }

    private static String Task2_5() {
        try {
            String oldResult = list2.display();
            list2.clear();
            return String.format("Изначальный список: %s \n Успешно очистен!", oldResult);
        } catch (Exception e) {
            return "Ошибка: " + e;
        }
    }

    private static String Task2_6() {
        return "В списке:\n" + list2.display() + "\nЭлементов - " + list2.getSize();
    }

    private static String Task2_7() {
        return "Проверка списка на пустоту.\nРезультат: " + list2.isEmpty();
    }

    private static String Task2_8() {
        try {
            String oldResult = list2.display();
            list2.removeFirst();
            return String.format("Изначальный список: %s \nУдаление первого элемента\nНовый список: %s", oldResult, list2.display());
        } catch (Exception e) {
            return "Ошибка: " + e;
        }
    }

    private static String Task2_9() {
        try {
            String oldResult = list2.display();
            list2.removeLast();
            return String.format("Изначальный список: %s \nУдаление последнего элемента\nНовый список: %s", oldResult, list2.display());
        } catch (Exception e) {
            return "Ошибка: " + e;
        }
    }

    private static String Task2_10(String input) {
        try {
            int num = Integer.parseInt(input);
            return String.format("Список: %s \nПринадлежность элемента %s к списку - %s", list2.display(), num, list2.contains(num));
        } catch (Exception e) {
            return "Ошибка: " + e;
        }
    }

    private static String Task2_11() {
        return String.format("Список %s\nНаибольшее значение - %s\nНаименьшее значение - %s", list2.display(), list2.findMax(), list2.findMin());
    }

    private static String Task2_12(String input) {
        try {
            String oldResult = list2.display();
            int num = Integer.parseInt(input);
            list2.remove(num);
            return String.format("Исходный список %s\nУдаление элемента со значением %s\nНовый список %s", oldResult, num, list2.display());
        } catch (NumberFormatException e) {
            throw new RuntimeException(e);
        }
    }

    private static String Task2_13(String input) {
        try {
            String oldResult = list2.display();
            int num = Integer.parseInt(input);
            list2.removeAll(num);
            return String.format("Исходный список %s\nУдаление всех элементов со значением %s\nНовый список %s", oldResult, num, list2.display());
        } catch (NumberFormatException e) {
            throw new RuntimeException(e);
        }
    }

    private static String Task2_14(String input) {
        try {
            String oldResult = list2.display();
            String[] srt = input.split(" ");
            int num1 = Integer.parseInt(srt[0]);
            int num2 = Integer.parseInt(srt[1]);
            list2.replace(num1, num2);
            return String.format("Список: %s\nЗамена элемента %s на %s\nНовый список: %s", oldResult, num1, num2, list2.display());

        } catch (NumberFormatException e) {
            throw new RuntimeException(e);
        }
    }

    private static String Task2_15() {
        return "Симметричность списка " + list2.display() + " - " + list2.isSymmetric();
    }

    private static String Task2_16() {
        return "Результат проверки списка " + list2.display() + " - " + list2.canRemoveTwoElementsToMakeSorted();
    }

    private static String Task2_17() {
        return "Различных значений содержится в списке: " + list2.countUniqueValues();
    }

    private static String Task2_18() {
        String oldResult = list2.display();
        list2.removeDuplicates();
        return "Старый список " + oldResult + "\nНовый список " + list2.display();
    }

    private static String Task2_19() {
        String oldResult = list2.display();
        list2.reverse();
        return "Старый список " + oldResult + "\nНовый список " + list2.display();
    }

    private static String Task2_20() {
        DoublyLinkedList list2_2 = new DoublyLinkedList();
        list2_2.clone(list2);
        String oldResult = list2.display();
        list2.sortLinkedListByPointers();
        list2_2.sortLinkedListByValues();
        return "Исходный список: " + oldResult + "\nСортировка путем изменения указателей: " + list2.display() + "\n// Сортировка путем изменения значений элементов " + list2_2.display();
    }


    private static String Task3(String input) {
        if (input != null) {
            books.add(new Book(input));
        }

        StringBuilder result = new StringBuilder();
        for (Book element : books) {
            result.append(element.title()).append("\n");
        }

        return result.toString();
    }

    private static String Task4(String input) {
        try {
            // [1, 3, 5, 7] [2, 4, 6, 8, 11]
            var it = Arrays.stream(input.split("]\\s+\\[")).iterator();
            var firstList = ListMerger.parser(it.next());
            var secondList = ListMerger.parser(it.next());

            return String.format("Результат слияния: %s", ListMerger.mergeSortedLists(firstList, secondList));

        } catch (NoSuchElementException e) {
            return "Вы ввели неправильные данные";
        }
    }

    private static String Task5(String input) {
        var linkedList = ListMerger.parser(input.substring(input.indexOf("[")));

        if (input.startsWith("положительные числа")) {

            linkedList.sort((o1, o2) -> {
                if (o1 > 0 && o2 > 0)
                    return o1.compareTo(o2);

                if (o1 > 0)
                    return -1;

                if (o2 > 0)
                    return 1;

                return 0;
            });

            return "Результат сортировки: " + linkedList;


        } else {

            var sortedEvenIndex = IntStream.range(0, linkedList.size())
                    .filter(i -> i % 2 == 0)
                    .mapToObj(linkedList::get)
                    .sorted()
                    .iterator();

            return "После сортировки: " + IntStream.range(0, linkedList.size())
                    .mapToObj(index -> {
                        if (index % 2 == 0) {
                            return sortedEvenIndex.next();
                        }
                        return linkedList.get(index);
                    }).toList();

        }
    }

    private static String Task6(String input) {
        try {
            var it = Arrays.stream(input.split("]\\s+\\[")).iterator();
            var firstList = new HashSet<>(ListMerger.parser(it.next()));
            var secondList = new HashSet<>(ListMerger.parser(it.next()));

            return firstList.equals(secondList) ? "Множества элементов совпадают" : "Множества элементов не совпадают";

        } catch (NoSuchElementException e) {
            return "Вы ввели неправильные данные";
        }
    }

    private static String Task7(String input) {
        var past = new StringBuilder();
        var list = new ArrayList<>(List.of(input.split("\\s+")));

        return list.stream().map(x -> {
            var result = past + x;
            past.append(x);
            return result;
        }).collect(Collectors.joining(" "));
    }

    private static String Task8() {
        ArrayList<Character> sentenceList = new ArrayList<>(Arrays.asList(
                'i', 't', 'm', 'a', 't', 'h', 'r', 'e', 'p', 'e', 't', 'i', 't', 'o', 'r',
                ' ', ' ', 'p', 'r', 'i', 'v', 'e', 't'
        ));

        var sentence = String.join("", sentenceList.stream().map(Object::toString).toArray(String[]::new));

        return sentence.replaceAll("itmathrepetitor", "silence");
    }

    private static String Task9() {
        LinkedList<Integer> charCountList = new LinkedList<>();

        try (BufferedReader reader = new BufferedReader(new FileReader("src/main/java/com/kikuzawa/kiku/texts/lab4Task9.txt"))) {
            String line;
            while ((line = reader.readLine()) != null) {
                charCountList.add(line.length());
            }
        } catch (IOException e) {
            e.printStackTrace();
        }

        StringBuilder result = new StringBuilder("Количество символов в каждой строке:\n");
        for (Integer count : charCountList) {
            result.append(count).append(" ");
        }

        return result.toString();
    }

    private static String Task10() {
        LinkedList<Group> facultyGroups = new LinkedList<>();

        Group group1 = new Group("ВКБ21");
        group1.addStudent(new Student("Котелевец Кирилл"));
        group1.addStudent(new Student("Заболотный Иван"));

        Group group2 = new Group("ВКБ22");
        group2.addStudent(new Student("Ковалев Данил"));
        group2.addStudent(new Student("Карпов Роман"));

        facultyGroups.add(group1);
        facultyGroups.add(group2);

        StringBuilder result = new StringBuilder("Группы факультета:\n");
        for (Group group : facultyGroups) {
            result.append(group).append("\n");
        }
        return result.toString();
    }

    private static String Task11(String input) {

        String[] words = input.split(";");
        List<Integer> grades = new ArrayList<>();
        String[] graddes = words[6].split(" ");
        for (String i : graddes) {
            grades.add(Integer.parseInt(i));
        }

        students.add(new Student1(words[0], words[1], words[2], Integer.parseInt(words[3]), Integer.parseInt(words[4]), words[5], grades));


        // Сортировка студентов по курсу и алфавиту
        students.sort(Comparator.comparingInt(Student1::getCourse).thenComparing(Student1::toString));

        // Нахождение среднего балла каждой группы по каждому предмету
        Map<String, Map<String, Double>> groupAverageGrades = new HashMap<>();
        for (Student1 student : students) {
            if (!groupAverageGrades.containsKey(student.groupNumber)) {
                groupAverageGrades.put(student.groupNumber, new HashMap<>());
            }
            for (int i = 0; i < student.grades.size(); i++) {
                String subject = "Предмет " + (i + 1);
                double averageGrade = groupAverageGrades.get(student.groupNumber).getOrDefault(subject, 0.0);
                averageGrade = (averageGrade * students.size() + student.grades.get(i)) / (students.size() + 1);
                groupAverageGrades.get(student.groupNumber).put(subject, averageGrade);
            }
        }

        // Нахождение самого старшего и младшего студентов
        Student1 oldestStudent = students.stream().min(Comparator.comparingInt(Student1::getBirthYear)).orElse(null);
        Student1 youngestStudent = students.stream().max(Comparator.comparingInt(Student1::getBirthYear)).orElse(null);

        // Нахождение лучшего студента в каждой группе
        Map<String, Student1> bestStudentsByGroup = new HashMap<>();
        for (Student1 student : students) {
            if (!bestStudentsByGroup.containsKey(student.groupNumber) ||
                    student.getAverageGrade() > bestStudentsByGroup.get(student.groupNumber).getAverageGrade()) {
                bestStudentsByGroup.put(student.groupNumber, student);
            }
        }

        StringBuilder result = new StringBuilder();
        result.append("Средняя успеваемость по группе:\n");
        for (Map.Entry<String, Map<String, Double>> entry : groupAverageGrades.entrySet()) {
            result.append("Группа: ").append(entry.getKey()).append("\n");
            for (Map.Entry<String, Double> gradeEntry : entry.getValue().entrySet()) {
                result.append(gradeEntry.getKey()).append(": ").append(gradeEntry.getValue()).append("\n");
            }
        }

        result.append("Старший студент: ").append(oldestStudent).append("\n");
        result.append("Молодой студент: ").append(youngestStudent).append("\n");

        result.append("Лучшие студенты по группе:\n");
        for (Map.Entry<String, Student1> entry : bestStudentsByGroup.entrySet()) {
            result.append("Группа: ").append(entry.getKey()).append(", Лучший студент: ").append(entry.getValue()).append("\n");
        }
        return result.toString();
    }
}
