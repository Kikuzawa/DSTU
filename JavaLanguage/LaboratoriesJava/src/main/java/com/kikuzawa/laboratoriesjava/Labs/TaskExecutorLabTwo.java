/*
 * Класс TaskExecutorLabTwo содержит методы для выполнения различных задач из лабораторной работы No2.
 * В основном это обычный вывод текста в поле.
 */
package com.kikuzawa.laboratoriesjava.Labs;

public class TaskExecutorLabTwo {
    private static String Task1() {
        return """
                public class Lab2Task1 {
                    public static void main(String[] args) {
                        int a = 15;
                        int b = 4;
                        float c = (float) a / b;
                        double d = a * 1e-3 + c;
                        System.out.println(d);
                    }
                }""";
    }

    private static String Task2() {
        return """
                public class Lab2Task2 {
                    public static void main(String[] args) {
                        float f = (float) 128.50;
                        int i = (int) f;
                        int b = (byte) (int) (i + f);
                        System.out.println(b);
                    }
                }""";
    }

    private static String Task3() {
       return """
               public static void main(String[] args) {
                       short number = 9;
                       char zero = '0';
                       int nine = (Character.getNumericValue(zero) + number);
                       System.out.println(nine);
                   }""";
    }

    private static String Task6() {
        return """
                public class Lab2Task4 {
                    public static void main(String[] args) {
                        double d = (short) 2.50256e2d;
                        char c = 'd';
                        short s = (short) 2.22;
                        int i = 150000;
                        float f = 0.50f;
                        double result = f + (i / c) - (d * s) - 500e-3;
                        System.out.println("result: " + result);
                    }
                }""";
    }

    private static String Task4() {
        return """
                public class Lab2Task5 {
                    public static void main(String[] args) {
                        long l =  1234_564_890L;
                        int x =  0b1000_1100_1010; //бинарность
                        double m =  (byte) 110_987_654_6299.123_34;
                        float f =  l++ + 10 + ++x - (float) m;
                        l = (long) f / 1000;
                        System.out.println(l);
                    }
                }
                """;
    }

    private static String Task5() {
        return """
                public class Lab2Task6 {
                    public static void main(String[] args) {
                        int a = 50;
                        int b = 17;
                        double d = (double) a / b;
                        System.out.println(d);
                    }
                }
                """;
    }

    private static String Task7() {
        return """
                public class Lab2Task7 {
                    public static void main(String[] args) {
                        int a = 257;
                        int b = 4;
                        int c = 3;
                        int e = 2;
                        double d = (byte) a + b / c / e;
                        System.out.println(d);
                    }
                }""";
    }

    private static String Task8() {
        return """
                public class Lab2Task8 {
                    public static void main(String[] args) {
                        int a = 5;
                        int b = 4;
                        int c = 3;
                        int e = 2;
                        double d = a + b / c / (double) e;
                        System.out.println(d);
                    }
                }""";
    }




    public static String execute(int task) {
        return switch (task) {
            case 1 -> Task1();
            case 2 -> Task2();
            case 3 -> Task3();
            case 4 -> Task4();
            case 5 -> Task5();
            case 6 -> Task6();
            case 7 -> Task7();
            case 8 -> Task8();
            default -> "Пока не реализовано";
        };
    }
}
