package com.kiku.javalangprogproject.reportGenerators;

import org.json.JSONArray;
import org.json.JSONObject;
import org.json.JSONTokener;

import java.awt.print.PrinterException;
import java.awt.print.PrinterJob;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.IOException;

public class PrinterReportGenerator {

    public static void createPrinterAssortiment(String[] headers, String filename) throws PrinterException, FileNotFoundException {
        JSONArray jsonArray;
        try (FileInputStream fis = new FileInputStream(filename)) {
            JSONTokener tokener = new JSONTokener(fis);
            jsonArray = new JSONArray(tokener);
        } catch (IOException e) {
            throw new RuntimeException(e);
        }

        StringBuilder table = new StringBuilder();
        for (int i = 0; i < headers.length; i++) {
            if (i != headers.length - 1) {
                table.append(headers[i]).append("\t");
            } else {
                table.append(headers[i]).append("\n");
            }
        }


        for (int i = 0; i < jsonArray.length(); i++) {
            JSONObject jsonObject = jsonArray.getJSONObject(i);
            for (int j = 0; j < headers.length; j++) {
                if (j != headers.length - 1) {
                    table.append(jsonObject.getString(headers[j])).append("\t");
                } else {
                    table.append(jsonObject.getString(headers[j])).append("\n");
                }

            }
        }

        PrinterJob job = PrinterJob.getPrinterJob();
        job.setPrintable(new PrintableTable(table.toString()));

        if (job.printDialog()) {
            job.print();
        }
    }
}