package com.kiku.javalangprogproject.reportGenerators;

import com.kiku.javalangprogproject.config.Paths;
import org.apache.poi.ss.usermodel.*;
import org.apache.poi.xssf.usermodel.XSSFWorkbook;
import org.json.JSONArray;
import org.json.JSONObject;
import org.json.JSONTokener;

import java.awt.*;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;

import static com.kiku.javalangprogproject.Utils.NotificationUtils.showErrorNotification;

public class ExcelReportGenerator {

    /* Этот фрагмент кода на Java создает файл Excel с указанным именем и именем таблицы.
     Он читает данные из файла JSON, заполняет лист Excel этими данными, оформляет заголовки,
    автоматически настраивает размеры столбцов, затем сохраняет и открывает файл Excel. Если происходит
    ошибка во время этого процесса, показывается уведомление с сообщением об ошибке. */

    public static void createExcelAssortiment(String[] headers, String filename, String nameTable) {
        try {
            JSONArray jsonArray;
            FileInputStream fis = new FileInputStream(Paths.PATH_JSONS + filename);
            JSONTokener tokener = new JSONTokener(fis);
            jsonArray = new JSONArray(tokener);


            Workbook workbook = new XSSFWorkbook();
            Sheet sheet = workbook.createSheet(nameTable);


            Row headerRow = sheet.createRow(0);

            CellStyle style = workbook.createCellStyle();
            style.setAlignment(HorizontalAlignment.CENTER);
            for (int i = 0; i < headers.length; i++) {
                Cell cell = headerRow.createCell(i);
                cell.setCellValue(headers[i]);
                cell.setCellStyle(style); }

            for (int i = 0; i < 8; i++) {
                Cell currentCell = headerRow.getCell(i);
                if (currentCell != null) {
                    currentCell.setCellStyle(style);
                }
            }


            for (int i = 0; i < jsonArray.length(); i++) {
                JSONObject jsonObject = jsonArray.getJSONObject(i);
                Row row = sheet.createRow(i + 1);
                for (int j = 0; j < headers.length; j++) {
                    row.createCell(j).setCellValue(jsonObject.getString(headers[j]));
                }
            }

            for (int i = 0; i < headers.length; i++) {
                sheet.autoSizeColumn(i);
            }



            FileOutputStream out = new FileOutputStream(Paths.PATH_SAVE + nameTable + ".xlsx");
            workbook.write(out);
            out.close();

            File file = new File(Paths.PATH_SAVE + nameTable + ".xlsx");
            if (file.exists()) {
                Desktop.getDesktop().open(file);
            }


        } catch (Exception ex) {
            showErrorNotification(ex.getMessage());
        }

    }
}
