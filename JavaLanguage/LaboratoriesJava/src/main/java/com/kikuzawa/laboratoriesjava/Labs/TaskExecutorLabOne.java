
/*
Этот файл содержит класс TaskExecutorLabOne, который выполняет различные задачи из лабораторной работы 1,
такие как вычисления математических формул, сортировку массивов, работу с числами и строками,
а также другие операции. Каждый метод класса выполняет определенную задачу,
используя различные математические и логические операции.
 */

package com.kikuzawa.laboratoriesjava.Labs;

import java.util.Arrays;
import java.util.concurrent.ThreadLocalRandom;

import static com.kikuzawa.laboratoriesjava.classes.HelpModule.*;
import static java.lang.Integer.parseInt;
@SuppressWarnings("ALL")
public class TaskExecutorLabOne {
    private static String Task1() {
        double z;
        int[] x = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 20};
        int[] y = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 15};
        int max_x, max_y;
        max_x = max(x);
        max_y = max(y);
        z = (Math.exp(Math.abs(max_x)) - Math.exp(Math.abs(max_y))) / Math.sqrt((Math.abs(max_x * max_y)));
        return Double.toString(z);
    }
    @SuppressWarnings("ConstantConditions")
    private static String Task2() {
        int[] a = {1, -2, 3, 4, -5, 6, 7, 8, 9, -10, 20};
        int[] b = {1, 2, 3, 4, -5, -6, 7, -8, 9, 10, 15};
        int[] c = {1, 2, 3, -4, 5, 6, 7, -8, 9, 10, -30};
        int s = sumPositive(a);
        int t = sumPositive(b);
        int k = sumPositive(c);
        float m = (float) (s + t + k) / 2;

        return Float.toString(m);
    }

    private static String Task3() {
        int m = 4, n = 3;
        long c = factorial(m) / (factorial(n) * factorial(m - n));
        return Long.toString(c);
    }

    private static String Task4() {
        int x = 2, y = 3, z = 4;
        double s;
        s = powSqrt(x, y) + powSqrt(x, z) + powSqrt(y, z);
        return Double.toString(s);
    }

    private static String Task5() {
        int[] x = {1, -2, 3, 4, -5, 6, 7, 8, 9, -10, 20};
        int[] y = {1, 2, 3, 4, -5, -6, 7, -8, 9, 10, 15};
        int[] z = {1, 2, 3, -4, 5, 6, 7, -8, 9, 10, -30};
        String s;
        s = "Среднее арифметическое положительного массива x = " + String.format("%.4f", ((double) (sumPositive(x)) / x.length)) + "\n";
        s += "Среднее арифметическое положительного массива y = " + String.format("%.4f", ((double) (sumPositive(y)) / y.length)) + "\n";
        s += "Среднее арифметическое положительного массива z = " + String.format("%.4f", ((double) (sumPositive(z)) / z.length)) + "\n";
        return s;
    }

    private static String Task6() {
        int[] a = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 15};
        int[] b = {1, 2, 3, 4, -5, -6, 7, 8, 9, 10, -12};
        int[] c = {1, 2, 3, -4, 5, 6, 7, -8, 9, 10, 30, 12};
        int l;
        if (min(a) > 10) l = min(b) + min(c);
        else l = 1 + min(c);
        return Integer.toString(l);
    }

    private static String Task7() {
        double[] D = new double[40];
        int len = D.length;
        for (int i = 0; i < len; i++) D[i] = ThreadLocalRandom.current().nextDouble(20.0);
        Arrays.parallelSort(D);
        int lens = countRange(D, len, 0, 12);
        return Double.toString(meanGeometric(D, lens));
    }

    private static String Task8() {
        int[] D = new int[10];
        int len = D.length, sum = 0;
        for (int i = 0; i < len; i++) D[i] = ThreadLocalRandom.current().nextInt(-10, 10);
        Arrays.parallelSort(D);
        int posix = searchNegativeOdd(D, len);
        for (int i = 0; i < posix; i++) if ((D[i] & 1) != 0) sum += D[i];
        return Integer.toString(sum);
    }

    public static String Task9() {
        int[] arr = new int[10];
        int len = arr.length;
        for (int i = 0; i < len; i++) arr[i] = ThreadLocalRandom.current().nextInt(100);
        return Double.toString(meanArithmetic(arr, len));
    }

    private static String Task10() {
        Integer[] arr = new Integer[10];
        int len = arr.length;
        StringBuilder result = new StringBuilder();
        for (int i = 0; i < len; i++) arr[i] = ThreadLocalRandom.current().nextInt(0, 100);
        Arrays.sort(arr, (Integer x, Integer y) -> {
            int tempx = x, tempy = y;
            int sumx = 0, sumy = 0;
            while (tempx != 0) {
                sumx += tempx % 10;
                tempx /= 10;
            }
            while (tempy != 0) {
                sumy += tempy % 10;
                tempy /= 10;
            }
            return sumx - sumy;
        });
        for (int i : arr) result.append(i).append(" ");
        return result.toString();

    }

    private static String Task11() {
        StringBuilder result = new StringBuilder();
        Integer[] arr = new Integer[10];
        int len = arr.length;
        for (int i = 0; i < len; i++) arr[i] = ThreadLocalRandom.current().nextInt(0, 100);
        result.append("\n");
        for (int i : arr) result.append(String.format("%4s", i + " "));
        Arrays.sort(arr, (Integer x, Integer y) -> {
            int tempx = x, tempy = y;
            int sumx = 0, sumy = 0;
            while (tempx != 0) {
                sumx += tempx % 10;
                tempx /= 10;
            }
            while (tempy != 0) {
                sumy += tempy % 10;
                tempy /= 10;
            }
            return sumx - sumy;
        });
        System.out.println();
        for (int i : arr) result.append(String.format("%4s", i + " "));
        System.out.println();
        for (int i : arr) result.append(String.format("%4s", summDigit(i) + " "));

        return result.toString();
    }

    private static String Task12(String input) {
        int number;
        try {
            number = parseInt(input);
            return Integer.toString(analyzeRaz(number));
        } catch (Exception e) {
            return String.format(String.valueOf(e));
        }


    }

    private static String Task13(String input) {
        int x;
        int s = 0;
        try {
            x = parseInt(input);
            for (int i = 0; i < 5; i++) {
                s += (int) ((-1) * i * (x / factorial(i)));
            }
            return Integer.toString(s);
        } catch (Exception e) {
            return String.format(String.valueOf(e));
        }
    }

    private static String Task14(String input) {
        try {
            String[] src = input.split(" ");
            int len = src.length;
            String temp;
            for (int i = 0; i <= (len / 2); i++) {
                temp = src[len - i - 1];
                src[len - i - 1] = src[i];
                src[i] = temp;
            }
            return String.join(" ", src);
        } catch (Exception e) {
            return String.format(String.valueOf(e));
        }
    }

    private static String Task15(String input) {
        int[] arr = new int[10];
        int len = arr.length;
        for (int i = 0; i < len; i++) arr[i] = ThreadLocalRandom.current().nextInt(0, 15);
        StringBuilder result = new StringBuilder();
        for (int i : arr) result.append(String.format("%3s", i + " "));

        int digit_search = parseInt(input);
        Arrays.parallelSort(arr);
        int result1 = binSearch(arr, digit_search, 0, len - 1);
        result.append(result1 != -1 ? "\n" + result1 + "\n" : "\nНе найдено\n");
        for (int i : arr) result.append(String.format("%3s", i + " "));
        return result.toString();
    }

    private static String Task16(String input) {
        String[] nums = input.split(" ");
        int n1 = parseInt(nums[0]);
        int n2 = parseInt(nums[1]);
        return "НОД: " + algorithmStein(n1, n2);
    }

    private static String Task17(String input) {
        try {
            String[] args = input.split(" ");
            int param = parseInt(args[0]);
            String result;
            switch (param) {
                case 1 -> result = circle(Double.parseDouble(args[1]));
                case 2 -> result = rect(parseInt(args[1]), parseInt(args[2]));
                case 3 -> result = triangle(parseInt(args[1]), parseInt(args[2]));
                case 4 -> result = triangle(parseInt(args[1]), parseInt(args[2]), parseInt(args[3]));
                default -> result = "Неправильно введен режим";
            }
            return result;
        } catch (Exception e) {
            return "Ошибка: " + e;
        }
    }

    private static String Task18() {
        int len = 5;
        StringBuilder result = new StringBuilder();
        int[][] arr = new int[len][len];
        for (int i = 0; i < len; i++) {
            for (int j = 0; j < len; j++) arr[i][j] = ThreadLocalRandom.current().nextInt(0, 10);
        }
        int[] sum = new int[len];
        for (int i = 0; i < len; i++) sum[i] = sumArray(arr[i]);
        for (int i = 0; i < len; i++) {
            for (int j = 0; j < len; j++) {
                result.append(String.format("%4d", arr[i][j]));
            }
            result.append(String.format("%.4s", "| " + sum[i]));
            result.append("\n");
        }
        result.append("--------------------------------------------\n");
        int max_sum = searchIndexLargest(sum);
        for (int i = 0; i < len; i++) result.append(String.format("%4d", arr[max_sum][i]));
        result.append(String.format("%.4s", "| " + sum[max_sum]));
        return result.toString();
    }

    private static String Task19(String input) {
        int len = 4;
        int[][] arr = new int[len][len];
        for (int i = 0; i < len; i++) {
            for (int j = 0; j < len; j++) arr[i][j] = ThreadLocalRandom.current().nextInt(0, 15);
        }
        String result = viewArr(arr, len);
        int param = Integer.parseInt(input);
        switch (param) {
            case 1 -> result += diagonalSums(arr, len, true);
            case 2 -> result += diagonalSums(arr, len, false);
            default -> {
                return "Не верные данные";
            }
        }
        return result;
    }

    private static String Task20(String input) {
        return decBinary(Integer.parseInt(input)).toString();
    }

    private static String Task21(String input) {
        int x = Integer.parseInt(input), y;
        if (x <= 5) {
            if (x >= -5) y = pow(x);
            else y = 2 * Math.abs(x) - 1;
        } else y = 2 * x;
        return "y(" + input + "): " + y;
    }

    private static String Task22(String input) {
        String[] nums = input.split(" ");
        int min = Integer.parseInt(nums[0]);
        int max = Integer.parseInt(nums[1]);
        int len = 10;
        StringBuilder result = new StringBuilder();
        int[] arr = new int[len];
        for (int i = 0; i < len; i++) arr[i] = ThreadLocalRandom.current().nextInt(min, max);
        for (int i = 0; i < len; i++) result.append(String.format("%.4s", arr[i] + " "));
        return result.toString();
    }

    private static String Task23(String input) {
        String[] nums = input.split(" ");
        double R = Double.parseDouble(nums[0]);
        double U = Double.parseDouble(nums[1]);
        double I = U / R;
        return Double.toString(I);
    }

    private static String Task24(String input) {
        String[] nums = input.split(" ");
        double I = Double.parseDouble(nums[0]);
        double[] R = new double[3], U = new double[3];
        for (int i = 0; i < 3; i++) {
            R[i] = Double.parseDouble(nums[i + 1]);
            U[i] = I * R[i];
        }
        StringBuilder result = new StringBuilder();
        for (int i = 0; i < 3; i++) result.append(String.format("%.6s", U[i] + " "));
        return result.toString();
    }

    private static String Task25(String input) {
        int day = Integer.parseInt(input);
        return (switch (day) {
            case 1 -> "Понедельник";
            case 2 -> "Вторник";
            case 3 -> "Среда";
            case 4 -> "Четверг";
            case 5 -> "Пятница";
            case 6 -> "Суббота";
            case 7 -> "Воскресенье";
            default -> "Покиньте планету";
        });
    }

    public static String execute(String input, int task) {
        return switch (task) {
            case 1 -> Task1();
            case 2 -> Task2();
            case 3 -> Task3();
            case 4 -> Task4();
            case 5 -> Task5();
            case 6 -> Task6();
            case 7 -> Task7();
            case 8 -> Task8();
            case 9 -> Task9();
            case 10 -> Task10();
            case 11 -> Task11();
            case 12 -> Task12(input);
            case 13 -> Task13(input);
            case 14 -> Task14(input);
            case 15 -> Task15(input);
            case 16 -> Task16(input);
            case 17 -> Task17(input);
            case 18 -> Task18();
            case 19 -> Task19(input);
            case 20 -> Task20(input);
            case 21 -> Task21(input);
            case 22 -> Task22(input);
            case 23 -> Task23(input);
            case 24 -> Task24(input);
            case 25 -> Task25(input);
            default -> "Пока не реализовано";
        };
    }
}