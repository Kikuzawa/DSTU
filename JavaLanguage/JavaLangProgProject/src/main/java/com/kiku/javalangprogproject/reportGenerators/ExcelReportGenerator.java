package com.kiku.javalangprogproject.reportGenerators;

import org.apache.poi.ss.usermodel.*;
import org.apache.poi.xssf.usermodel.XSSFWorkbook;
import org.json.JSONArray;
import org.json.JSONObject;
import org.json.JSONTokener;

import java.awt.*;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;

public class ExcelReportGenerator {
    public static void createExcelAssortiment(String[] headers, String filename, String nameTable) throws IOException {
        JSONArray jsonArray;
        try (FileInputStream fis = new FileInputStream(filename)) {
            JSONTokener tokener = new JSONTokener(fis);
            jsonArray = new JSONArray(tokener);
        }

        try (Workbook workbook = new XSSFWorkbook()) {
            Sheet sheet = workbook.createSheet(nameTable);

            // Создание заголовка таблицы
            Row headerRow = sheet.createRow(0);

            CellStyle style = workbook.createCellStyle();
            style.setAlignment(HorizontalAlignment.CENTER);
            for (int i = 0; i < headers.length; i++){
                Cell cell = headerRow.createCell(i);
                cell.setCellValue(headers[i]);
                cell.setCellStyle(style); // Установка стиля после создания ячейки
            }

            for (int i = 0; i < 8; i++) {
                Cell currentCell = headerRow.getCell(i);
                if (currentCell != null) {
                    currentCell.setCellStyle(style);
                }
            }

            // Заполнение таблицы данными из JSON
            for (int i = 0; i < jsonArray.length(); i++) {
                JSONObject jsonObject = jsonArray.getJSONObject(i);
                Row row = sheet.createRow(i + 1);
                for (int j = 0; j < headers.length; j++){
                    row.createCell(j).setCellValue(jsonObject.getString(headers[j]));
                }
            }

            for (int i = 0; i < headers.length; i++) {
                sheet.autoSizeColumn(i);
            }


            // Сохранение документа Excel
            FileOutputStream out = new FileOutputStream(nameTable+".xlsx");
            workbook.write(out);
            out.close();

            File file = new File(nameTable+".xlsx");
            if (file.exists()) {
                Desktop.getDesktop().open(file);
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

}
