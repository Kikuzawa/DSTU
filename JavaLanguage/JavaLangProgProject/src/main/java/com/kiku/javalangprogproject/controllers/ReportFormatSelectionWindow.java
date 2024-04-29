package com.kiku.javalangprogproject.controllers;


import com.kiku.javalangprogproject.BaseController;
import com.kiku.javalangprogproject.config.ListHeaderTable;
import com.kiku.javalangprogproject.reportGenerators.ExcelReportGenerator;
import com.kiku.javalangprogproject.reportGenerators.PrinterReportGenerator;
import com.kiku.javalangprogproject.reportGenerators.WordDocxReportGenerator;
import javafx.scene.control.Button;
import javafx.scene.layout.AnchorPane;
import javafx.stage.Stage;

import static com.kiku.javalangprogproject.Utils.NotificationUtils.showErrorNotification;

public class ReportFormatSelectionWindow extends BaseController {


    public Button excelButton;


    public static String nameCallingController;
    public AnchorPane pane;
    public AnchorPane paneReport;


    /**
     * Этот код извлекает имя вызывающего контроллера, анализируя стек вызовов текущего потока.
     * Затем он выводит и сохраняет имя вызывающего контроллера.
     */
    public static void help() {
        try {
            StackTraceElement[] stackTraceElements = Thread.currentThread().getStackTrace();
            if (stackTraceElements.length >= 3) { // Assuming the calling controller is at index 2
                String callingController = stackTraceElements[2].getClassName();
                nameCallingController = callingController;
            }
        } catch (Exception ex) {
            showErrorNotification(ex.getMessage());
        }
    }

    public void createWordDocx() {
        try {

            if (nameCallingController.equals("com.kiku.javalangprogproject.controllers.AssortimentController")) {
                WordDocxReportGenerator.createWordDocxAssortiment(ListHeaderTable.ASSORTIMENT, "shoes.json", "shoes.docx");
            }
            if (nameCallingController.equals("com.kiku.javalangprogproject.controllers.DisposalController")) {
                WordDocxReportGenerator.createWordDocxAssortiment(ListHeaderTable.DISPOSAL, "disposal.json", "disposal.docx");
            }
            if (nameCallingController.equals("com.kiku.javalangprogproject.controllers.StockController")) {
                WordDocxReportGenerator.createWordDocxAssortiment(ListHeaderTable.STOCK, "stock.json", "stock.docx");
            }
            if (nameCallingController.equals("com.kiku.javalangprogproject.controllers.ShopsController")) {
                WordDocxReportGenerator.createWordDocxAssortiment(ListHeaderTable.SHOPS, "shops.json", "shops.docx");
            }
            if (nameCallingController.equals("com.kiku.javalangprogproject.controllers.SuppliersController")) {
                WordDocxReportGenerator.createWordDocxAssortiment(ListHeaderTable.SUPPLIERS, "suppliers.json", "suppliers.docx");
            }
            if (nameCallingController.equals("com.kiku.javalangprogproject.controllers.FaxController")) {
                WordDocxReportGenerator.createWordDocxAssortiment(ListHeaderTable.TAX, "tax.json", "fax.docx");
            }
            if (nameCallingController.equals("com.kiku.javalangprogproject.controllers.ComplainController")) {
                WordDocxReportGenerator.createWordDocxAssortiment(ListHeaderTable.COMPLAIN, "complain.json", "complain.docx");
            }

        } catch (Exception ex) {
            showErrorNotification(ex.getMessage());
        }
    }

    public void createExcel() {
        try {
            if (nameCallingController.equals("com.kiku.javalangprogproject.controllers.AssortimentController")) {
                ExcelReportGenerator.createExcelAssortiment(ListHeaderTable.ASSORTIMENT, "shoes.json", "shoes");
            }
            if (nameCallingController.equals("com.kiku.javalangprogproject.controllers.DisposalController")) {
                ExcelReportGenerator.createExcelAssortiment(ListHeaderTable.DISPOSAL, "disposal.json", "disposal");
            }
            if (nameCallingController.equals("com.kiku.javalangprogproject.controllers.StockController")) {
                ExcelReportGenerator.createExcelAssortiment(ListHeaderTable.STOCK, "stock.json", "stock");
            }
            if (nameCallingController.equals("com.kiku.javalangprogproject.controllers.ShopsController")) {
                ExcelReportGenerator.createExcelAssortiment(ListHeaderTable.SHOPS, "shops.json", "shops");
            }
            if (nameCallingController.equals("com.kiku.javalangprogproject.controllers.SuppliersController")) {
                ExcelReportGenerator.createExcelAssortiment(ListHeaderTable.SUPPLIERS, "suppliers.json", "suppliers");
            }
            if (nameCallingController.equals("com.kiku.javalangprogproject.controllers.FaxController")) {
                ExcelReportGenerator.createExcelAssortiment(ListHeaderTable.TAX, "tax.json", "fax");
            }
            if (nameCallingController.equals("com.kiku.javalangprogproject.controllers.ComplainController")) {
                ExcelReportGenerator.createExcelAssortiment(ListHeaderTable.COMPLAIN, "complain.json", "complain");
            }
        } catch (Exception ex) {
            showErrorNotification(ex.getMessage());
        }
    }

    public void createPdf() {
        try {


            if (nameCallingController.equals("com.kiku.javalangprogproject.controllers.AssortimentController")) {
                PrinterReportGenerator.createPrinterAssortiment(ListHeaderTable.ASSORTIMENT, "shoes.json");
            }
            if (nameCallingController.equals("com.kiku.javalangprogproject.controllers.DisposalController")) {
                PrinterReportGenerator.createPrinterAssortiment(ListHeaderTable.DISPOSAL, "disposal.json");
            }
            if (nameCallingController.equals("com.kiku.javalangprogproject.controllers.StockController")) {
                PrinterReportGenerator.createPrinterAssortiment(ListHeaderTable.STOCK, "stock.json");
            }
            if (nameCallingController.equals("com.kiku.javalangprogproject.controllers.ShopsController")) {
                PrinterReportGenerator.createPrinterAssortiment(ListHeaderTable.SHOPS, "shops.json");
            }
            if (nameCallingController.equals("com.kiku.javalangprogproject.controllers.SuppliersController")) {
                PrinterReportGenerator.createPrinterAssortiment(ListHeaderTable.SUPPLIERS, "suppliers.json");
            }
            if (nameCallingController.equals("com.kiku.javalangprogproject.controllers.FaxController")) {
                PrinterReportGenerator.createPrinterAssortiment(ListHeaderTable.TAX, "tax.json");
            }
            if (nameCallingController.equals("com.kiku.javalangprogproject.controllers.ComplainController")) {
                PrinterReportGenerator.createPrinterAssortiment(ListHeaderTable.COMPLAIN, "complain.json");
            }
        } catch (Exception ex) {
            showErrorNotification(ex.getMessage());
        }
    }


    public void closeWindow() {
        Stage stage = (Stage) excelButton.getScene().getWindow();
        stage.close();
    }
}
