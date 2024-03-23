/**
 * Код в файле HelpModule.java представляет собой набор статических методов для работы с массивами,
 * строками и различными математическими операциями.
 * Включает функции по поиску максимального и минимального элементов в массиве,
 * вычислению суммы положительных чисел, факториала числа, возведения в степень,
 * поиску индексов элементов в массиве, вычислению среднего геометрического и арифметического,
 * сортировке строк по длине, обработке строк и другие.
 */
package com.kikuzawa.laboratoriesjava.classes;

import java.util.*;

public class HelpModule {
    public static int max(int[] array) {
        int max_arr = array[0];
        for (int i : array) if (i > max_arr) max_arr = i;
        return max_arr;
    }

    public static String max(String[] array) {
        String max_arr = array[0];
        for (String i : array) if (i.length() > max_arr.length()) max_arr = i;
        return max_arr;
    }


    public static int min(int[] array) {
        int min_arr = array[0];
        for (int i : array) if (i < min_arr) min_arr = i;
        return min_arr;
    }

    public static String min(String[] array) {
        String min_arr = array[0];
        for (String i : array) if (i.length() < min_arr.length()) min_arr = i;
        return min_arr;
    }

    public static int sumPositive(int[] array) {
        int sum = 0;
        for (int i : array) if (i > 0) sum += i;
        return sum;
    }

    public static long factorial(int k) {
        long result = 1L;
        for (int i = 1; i <= k; i++) result *= i;
        return result;
    }

    public static int pow(int value) {
        return value * value;
    }

    public static double powSqrt(int a, int b) {
        return Math.sqrt(pow(a) + pow(b) + Math.pow(Math.sin(a * b), 2));
    }

    public static int lowerIndex(double[] arr, int len, int x) {
        int l = 0, mid;
        len--;
        while (l <= len) {
            mid = (l + len) / 2;
            if (arr[mid] > x) len = mid - 1;
            else l = mid + 1;
        }
        return l;
    }

    public static int upperIndex(double[] arr, int len, int y) {
        int l = 0, mid;
        len--;
        while (l <= len) {
            mid = (l + len) / 2;
            if (arr[mid] < y) l = mid + 1;
            else len = mid - 1;
        }
        return l;
    }

    public static int countRange(double[] arr, int len, int x, int y) {
        return upperIndex(arr, len, y) - lowerIndex(arr, len, x);
    }

    public static double meanGeometric(double[] arr, int len) {
        double sum = 0;
        for (int i = 0; i < len; i++)
            sum += Math.log(arr[i]);
        sum /= len;
        return Math.exp(sum);
    }

    public static int searchNegativeOdd(int[] arr, int len) {
        int l = 0, mid;
        len--;
        while (l <= len) {
            mid = (l + len) / 2;
            if (arr[mid] < 0) l = mid + 1;
            else len = mid - 1;
        }
        return l;
    }

    public static double meanArithmetic(int[] arr, int len) {
        int result = 0;
        for (int i : arr) result += i;
        return (double) result / len;
    }

    public static double AverageLength(List<String> strings) {
        int totalLength = 0;
        for (String str : strings) {
            totalLength += str.length();
        }
        return (double) totalLength / strings.size();
    }

    public static String[] filtStringsUpNumber(String[] strings, double number) {
        String[] filteredArray = new String[strings.length];
        int count = 0;

        for (String element : strings) {
            if (element.length() > number) {
                filteredArray[count] = element;
                count++;
            }
        }

        return Arrays.copyOf(filteredArray, count);
    }

    public static String[] filtStringsDownNumber(String[] strings, double number) {
        String[] filteredArray = new String[strings.length];
        int count = 0;

        for (String element : strings) {
            if (element.length() < number) {
                filteredArray[count] = element;
                count++;
            }
        }

        return Arrays.copyOf(filteredArray, count);
    }

    public static int summDigit(int temp) {
        int sum = 0;
        while (temp != 0) {
            sum += temp % 10;
            temp /= 10;
        }
        return sum;
    }

    public static List<String> sortByLength(List<String> strings) {
        strings.sort(Comparator.comparingInt(String::length));
        return strings;
    }

    public static List<String> sortByLengthAnti(List<String> strings) {
        strings.sort((s1, s2) -> Integer.compare(s2.length(), s1.length()));
        return strings;
    }

    // Функция для поиска слова с минимальным количеством уникальных символов
    public static String findWordWithMinDistinctChars(String[] words) {
        String minWord = "";
        int minNumDistinctChars = Integer.MAX_VALUE;
        for (String word : words) {
            int numDistinctChars = countDistinctCharacters(word);
            if (numDistinctChars < minNumDistinctChars) {
                minWord = word;
                minNumDistinctChars = numDistinctChars;
            }
        }
        return minWord;
    }

    // Функция для подсчета количества уникальных символов в строке
    public static int countDistinctCharacters(String str) {
        Set<Character> distinctCharacters = new HashSet<>();
        for (char c : str.toCharArray()) {
            distinctCharacters.add(c);
        }
        return distinctCharacters.size();
    }

    // Функция для подсчета количества слов, содержащих только символы латинского алфавита
    public static int countLatinWords(String[] words) {
        int count = 0;
        for (String word : words) {
            if (word.matches("[a-zA-Z]+")) {
                count++;
            }
        }
        return count;
    }

    // Функция для проверки, имеет ли слово равное число гласных и согласных букв
    public static boolean hasEqualVowelsAndConsonants(String word) {
        int countVowels = 0;
        int countConsonants = 0;

        for (char c : word.toCharArray()) {
            if (isVowel(c)) {
                countVowels++;
            } else {
                countConsonants++;
            }
        }

        return countVowels == countConsonants;
    }

    // Функция для проверки, является ли символ гласной буквой
    public static boolean isVowel(char c) {
        return "aeiouAEIOU".contains(String.valueOf(c));
    }

    // Функция для подсчета количества слов с равным числом гласных и согласных букв
    public static int countLatinWordsWithEqualVowelsAndConsonants(String[] words) {
        int count = 0;
        for (String word : words) {
            if (word.matches("[a-zA-Z]+") && hasEqualVowelsAndConsonants(word)) {
                count++;
            }
        }
        return count;
    }

    // Находит первое слово с символами в строгом порядке возрастания их кодов
    public static String findAscendingWord(String[] words) {
        for (String word : words) {
            if (isAscending(word)) {
                return word;
            }
        }
        return null;
    }

    // Проверяет, идут ли символы в слове в строгом порядке возрастания их кодов
    public static boolean isAscending(String word) {
        for (int i = 1; i < word.length(); i++) {
            if (word.charAt(i) < word.charAt(i - 1)) {
                return false;
            }
        }
        return true;
    }

    // Находит первое слово, состоящее только из различных символов
    public static String findUniqueWord(String[] words) {
        for (String word : words) {
            if (isUnique(word)) {
                return word;
            }
        }
        return null;
    }

    // Проверяет, состоит ли слово только из различных символов
    public static boolean isUnique(String word) {
        Set<Character> characters = new HashSet<>();
        for (char character : word.toCharArray()) {
            if (!characters.add(character)) {
                return false;
            }
        }
        return true;
    }

    // Находит второе слово-палиндром, состоящее только из цифр
    public static String findSecondDigitPalindrome(String[] words) {
        int count = 0;
        String firstPalindrome = null;
        String secondPalindrome = null;
        for (String word : words) {
            if (isDigitPalindrome(word)) {
                count++;
                if (count == 1) {
                    firstPalindrome = word;
                }
                if (count == 2) {
                    secondPalindrome = word;
                    break;
                }
            }
        }
        if (secondPalindrome == null) {
            return firstPalindrome;
        } else {
            return secondPalindrome;
        }
    }

    // Про
    // // Находит второе слово-палиндром, состоящее только из цифрверяет, является ли слово палиндромом, состоящим только из цифр
    public static boolean isDigitPalindrome(String word) {
        if (!word.matches("[0-9]+")) {
            return false;
        }
        int left = 0;
        int right = word.length() - 1;
        while (left < right) {
            if (word.charAt(left) != word.charAt(right)) {
                return false;
            }
            left++;
            right--;
        }
        return true;
    }

    public static String replaceEverySecondOccurrence(String str, String target, String replacement) {
        int index = str.indexOf(target);
        int count = 0;

        while (index != -1) {
            if (count % 2 == 1) {
                str = str.substring(0, index) + replacement + str.substring(index + target.length());
            }
            index = str.indexOf(target, index + replacement.length());
            count++;
        }

        return str;
    }

    public static boolean checkWordLength(String str) {
        int length = str.length();
        return length % 2 == 0;
    }

    public static String rect(int a, int b) {
        return "Площадь прямоугольника: " + a * b;

    }

    public static String triangle(int h, int a){
        return Double.toString((h * a) / 2.0);
    }

    public static String triangle(int a, int b, int c){
        if (a < 0 || b < 0 || c < 0 || (a + b <= c) || a + c <= b || b + c <= a){
            return "Не верные данные";
        }
        double P = (a + b + c) / 2.0;
        return Double.toString(Math.sqrt(P * (P - a) * (P - b) * (P - c)));
    }

    public static String circle(double radius){
        double S = radius * radius * Math.PI;
        return "Площадь круга: " + S;
    }

    public static int searchIndexLargest(int[] array){
        int index_largest = 0;
        for ( int i = 0; i < array.length; i++ ) {
            if ( array[i] > array[index_largest] ) {
                index_largest = i;
            }
        }
        return index_largest;
    }

    public static StringBuilder decBinary(int n) {
        StringBuilder result = new StringBuilder();
        for (int i = 31; i >= 0; i--) {
            int k = n >> i;
            if ((k & 1) > 0) result.append("1");
            else result.append("0");
        }
        return new StringBuilder(result.substring(result.indexOf("1"), 32));
    }



    public static String viewArr(int[][] arr, int len){
        StringBuilder result = new StringBuilder();
        for (int i =0; i < len; i++) {
            for (int j = 0; j < len; j++) {
                result.append(String.format("%4d", arr[i][j]));
            }
            result.append("\n");
        }
        return result.toString();
    }
    public static String diagonalSums(int [][]mat, int n, boolean f) {
        int principal = 0, secondary = 0;
        for (int i = 0; i < n; i++) {
            principal += mat[i][i];
            secondary += mat[i][n - i - 1];
        }
        return String.format((f) ? ("Главная диагональ:" + principal) : ("Побочная диагональ:" + secondary));
    }

    public static int sumArray(int[] array){
        int temp =0;
        for (int i:array) temp+=i;
        return temp;
    }

    public static int algorithmStein(int n1, int n2) {
        if (n1 == 0) return n2;
        if (n2 == 0) return n1;
        int n;
        for (n = 0; ((n1 | n2) & 1) == 0; n++) {
            n1 >>= 1;
            n2 >>= 1;
        }
        while ((n1 & 1) == 0) n1 >>= 1;
        do {
            while ((n2 & 1) == 0) n2 >>= 1;
            if (n1 > n2) {
                int temp = n1;
                n1 = n2;
                n2 = temp;
            }
            n2 = (n2 - n1);
        } while (n2 != 0);
        return n1 << n;
    }

    public static int binSearch(int[] sortedArray, int valueToFind, int low, int high){
        int index = -1;
        while (low <= high) {
            int mid = low + (high - low) / 2;
            if (sortedArray[mid] < valueToFind) {
                low = mid + 1;
            } else if (sortedArray[mid] > valueToFind) {
                high = mid - 1;
            } else if (sortedArray[mid] == valueToFind) {
                index = mid;
                break;
            }
        }
        return index;
    }

    public static String getMiddleCharacters(String str) {
        int middleIndex = str.length() / 2;
        return str.substring(middleIndex - 1, middleIndex + 1);
    }

    public static int countUniqueCharacters(String word) {
        int uniqueChars = 0;
        boolean[] visited = new boolean[256];

        for (char c : word.toCharArray()) {
            if (!visited[c]) {
                visited[c] = true;
                uniqueChars++;
            }
        }

        return uniqueChars;
    }

    public static int analyzeRaz(int number) {
        if (number < 100000) {
            if (number < 100) {
                if (number < 10) {
                    return 1;
                } else {
                    return 2;
                }
            } else {
                if (number < 1000) {
                    return 3;
                } else {
                    if (number < 10000) {
                        return 4;
                    } else {
                        return 5;
                    }
                }
            }
        } else {
            if (number < 10000000) {
                if (number < 1000000) {
                    return 6;
                } else {
                    return 7;
                }
            } else {
                if (number < 100000000) {
                    return 8;
                } else {
                    if (number < 1000000000) {
                        return 9;
                    } else {
                        return 10;
                    }
                }
            }
        }
    }
}
