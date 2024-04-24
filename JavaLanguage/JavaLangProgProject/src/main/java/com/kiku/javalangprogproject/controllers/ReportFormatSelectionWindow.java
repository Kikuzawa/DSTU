package com.kiku.javalangprogproject.controllers;

import com.itextpdf.text.DocumentException;
import com.kiku.javalangprogproject.BaseController;
import com.kiku.javalangprogproject.classes.ListHeaderTable;
import com.kiku.javalangprogproject.reportGenerators.ExcelReportGenerator;
import com.kiku.javalangprogproject.reportGenerators.PrinterReportGenerator;
import com.kiku.javalangprogproject.reportGenerators.WordDocxReportGenerator;
import javafx.event.ActionEvent;
import javafx.scene.control.Button;
import javafx.stage.Stage;

import java.awt.print.PrinterException;
import java.io.IOException;

public class ReportFormatSelectionWindow extends BaseController {


    public Button excelButton;


    public Button PdfButton;
    public Button wordButton;

    public static String nameCallingController;

    public static void help() {
        StackTraceElement[] stackTraceElements = Thread.currentThread().getStackTrace();
        if (stackTraceElements.length >= 3) { // Assuming the calling controller is at index 2
            String callingController = stackTraceElements[2].getClassName();
            System.out.println(callingController);
            nameCallingController = callingController;
        }
    }

    public void createWordDocx() throws IOException {

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
            WordDocxReportGenerator.createWordDocxAssortiment(ListHeaderTable.TAX, "fax.json", "fax.docx");
        }

    }

    public void createExcel() throws IOException {
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
            ExcelReportGenerator.createExcelAssortiment(ListHeaderTable.TAX, "fax.json", "fax");
        }
    }

    public void createPdf() throws IOException, DocumentException, PrinterException {
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
            PrinterReportGenerator.createPrinterAssortiment(ListHeaderTable.TAX, "fax.json");
        }
    }


    public void closeWindow(ActionEvent actionEvent) {
        Stage stage = (Stage) excelButton.getScene().getWindow();
        stage.close();
    }
}
