package com.kikuzawa.laboratoriesjava.Labs;

/*
 * Класс TaskExecutorLabOneDOne содержит методы для выполнения различных задач из лабораторной работы No1.1.
 * В основном это обычный вывод текста в поле.
 */
public class TaskExecutorLabOneDOne {
    private static String Task1() {
        return """
                Scanner scanner = new Scanner(System.in);

                        System.out.print("Введите количество строк: ");
                        int n = scanner.nextInt();
                        scanner.nextLine();

                        String shortestString = null;
                        int shortestStringLength = Integer.MAX_VALUE;

                        for (int i = 0; i < n; i++) {
                            System.out.print("Введите строку " + (i + 1) + ": ");
                            String input = scanner.nextLine();

                            if (input.length() < shortestStringLength) {
                                shortestString = input;
                                shortestStringLength = input.length();
                            }
                        }

                        System.out.println("Самая короткая строка: " + shortestString);
                        System.out.println("Длина строки: " + shortestStringLength);""";
    }

    private static String Task2() {
        return """
                Scanner scanner = new Scanner(System.in);

                        System.out.print("Введите количество строк: ");
                        int n = scanner.nextInt();
                        scanner.nextLine(); // считываем символ новой строки после ввода числа

                        String[] strings = new String[n];

                        for (int i = 0; i < n; i++) {
                            System.out.print("Введите строку " + (i + 1) + ": ");
                            strings[i] = scanner.nextLine();
                        }

                        Arrays.sort(strings, Comparator.comparingInt(String::length).thenComparing(String::compareTo));

                        System.out.println("Отсортированные строки: ");
                        for (String str : strings) {
                            System.out.println(str);
                            System.out.println("Длина строки: " + str.length());
                        }""";
    }

    private static String Task3() {
       return """
               Scanner scanner = new Scanner(System.in);

                       System.out.print("Введите количество строк: ");
                       int n = scanner.nextInt();

                       scanner.nextLine(); // считываем перевод на новую строку после ввода числа

                       String[] strings = new String[n];
                       double sumLength = 0;

                       System.out.println("Введите строки:");
                       for (int i = 0; i < n; i++) {
                           strings[i] = scanner.nextLine();
                           sumLength += strings[i].length();
                       }

                       double averageLength = sumLength / n;

                       System.out.println("Строки, длина которых меньше средней:");
                       for (String str : strings) {
                           if (str.length() < averageLength) {
                               System.out.println(str + " (длина: " + str.length() + ")");
                           }
                       }""";
    }

    private static String Task6() {
        return """
                String text = "Пример 123 текста 456! Символы удалить.";
                        String cleanedText = text.replaceAll("[^а-яА-Яa-zA-Z ]+", " "); // Удаление символов, не являющихся буквами или пробелами
                        cleanedText = cleanedText.replaceAll("(\\\\p{L}+)(\\\\s*\\\\1)+", "$1 "); // Оставляем только один пробел между последовательностями букв

                        System.out.println(cleanedText);""";
    }

    private static String Task4() {
        return """
                Scanner scanner = new Scanner(System.in);

                        System.out.println("Введите текст:");
                        String text = scanner.nextLine();

                        System.out.println("Введите номер буквы, которую нужно заменить:");
                        int k = scanner.nextInt();

                        System.out.println("Введите символ для замены:");
                        char symbol = scanner.next().charAt(0);

                        String[] words = text.split(" ");

                        for (String word : words) {
                            if (k <= word.length()) {
                                char[] letters = word.toCharArray();
                                letters[k - 1] = symbol;
                                System.out.print(new String(letters) + " ");
                            } else {
                                System.out.print(word + " ");
                            }
                        }""";
    }

    private static String Task5() {
        return """
                String text = "Пример нашего текста";
                        text = text.toLowerCase(); // Преобразуем текст к нижнему регистру

                        for (int i = 0; i < text.length(); i++) {
                            char letter = text.charAt(i);
                            int number = letter - 'а' + 1; // Вычисляем номер буквы от 1 до 33 для русского алфавита
                            System.out.print(letter + "  ");
                        }
                        System.out.println(); // Переход на новую строку

                        for (int i = 0; i < text.length(); i++) {
                            char letter = text.charAt(i);
                            int number = letter - 'а' + 1; // Вычисляем номер буквы от 1 до 33 для русского алфавита
                            if (letter == ' '){System.out.print("     ");}
                            else {System.out.print(number + " ");}

                        }""";
    }

    private static String Task7() {
        return """
                String text = "Example text to illustrate the removal of words of length 5 that start with a consonant.";

                        int wordLength = 5;
                        String consonantPattern = "[bcdfghjklmnpqrstvwxyzBCDFGHJKLMNPQRSTVWXYZ]";

                        Pattern pattern = Pattern.compile("\\\\b" + consonantPattern + "\\\\p{L}{" + (wordLength - 1) + "}\\\\b");
                        Matcher matcher = pattern.matcher(text);

                        String cleanedText = matcher.replaceAll("");

                        System.out.println(cleanedText);""";
    }

    private static String Task8() {
        return """
                String text = "Просто здравствуй просто как дела алед как ты привет отсорП ";
                        System.out.print("Исходный текст: " + text);
                        String[] words = text.split(" ");
                        StringBuilder reverseWord;
                        for (int i = 0; i < words.length; i++) {
                            for (int j = i + 1; j < words.length; j++) {
                                reverseWord = new StringBuilder(words[j]).reverse();
                                if (words[i].equalsIgnoreCase(reverseWord.toString())) {
                                    System.out.println("\\n" + words[i] + " - " + reverseWord.reverse());


                                }


                            }
                        }""";
    }

    public static String Task9() {
        return """
                 String text = "А снег идёт, а снег идёт и всё мерцает и плывёт плывёт";
                        System.out.println("Исходный текст: " + text);
                        String[] words = text.split(" ");
                        for (int i = 0; i < words.length; i++) {
                            int repeat = 0;
                            for (int j = 0; j < words.length; j++) {
                                if (words[i].equals(words[j])) {
                                    repeat++;
                                }
                            }
                            System.out.println("Слово " + "'" + words[i] + "'" + " повторяется " + repeat + " раз(а)");
                        }\
                """;
    }

    private static String Task10() {
        return """
                Scanner scanner = new Scanner(System.in);
                        System.out.println("Введите текст:");
                        String text = scanner.nextLine();

                        String[] sentences = text.split("[.!?]");

                        for (String sentence : sentences) {
                            int vowels = 0;
                            int consonants = 0;

                            for (char c : sentence.toLowerCase().toCharArray()) {
                                if (c >= 'a' && c <= 'z') {
                                    if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u') {
                                        vowels++;
                                    } else {
                                        consonants++;
                                    }
                                }
                            }

                            System.out.println("В предложении: \\"" + sentence.trim() + "\\"");
                            if (vowels > consonants) {
                                System.out.println("Больше гласных букв");
                            } else if (consonants > vowels) {
                                System.out.println("Больше согласных букв");
                            } else {
                                System.out.println("Гласных и согласных букв поровну");
                            }
                        }

                        scanner.close();""";
    }

    private static String Task11() {
        return """
                Scanner in = new Scanner(System.in);
                        System.out.print("Введите количество точек: ");
                        int n = in.nextInt();
                        double[] x_kord = new double[n];
                        double[] y_kord = new double[n];
                        for (int i = 0; i < n; i++) {
                            System.out.print("Введите количество координату x точки номер " + (i + 1) + ": ");
                            x_kord[i] = in.nextDouble();
                            System.out.print("Введите количество координату y точки номер " + (i + 1) + ": ");
                            y_kord[i] = in.nextDouble();
                        }
                        System.out.println("Вы ввели точки: ");
                        for (int i = 0; i < n; i++) {
                            System.out.println("(" + x_kord[i] + ";" + y_kord[i] + ")");
                        }

                        if (n < 3) {
                            System.out.print("Точек недостаточно чтобы построить треугольник");
                        } else {
                            if (n == 3) {
                                double res = lenght(0, 1, x_kord, y_kord) + lenght(1, 2, x_kord, y_kord) + lenght(2, 0, x_kord, y_kord);
                                System.out.print("Единственный и наибольший периметр: " + res);
                            } else {
                                double max = 0;
                                double[] x_max = new double[3];
                                double[] y_max = new double[3];
                                for (int i = 0; i < n; i++) {
                                    for (int j = i; j < n; j++) {
                                        for (int k = j; k < n; k++) {
                                            double maybe = lenght(i, j, x_kord, y_kord) + lenght(j, k, x_kord, y_kord) + lenght(k, i, x_kord, y_kord);
                                            if (maybe >= max) {
                                                max = maybe;
                                                y_max[0] = y_kord[i];
                                                y_max[1] = y_kord[j];
                                                y_max[2] = y_kord[k];
                                            }
                                        }
                                    }
                                }
                                System.out.println("Максимальный периметр треугольника " + max);
                                for (int i = 0; i < 3; i++) {
                                    System.out.println("(" + x_kord[i] + ";" + y_kord[i] + ")");
                                }
                            }
                        }
                    }

                    private static double lenght(int i, int j, double[] x, double[] y) {
                        double dif_x = x[j] - x[i];
                        double dif_y = y[j] - y[i];
                        double ans = Math.sqrt(Math.pow(dif_x, 2) + Math.pow(dif_y, 2));
                        System.out.println(ans);
                        return ans;
                    }""";
    }

    private static String Task12() {
        return """
                Scanner in = new Scanner(System.in);
                        System.out.print("Введите количество точек: ");
                        int n = in.nextInt();
                        double[] x_kord = new double[n];
                        double[] y_kord = new double[n];
                        for (int i = 0; i < n; i++) {
                            System.out.print("Введите количество координату x точки номер " + (i + 1) + ": ");
                            x_kord[i] = in.nextDouble();
                            System.out.print("Введите количество координату y точки номер " + (i + 1) + ": ");
                            y_kord[i] = in.nextDouble();
                        }
                        System.out.println("Вы ввели точки:");
                        for (int i = 0; i < n; i++) {
                            System.out.println("(" + x_kord[i] + ";" + y_kord[i] + ")");
                        }
                        double max = 0;
                        double x_max = 0;
                        double y_max = 0;
                        int max_index = 0;
                        for (int i = 0; i < n; i++) {
                            for (int j = 0; j < n; j++) {
                                double sum = 0;
                                if (j != i) {
                                    sum += lenght(i, j, x_kord, y_kord);
                                }
                                if (sum >= max) {
                                    max = sum;
                                    x_max = x_kord[i];
                                    y_max = y_kord[i];
                                    max_index = i + 1;
                                }
                            }
                        }
                        System.out.println("Ответ: точка номер " + max_index + " с координатами (" + x_max + ";" + y_max + ") и суммой расстояний " + max);
                    }

                    private static double lenght(int i, int j, double[] x, double[] y) {
                        double dif_x = x[j] - x[i];
                        double dif_y = y[j] - y[i];
                        double ans = Math.sqrt(Math.pow(dif_x, 2) + Math.pow(dif_y, 2));
                        return ans;
                    }""";
    }

    private static String Task13() {
        return """
                Scanner in = new Scanner(System.in);
                        System.out.print("Введите количество точек: ");
                        int n = in.nextInt();
                        int[] x = new int[n];
                        int[] y = new int[n];
                        for (int i = 0; i < n; i++){
                            System.out.print("Введите количество координату x точки номер "+ (i + 1) +": ");
                            x[i] = in.nextInt();
                            System.out.print("Введите количество координату y точки номер "+ (i + 1) +": ");
                            y[i] = in.nextInt();
                        }
                        System.out.println("Вы ввели точки:");
                        for (int i = 0; i < n; i++) {
                            System.out.println("(" + x[i] + ";" + y[i] + ")");
                        }
                        double s ;
                        int smid = 0;
                        for (int i = 0; i < n-1; i++){
                            if (i + 1 == n) {
                                System.out.println(i);
                                smid += (x[i] * y[1]) - (y[i] * x[1]);
                            }
                            else{
                                smid += (x[i] * y[i+1]) - (y[i] * x[i+1]);
                            }
                        }
                        System.out.println(smid);
                        s = Math.abs(smid) / 2;
                        System.out.print("Площадь многоугольников равна " + s);
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
            case 9 -> Task9();
            case 10 -> Task10();
            case 11 -> Task11();
            case 12 -> Task12();
            case 13 -> Task13();
            default -> "Пока не реализовано";
        };
    }
}
