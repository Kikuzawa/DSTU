/**
 * Класс TaskExecutorLabThree выполняет различные задачи из лабораторной 3 над строками на Java.
 * Задачи включают поиск самых длинных и коротких строк, сортировку по длине,
 * работу со словами и символами и другие операции.
 */
package com.kikuzawa.laboratoriesjava.Labs;

import java.util.Arrays;
import java.util.regex.Matcher;
import java.util.regex.Pattern;
import java.util.List;

import static com.kikuzawa.laboratoriesjava.classes.HelpModule.*;

public class TaskExecutorLabThree {

    private static String Task1(String input) {
        String[] strings = input.split(" ");
        String result = "";
        result += "Самая длинная строка: " + max(strings) + "\n" + "Ее длина:" + max(strings).length();
        result += "\nСамая короткая строка: " + min(strings) + "\n" + "Ее длина:" + min(strings).length();

        return result;
    }

    private static String Task2(String input) {
        String[] strings = input.split(" ");
        String result = "";

        result += "Исходный список:\n" + String.join("\n", strings) + "\n";
        result += "По возрастанию:\n" + String.join("\n", sortByLength(Arrays.asList(strings))) + "\n";
        result += "По убыванию:\n" + String.join("\n", sortByLengthAnti(Arrays.asList(strings)));

        return result;
    }

    private static String Task3(String input) {
        String[] strings = input.split(" ");
        StringBuilder result;
        double average = AverageLength(Arrays.asList(strings));

        result = new StringBuilder("Исходный список:\n" + String.join("\n", strings) + "\n Больше среднего:\n");
        for (String word : filtStringsUpNumber(strings, average)) {
            result.append(word).append(word.length()).append("\n");
        }
        result.append("Меньше среднего:\n");
        for (String word : filtStringsDownNumber(strings, average)) {
            result.append(word).append(word.length()).append("\n");
        }
        return result.toString();
    }

    private static String Task4(String input) {
        String[] words = input.split(" ");

        return findWordWithMinDistinctChars(words);
    }

    private static String Task5(String input) {
        String[] words = input.split(" ");

        String result = "";

        int numLatinWords = countLatinWords(words);
        int numLatinWordsWithEqualVowelsAndConsonants = countLatinWordsWithEqualVowelsAndConsonants(words);

        result += "Количество слов, содержащих только символы латинского алфавита: " + numLatinWords + "\n";
        result += "Количество слов с равным числом гласных и согласных букв: " + numLatinWordsWithEqualVowelsAndConsonants;

        return result;
    }

    private static String Task6(String input) {
        String[] words = input.split(" ");

        String ascendingWord = findAscendingWord(words);

        // Выведите результат
        if (ascendingWord != null) {
            return String.format("Слово с символами в строгом порядке возрастания их кодов: " + ascendingWord);
        } else {
            return "Таких слов нет.";
        }
    }

    private static String Task7(String input) {
        String[] words = input.split(" ");
        String uniqueWord = findUniqueWord(words);

        if (uniqueWord != null) {
            return String.format("Слово, состоящее только из различных символов: " + uniqueWord);
        } else {
            return "Таких слов нет.";
        }
    }

    private static String Task8(String input) {
        String[] words = input.split(" ");

        // Проверьте, все ли слова состоят из цифр
        boolean allDigits = true;
        for (String word : words) {
            if (!word.matches("[0-9]+")) {
                allDigits = false;
                break;
            }
        }

        String DigitPalindrome = null;
        if (allDigits) {
            DigitPalindrome = findSecondDigitPalindrome(words);
        }


        if (DigitPalindrome != null) {
            return String.format("Слово-палиндром, состоящее только из цифр: " + DigitPalindrome);
        } else if (!allDigits) {
            return "Есть слова, состоящие не только из цифр!";
        } else {
            return "Таких слов нет!";
        }
    }

    private static String Task10(String input) {
        String result = "a) " + input + "\n";

        int lastIndex = input.length() - 1;
        char lastChar = input.charAt(lastIndex);

        result += "б) " + lastChar + "\n";

        boolean endsWith = input.endsWith("!!!");
        result += "в) " + endsWith + "\n";

        boolean startsWith = input.startsWith("I like");
        result += "г) " + startsWith + "\n";

        boolean contains = input.contains("Java");
        result += "д) " + contains + "\n";

        int index = input.indexOf("Java");
        result += "е) " + index + "\n";

        String newStr = input.replace('a', 'o');
        result += "ж) " + newStr + "\n";

        String upperCase = input.toUpperCase();
        result += "з) " + upperCase + "\n";

        String lowerCase = input.toLowerCase();
        result += "и) " + lowerCase + "\n";

        String substring = input.substring(7, 11); // вырезает подстроку с индексов 7 по 10 (не включая 11)
        result += "к) " + substring + "\n";

        return result;

    }

    private static String Task11(String input) {
        String[] nums = input.split(" ");
        boolean flag = true;

        for (String num : nums) {
            if (!num.matches("[0-9]+")) {
                flag = false;
                break;
            }
        }

        if (nums.length != 2) {
            flag = false;
        }


        if (flag) {
            String result = "";
            StringBuilder sb = new StringBuilder();
            int num1 = Integer.parseInt(nums[0]);
            int num2 = Integer.parseInt(nums[1]);

            sb.append(num1).append(" + ").append(num2).append(" = ").append(num1 + num2).append("\n");
            sb.append(num1).append(" - ").append(num2).append(" = ").append(num1 - num2).append("\n");
            sb.append(num1).append(" * ").append(num2).append(" = ").append(num1 * num2);

            result += "а)\n" + sb + "\n";


            int index = sb.indexOf("=");
            while (index != -1) {
                sb.deleteCharAt(index);
                sb.insert(index, "равно");
                index = sb.indexOf("=", index + 1);
            }

            result += "б)\n" + sb + "\n";

            //sb.replace(sb.indexOf("="), sb.indexOf("=") + 1, "равно");

            result += "в)\n" + sb + "\n";

            return result;

        } else {
            return "Неправильный ввод!";
        }
    }

    private static String Task12(String input) {
        String target = "Object-oriented programming";
        String replacement = "OOP";
        return replaceEverySecondOccurrence(input, target, replacement);
    }

    private static String Task13(String input) {
        String[] strings = input.split(" ");
        StringBuilder result1 = new StringBuilder();
        StringBuilder result2 = new StringBuilder();
        for (String str : strings) {
            if (checkWordLength(str)) {
                String result = getMiddleCharacters(str);
                result1.append("Слово \"").append(str).append("\" прошло проверку на длину. Результат: ").append(result).append("\n");
            } else {
                result2.append("Слово \"").append(str).append("\" не прошло проверку на длину.\n");
            }
        }

        return result1 + "------------\n" + result2;
    }

    private static String Task14(String input) {
        String[] words = input.split(" ");

        try {
            if (words.length != 3) {
                return "Неправильный ввод!";
            } else {
                String name = words[0];
                int grade = Integer.parseInt(words[1]);
                String subject = words[2];

                return String.format("Студент %15s получил %3d по %10s\n", name, grade, subject);
            }
        } catch (Exception e) {
            return "Ошибка: " + e;
        }
    }

    private static String Task15(String input) {

        Pattern pattern = Pattern.compile("Java\\s+[0-9]+");
        StringBuilder result = new StringBuilder();

        // Создание объекта Matcher для поиска совпадений в строке input
        Matcher matcher = pattern.matcher(input);

        // Поиск всех совпадений и печать найденных подстрок
        while (matcher.find()) {
            result.append(matcher.group()).append("\n");
        }

        return result.toString();
    }

    private static String Task16(String input) {
        String[] words = input.split(" ");


        String minUniqueWord = "";
        int minUniqueChars = Integer.MAX_VALUE;

        for (String word : words) {
            int uniqueChars = countUniqueCharacters(word);
            if (uniqueChars < minUniqueChars) {
                minUniqueChars = uniqueChars;
                minUniqueWord = word;
            }
        }

        return "Слово с минимальным числом различных символов: " + minUniqueWord;
    }

    private static String Task17(String input) {
        String[] words = input.split(" ");

        String result = Integer.toString(countLatinWords(words));

        return "Количество таких слов: " + result;
    }

    private static String Task18(String input){
        List<String> words = Arrays.asList(input.split(" "));

        List<String> numericWords = words.stream()
                .filter(word -> word.matches("[0-9]+"))
                .toList();

        // Найти все палиндромы
        List<String> palindromes = numericWords.stream()
                .filter(word -> word.contentEquals(new StringBuilder(word).reverse()))
                .toList();


        // Вывести результат
        return String.valueOf(palindromes);

    }

    public static String execute(String input, int task) {
        return switch (task) {
            case 1 -> Task1(input);
            case 2 -> Task2(input);
            case 3 -> Task3(input);
            case 4 -> Task4(input);
            case 5 -> Task5(input);
            case 6 -> Task6(input);
            case 7 -> Task7(input);
            case 8 -> Task8(input);
            case 10 -> Task10(input);
            case 11 -> Task11(input);
            case 12 -> Task12(input);
            case 13 -> Task13(input);
            case 14 -> Task14(input);
            case 15 -> Task15(input);
            case 16 -> Task16(input);
            case 17 -> Task17(input);
            case 18 -> Task18(input);
            default -> "Пока не реализовано";
        };
    }
}
