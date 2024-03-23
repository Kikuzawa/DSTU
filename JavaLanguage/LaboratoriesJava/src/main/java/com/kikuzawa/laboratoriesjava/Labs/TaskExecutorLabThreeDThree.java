/**
 * Класс TaskExecutorLabThreeDThree предоставляет метод execute для выполнения различных задач из лабораторной работы 3.1
 * по регулярным выражениям. Задачи включают проверку соответствия ввода определенным шаблонам, таким как
 * URL, IP-адреса, электронные адреса и т. д.
 */
package com.kikuzawa.laboratoriesjava.Labs;

import java.util.regex.Matcher;
import java.util.regex.Pattern;

@SuppressWarnings("Annotator")
public class TaskExecutorLabThreeDThree {
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
            case 9 -> Task9(input);
            case 10 -> Task10(input);
            case 11 -> Task11(input);
            case 12 -> Task12(input);
            case 13 -> Task13(input);
            default -> "Пока не реализовано";
        };
    }

    private static String Task1(String input) {
        String pattern = "^abcdefghijklmnopqrstuv18340";
        return String.valueOf(Pattern.matches(pattern, input));
    }

    private static String Task2(String input) {
        String pattern = "^[A-Za-z0-9]{8}-[A-Za-z0-9]{4}-[A-Za-z0-9]{4}-[A-Za-z0-9]{4}-[A-Za-z0-9]{12}$";
        return String.valueOf(Pattern.matches(pattern, input));
    }

    private static String Task3(String input) {
        String pattern = "^([0-9A-Fa-f]{2}[:-]){5}([0-9A-Fa-f]{2})$";
        return String.valueOf(Pattern.matches(pattern, input));
    }

    private static String Task4(String text) {
        final String URL_REGEX = "((http|https)://)(www.)?" +
                "[a-zA-Z0-9@:%.\\+~#?&//=]" +
                "{2,256}\\.[a-z]" +
                "{2,6}\\b([-a-zA-Z0-9@:%" +
                ".\\+~#?&//=]*)";
        final String IP_ADDRESS_REGEX = "\\b(?:\\d{1,3}\\.){3}\\d{1,3}\\b";

            Pattern urlPattern = Pattern.compile(URL_REGEX);
            Pattern ipAddressPattern = Pattern.compile(IP_ADDRESS_REGEX);

        if (ipAddressPattern.matcher(text).find()) {
            return "false";
        } else {
            return String.valueOf(urlPattern.matcher(text).matches());
        }
    }

    private static String Task5(String text){
        Pattern pattern = Pattern.compile("^#[A-Fa-f0-9]{6}$");
        return String.valueOf(pattern.matcher(text).matches());
    }

    private static String Task6(String text){
        String pattern = "^(0[1-9]|1\\d|2[0-8])/(0[1-9]|1[0-2])/((?:1[6-9]|[2-9]\\d)?\\d{2})\\|29/02/(?:(?:(?:1[6−9]∣[2−9]\\d)(?:0[′ r′48]∣[2468][048]∣[13579][26]))∣(?:16∣[2468][048]∣[3579][26])00)\\|29/02/(?:(?:(?:1[6−9]∣[2−9]\\d)(?:0[′ r′48]∣[2468][048]∣[13579][26]))∣(?:16∣[2468][048]∣[3579][26])00)";
        return String.valueOf(Pattern.matches(pattern, text));
    }

    private static String Task7(String text){
        String pattern = "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+.[a-zA-Z]{2,}$";
        return String.valueOf(Pattern.matches(pattern, text));
    }

    private static String Task8(String text){
        String pattern = "^([0-9]{1,3}[.]){3}[0-9]{1,3}$";
        return String.valueOf(Pattern.matches(pattern, text.strip()));
    }

    private static String Task9(String text){
        String pattern = "^[a-zA-Z0-9_]{8,}";
        if (Pattern.matches(pattern, text) && text.matches(".[A-Z].") && text.matches(".[a-z].") && text.matches(".\\d.")) {
            return "True";
        } else {
            return "False";
        }
    }

    private static String Task10(String text){
        Pattern pattern = Pattern.compile("^[1-9]{6}");
        return String.valueOf(pattern.matcher(text).matches());
    }

    //TODO
    private static String Task11(String text){
        String pattern = "(?:^|[\\n\\r]|[^\\w\\d\\.])([1-9]\\d*(?:.\\d{,2})?\\s*(?:USD|EU|RUR))\b";

        Pattern r = Pattern.compile(pattern);
        Matcher m = r.matcher(text);

        StringBuilder result = new StringBuilder();
        while (m.find()) {
            result.append(m.group(1)).append("\n");
        }

        return result.toString();
    }
    private static String Task12(String text){
        String pattern = "\b\\d+(?:\\s*\\+)";

        Pattern r = Pattern.compile(pattern);
        Matcher m = r.matcher(text.strip());

        boolean found = m.find();

        return Boolean.toString(found);
    }
    private static String Task13(String text){
        Pattern pattern = Pattern.compile("^[^()]*$|^[^()]*(\\([^()]*\\)[^()]*)*$");
        Matcher match = pattern.matcher(text.strip());
        return String.valueOf(match.matches() && match.group(0).chars().filter(c -> c == '(').count() == match.group(0).chars().filter(c -> c == ')').count());
    }



}
