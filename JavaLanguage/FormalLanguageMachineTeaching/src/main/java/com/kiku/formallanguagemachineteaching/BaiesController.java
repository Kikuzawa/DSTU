package com.kiku.formallanguagemachineteaching;

import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.scene.control.*;
import javafx.scene.control.cell.PropertyValueFactory;
import javafx.scene.paint.Color;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.*;


@SuppressWarnings("ALL")
public class BaiesController {

    public Button removeButton;
    public TextArea otherMessageField;
    public CheckBox checkBoxSpam;
    public Button addButton;
    public TextField pSpamField;
    public TextField pNoSpamField;
    public Label stavniLabel;
    public TextField clearWordField;
    Double countSpamP;
    Double countNoSpamP;

    public TableView<Word> wordsTable;
    public TableColumn<Word, String> wordColumn;
    public TableColumn<Word, Integer> spamColumn;
    public TableColumn<Word, Integer> noSpamColumn;
    public TableColumn<Word, Double> pSpamColumn;
    public TableColumn<Word, Double> pNoSpamColumn;
    public TextArea messageField;
    public TextField statusFiled;
    public Button calculateButton;
    public TableView<Message> messageTable;
    public TableColumn<Message, String> messageColumn;
    public TableColumn<Message, String> statusColumn;
    public TextField coffField;


    Connection connection = DbConnect.getConnect();
    ObservableList<Message> MessageList = FXCollections.observableArrayList();

    ObservableList<Word> WordList = FXCollections.observableArrayList();

    public void initialize() throws SQLException {

        messageField.setText(" ");
        coffField.setText("1.0");
        loadDateToMessageTable();
        messageField.clear();

        messageTable.setOnMouseClicked(event -> {
            if (event.getClickCount() == 1) {
                Message selectedMessage = messageTable.getSelectionModel().getSelectedItem();

                if (selectedMessage != null) {
                    String messageContent = selectedMessage.getMessage();
                    otherMessageField.setText(messageContent);
                    checkBoxSpam.setSelected(selectedMessage.getStatus().equals("SPAM"));
                }
            }
        });


        /*
         * Обрабатывает таблицу, закрашивая выделенные ячейки со словами исследуюемого сообщения зеленым цветом
         * */
        wordColumn.setCellFactory(column -> {
            return new TableCell<Word, String>() {
                @Override
                protected void updateItem(String item, boolean empty) {
                    super.updateItem(item, empty);

                    if (item == null || empty) {
                        setText(null);
                        setStyle("");
                    } else {
                        setText(item);

                        String messageFieldText = messageField.getText();
                        if (messageFieldText != null && !messageFieldText.isEmpty() && item != null && !item.isEmpty()) {
                            boolean containsWholeWord = false;
                            String[] words = messageFieldText.split("\\s+");
                            for (String word : words) {
                                if (word.equalsIgnoreCase(item)) {
                                    containsWholeWord = true;
                                    break;
                                }
                            }

                            if (containsWholeWord) {
                                setStyle("-fx-background-color: lightgreen;");
                                setTextFill(Color.BLACK);
                            } else {
                                setStyle("");
                                setTextFill(Color.BLACK);
                            }
                        } else {
                            setStyle("");
                            setTextFill(Color.BLACK);
                        }
                    }
                }
            };
        });


    }

    /*  Метод для подсчета количества слов в сообщении
     *  @param word - слово, которое нужно подсчитать
     *  @param Messages - список сообщений, в которых нужно искать слово
     *  @return количество вхождений слова в сообщения
     */
    public Integer countWordInMessages(String word, List<String> Messages) {
        int count = 0;
        String regex = "(^|\\s+)" + word + "(\\s+|$)";

        for (String message : Messages) {
            if (message.matches(".*" + regex + ".*")) {
                count++;
            }
        }
        return count;
    }


    /**
     * Обновляет таблицу сообщений, извлекая сообщения из базы данных и обновляя пользовательский интерфейс.
     *
     * @throws SQLException если происходит ошибка доступа к базе данных
     */
    public void refreshMessageTable() throws SQLException {

        MessageList.clear();


        PreparedStatement preparedStatement = connection.prepareStatement("SELECT * FROM baiesfl.message");
        ResultSet resultSet = preparedStatement.executeQuery();

        while (resultSet.next()) {
            MessageList.add(new Message(resultSet.getString("message").toLowerCase(), resultSet.getString("status")));

            messageTable.setItems(MessageList);
        }


    }


    /*  Загрузка сообщений в таблицу
     *  @throws SQLException  если происходит ошибка доступа к базе данных
     */
    public void loadDateToMessageTable() throws SQLException {

        refreshMessageTable();


        messageColumn.setCellValueFactory(new PropertyValueFactory<>("message"));
        statusColumn.setCellValueFactory(new PropertyValueFactory<>("status"));
        fillWordColumn();
    }


    /**
     * Метод для извлечения всех сообщений с определенноым статусом из MessageList.
     *
     * @return Возвращает список сообщений после обработки.
     */
    public List<String> getMessages(String status) {
        List<String> spamMessages = new ArrayList<>();

        for (Message message : MessageList) {
            if (message.getStatus().equals(status)) {
                spamMessages.add(removePunctuation(removePrepositions(message.getMessage())));
            }

        }
        return spamMessages;
    }



    /*  Удаление знаков препинания из сообщений
     *  @param message - сообщение, из которого нужно удалить знаки препинания
     *  @return сообщение без знаков препинания
     */

    public String removePrepositions(String message) {
        List<String> prepositions = Arrays.asList(clearWordField.getText().split("\\s+"));

        String[] words = message.split("\\s+");
        StringBuilder result = new StringBuilder();

        for (String word : words) {
            if (!prepositions.contains(word.toLowerCase())) {
                result.append(word).append(" ");
            }
        }

        return result.toString().trim();
    }

    /* Этот фрагмент кода представляет собой метод на Java,
     * который заполняет столбец слов в таблице. Он обрабатывает
     * сообщения, отмеченные как "СПАМ" и "НЕ СПАМ", извлекает слова,
     * вычисляет вероятности и создает объекты Word для каждого
     * уникального слова для отображения в таблице.
     */
    public void fillWordColumn() {
        Set<String> uniqueWords = new HashSet<>();
        Set<String> spamWords = new HashSet<>();
        Set<String> noSpamWords = new HashSet<>();
        List<String> spamMessages = getMessages("SPAM");
        List<String> noSpamMessages = getMessages("NO SPAM");


        String[] wordsCorrectMessage = removePrepositions(removePunctuation(messageField.getText().toLowerCase())).split("\\s+");


        // Проход по каждой строке в messageColumn


        for (String message : spamMessages) {
            spamWords.addAll(Arrays.asList(removePrepositions(message).split("\\s+")));
        }

        for (String message : noSpamMessages) {
            noSpamWords.addAll(Arrays.asList(removePrepositions(message).split("\\s+")));
        }

        uniqueWords.addAll(spamWords);
        uniqueWords.addAll(noSpamWords);


        int countM = uniqueWords.size();

        int countSpam = spamWords.size();

        int countNoSpam = noSpamWords.size();


        countSpamP = getP(MessageList.size(), spamMessages.size());

        countNoSpamP = getP(MessageList.size(), noSpamMessages.size());


        uniqueWords.addAll(Arrays.asList(wordsCorrectMessage));


        // Создание объектов Word для каждого уникального слова и добавление их в список
        for (String word : uniqueWords) {
            Integer countSpamOfWord = countWordInMessages(word, spamMessages);
            Integer countNoSpamOfWord = countWordInMessages(word, noSpamMessages);

            Double pSpam = (1.0 + countSpamOfWord) / (1.0 * countM + countSpam);

            Double pNoSpam = (1.0 + countNoSpamOfWord) / (1.0 * countM + countNoSpam);

            if (Arrays.asList(wordsCorrectMessage).contains(word)) {
                WordList.add(new Word(removePunctuation(word), countSpamOfWord, countNoSpamOfWord, pSpam, pNoSpam));
            } else {
                WordList.add(new Word(removePunctuation(word), countSpamOfWord, countNoSpamOfWord, 1.0, 1.0));

            }
        }

        // Установка списка уникальных слов в таблицу
        wordsTable.setItems(WordList);


        wordColumn.setCellValueFactory(new PropertyValueFactory<>("word"));
        spamColumn.setCellValueFactory(new PropertyValueFactory<>("spam"));
        noSpamColumn.setCellValueFactory(new PropertyValueFactory<>("noSpam"));
        pSpamColumn.setCellValueFactory(new PropertyValueFactory<>("pSpam"));
        pNoSpamColumn.setCellValueFactory(new PropertyValueFactory<>("pNoSpam"));


    }

    /*Этот Java код определяет метод calculate, который выполняет
    различные операции, такие как обновление таблицы сообщений,
    очистку списка слов, заполнение столбца слов, установку текста
    в определенных полях на основе вычислений, определение статуса
    сообщения, установку стилей и обновление полей сообщений.
    Метод также обновляет поле статуса, метку и флажок на основе результатов вычислений спама.
     */
    public void calculate() throws SQLException {


        refreshMessageTable();
        WordList.clear();
        fillWordColumn();


        pSpamField.setText(String.valueOf(getArg(pSpamColumn, countSpamP)));
        pNoSpamField.setText(String.valueOf(getArg(pNoSpamColumn, countNoSpamP)));

        /* Определяем статус сообщения и выставляем соответствующий стиль */
        if (getArg(pSpamColumn, countSpamP) > getArg(pNoSpamColumn, countNoSpamP)) {
            statusFiled.setText("SPAM");
            statusFiled.setStyle("-fx-background-color: red;");
            checkBoxSpam.setSelected(true);

            stavniLabel.setText("⋁");
        } else {
            statusFiled.setText("NO SPAM");
            statusFiled.setStyle("-fx-background-color: green;");
            checkBoxSpam.setSelected(false);
            stavniLabel.setText("⋀");
        }


        otherMessageField.setText(messageField.getText());
        addMessage();


    }


    /*  Удаление знаков препинания из слова или сообщения */
    public static String removePunctuation(String word) {

        List<String> prepositions = Arrays.asList("в", "на", "из", "от", "до", "по", "за", "под", "над", "к", "с", "у", "о", "об", "перед", "через", "между", "подо");


        String cleanWord = word.replaceAll("\\p{Punct}", "").toLowerCase();


        for (String preposition : prepositions) {
            cleanWord = cleanWord.replaceAll("\\b" + preposition + "\\b", "");
        }

        return cleanWord.trim();
    }

    /* Получения вероятности */
    public Double getP(int countM, int count) {

        return count * 1.0 / countM;
    }


    /* Вычисление аргумента */
    public Double getArg(TableColumn<Word, Double> column, Double p) {

        double result = 1.0;


        for (Word word : wordsTable.getItems()) {
            Double pSpamValue = column.getCellData(word);


            result *= pSpamValue;
        }

        result *= p;


        return result;
    }


    /* Удаление сообщения из БД SQL  */
    public void removeMessage() {

        try {
            String query = "DELETE FROM baiesfl.message WHERE message = ?";
            PreparedStatement preparedStatement = connection.prepareStatement(query);
            preparedStatement.setString(1, otherMessageField.getText()); // Assuming id is the primary key of the message table
            preparedStatement.executeUpdate();

            // Refresh the table after deletion
            refreshMessageTable();
        } catch (SQLException e) {
            System.out.println("Error deleting message: " + e.getMessage()); // Handle any SQLprintln(); // Handle any SQL exceptions
        }

        otherMessageField.clear();
        checkBoxSpam.setSelected(false);

    }

    /* Добавление сообщения в БД SQL */
    public void addMessage() throws SQLException {

        if (!checkMessageExists(otherMessageField.getText())) {

            String query = "INSERT INTO baiesfl.message (message, status) VALUES (?, ?)";
            PreparedStatement preparedStatement = connection.prepareStatement(query);
            preparedStatement.setString(1, otherMessageField.getText());
            if (checkBoxSpam.isSelected()) {
                preparedStatement.setString(2, "SPAM");
            } else {
                preparedStatement.setString(2, "NO SPAM");
            }

            preparedStatement.executeUpdate();

            refreshMessageTable();
            otherMessageField.clear();
            checkBoxSpam.setSelected(false);
        } else {
            otherMessageField.clear();
            checkBoxSpam.setSelected(false);
            statusFiled.setText("ОШИБКА");
            statusFiled.setStyle("-fx-background-color: yellow;");
        }
    }

    /* Проверка наличия сообщения в БД SQL */
    public boolean checkMessageExists(String messageContent) throws SQLException {
        String query = "SELECT COUNT(*) AS count FROM baiesfl.message WHERE message = ?";
        PreparedStatement preparedStatement = connection.prepareStatement(query);
        preparedStatement.setString(1, messageContent);
        ResultSet resultSet = preparedStatement.executeQuery();


        if (resultSet.next() || messageContent.isEmpty()) {
            int count = resultSet.getInt("count");
            return count > 0;
        }

        return false;
    }
}


