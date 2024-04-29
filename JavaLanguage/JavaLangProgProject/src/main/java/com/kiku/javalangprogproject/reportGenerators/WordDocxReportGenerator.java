package com.kiku.javalangprogproject.reportGenerators;

import com.kiku.javalangprogproject.config.Paths;
import org.apache.poi.xwpf.usermodel.XWPFDocument;
import org.apache.poi.xwpf.usermodel.XWPFTable;
import org.apache.poi.xwpf.usermodel.XWPFTableRow;
import org.json.JSONArray;
import org.json.JSONObject;
import org.json.JSONTokener;

import java.awt.*;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;

import static com.kiku.javalangprogproject.Utils.NotificationUtils.showErrorNotification;

public class WordDocxReportGenerator {

    /* Этот код на Java создает документ Word и заполняет его данными из массива JSON.
    Он принимает заголовки, имя файла и имя таблицы в качестве параметров. Код читает
    JSON файл, создает таблицу в документе Word, заполняет таблицу данными из массива JSON,
    сохраняет документ Word и открывает его на рабочем столе. Если происходит исключение,
    показывается уведомление об ошибке.
     */

    public static void createWordDocxAssortiment(String[] headers, String filename, String nameTable) {
        try {
            JSONArray jsonArray;
            try (FileInputStream fis = new FileInputStream(Paths.PATH_JSONS + filename)) {
                JSONTokener tokener = new JSONTokener(fis);
                jsonArray = new JSONArray(tokener);
            }

// Заполните массив jsonArray вашими данными


            XWPFDocument document = new XWPFDocument();
            XWPFTable table = document.createTable();

            // Создание заголовка таблицы
            XWPFTableRow headerRow = table.getRow(0);
            for (int i = 1; i < headers.length; i++) {
                headerRow.addNewTableCell().setText("");
                headerRow.getCell(i).setText(headers[i]);
            }

            // Заполнение таблицы данными из JSON
            for (int i = 0; i < jsonArray.length(); i++) {
                JSONObject jsonObject = jsonArray.getJSONObject(i);
                XWPFTableRow row = table.createRow();
                for (int j = 0; j < headers.length; j++) {
                    row.getCell(j).setText(jsonObject.getString(headers[j]));
                }
            }

            // Сохранение документа Word
            FileOutputStream out = new FileOutputStream(Paths.PATH_SAVE + nameTable);
            document.write(out);
            out.close();

            File file = new File(Paths.PATH_SAVE + nameTable);
            Desktop desktop = Desktop.getDesktop();
            if (file.exists()) {
                desktop.open(file);
            }

        } catch (Exception ex) {
            showErrorNotification(ex.getMessage());
        }
    }
}
