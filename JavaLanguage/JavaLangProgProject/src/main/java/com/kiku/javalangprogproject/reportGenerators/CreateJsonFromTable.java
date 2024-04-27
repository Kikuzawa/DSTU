package com.kiku.javalangprogproject.reportGenerators;

import com.kiku.javalangprogproject.classes.*;
import com.kiku.javalangprogproject.config.Paths;
import com.kiku.javalangprogproject.classes.Tax;
import javafx.collections.ObservableList;
import javafx.scene.control.TableView;
import org.json.JSONArray;
import org.json.JSONObject;

import java.io.FileWriter;


import static com.kiku.javalangprogproject.Utils.NotificationUtils.showErrorNotification;

public class CreateJsonFromTable {



    public static void jsonCreateShoe(TableView<Shoe> shoesTable) {
        try {

        ObservableList<Shoe> data = shoesTable.getItems();

        JSONArray jsonArray = new JSONArray();
        for (Shoe item : data) {
            JSONObject jsonObject = new JSONObject();
            jsonObject.put("id", item.getIdShoe());
            jsonObject.put("name", item.getNameShoe());
            jsonObject.put("cost", item.getCostShoe().toString());
            jsonObject.put("color", item.getColorShoe());
            jsonObject.put("stock", item.getStockShoe());
            jsonObject.put("size", item.getSizeShoe());
            jsonObject.put("season", item.getSeasonShoe());
            jsonObject.put("complection", item.getComplection());
            jsonArray.put(jsonObject);
        }

        saveJsonFile("shoes.json", jsonArray);
    } catch (Exception ex) {
        showErrorNotification(ex.getMessage());
    }
    }

    public static void jsonCreateShops(TableView<Shop> shopsTable) {
        try {

        ObservableList<Shop> data = shopsTable.getItems();

        JSONArray jsonArray = new JSONArray();
        for (Shop item : data) {
            JSONObject jsonObject = new JSONObject();
            jsonObject.put("id", item.getIdShop());
            jsonObject.put("name", item.getNameShop());
            jsonObject.put("location", item.getLocationsShop());
            jsonObject.put("email", item.getEmailShop());
            jsonObject.put("number", item.getNumberShop());
            jsonObject.put("fio", item.getFioShop());
            jsonArray.put(jsonObject);
        }
        saveJsonFile("shops.json", jsonArray);
    } catch (Exception ex) {
        showErrorNotification(ex.getMessage());
    }

    }

    public static void jsonCreateSuppliers(TableView<Supplier> suppliersTable) {
        try {

        ObservableList<Supplier> data = suppliersTable.getItems();

        JSONArray jsonArray = new JSONArray();
        for (Supplier item : data) {
            JSONObject jsonObject = new JSONObject();
            jsonObject.put("id", item.getIdSupplier());
            jsonObject.put("name", item.getNameSupplier());
            jsonObject.put("location", item.getLocationsSupplier());
            jsonObject.put("number", item.getNumberSupplier());
            jsonObject.put("stock", item.getStockSupplier());
            jsonArray.put(jsonObject);
        }

        saveJsonFile("suppliers.json", jsonArray);
    } catch (Exception ex) {
        showErrorNotification(ex.getMessage());
    }

    }

    public static void jsonCreateDisposal(TableView<Disposal> disposalTable) {
        try {

        ObservableList<Disposal> data = disposalTable.getItems();
        JSONArray jsonArray = new JSONArray();
        for (Disposal item : data) {
            JSONObject jsonObject = new JSONObject();
            jsonObject.put("id", String.valueOf(item.getIdDisposal()));
            jsonObject.put("name", item.getNameDisposal());
            jsonObject.put("reason", item.getReasonDisposal());
            jsonObject.put("quantity", String.valueOf(item.getQuantityDisposal()));
            jsonObject.put("total", String.valueOf(item.getTotalDisposal()));
            jsonObject.put("cost", String.valueOf(item.getCostDisposal()));
            jsonArray.put(jsonObject);
        }

        saveJsonFile("disposal.json", jsonArray);
    } catch (Exception ex) {
        showErrorNotification(ex.getMessage());
    }
    }

    public static void jsonCreateStock(TableView<Stock> stockTable){
        try {

        ObservableList<Stock> data = stockTable.getItems();
        JSONArray jsonArray = new JSONArray();
        for (Stock item : data) {
            JSONObject jsonObject = new JSONObject();
            jsonObject.put("id", String.valueOf(item.getIdStock()));
            jsonObject.put("name", item.getNameStock());
            jsonObject.put("quantity", String.valueOf(item.getQuantityStock()));
            jsonObject.put("total", String.valueOf(item.getTotalStock()));
            jsonObject.put("cost", String.valueOf(item.getCostStock()));
            jsonArray.put(jsonObject);
        }

        saveJsonFile("stock.json", jsonArray);
    } catch (Exception ex) {
        showErrorNotification(ex.getMessage());
    }
    }


    private static void saveJsonFile(String name, JSONArray jsonArray) {
        try {
            try (FileWriter file = new FileWriter(Paths.PATH_JSONS + name)) {
                file.write("[");
                for (int i = 0; i < jsonArray.length(); i++) {
                    file.write(jsonArray.getJSONObject(i).toString());
                    if (i < jsonArray.length() - 1) {
                        file.write(",");
                    }
                }
                file.write("]");
            }
        } catch (Exception ex) {
            showErrorNotification(ex.getMessage());
        }

    }

    public static void jsonCreateTax(TableView<Tax> taxTable) {
        try {
        ObservableList<Tax> data = taxTable.getItems();
        JSONArray jsonArray = new JSONArray();
        for (Tax item : data) {
            JSONObject jsonObject = new JSONObject();
            jsonObject.put("id", String.valueOf(item.getIdTax()));
            jsonObject.put("month", item.getMonthTax());
            jsonObject.put("year", String.valueOf(item.getYearTax()));
            jsonObject.put("totalIncome", String.valueOf(item.getTotalIncomeTax()));
            jsonObject.put("totalExpense", String.valueOf(item.getTotalExpenseTax()));
            jsonObject.put("procentEarthTax", String.valueOf(item.getProcentEarthTax()));
            jsonObject.put("procentHouseTax", String.valueOf(item.getHouseTax()));
            jsonObject.put("NDS", String.valueOf(item.getNdsTax()));
            jsonObject.put("finalTax", String.valueOf(item.getFinalTax()));
            jsonObject.put("baseTax", String.valueOf(item.getBaseTax()));
            jsonObject.put("taxWithNDS", String.valueOf(item.getTaxWithNDS()));
            jsonObject.put("taxWithNdsAndHouse", String.valueOf(item.getTaxWithNdsAndHouse()));


            jsonArray.put(jsonObject);
        }

        saveJsonFile("tax.json", jsonArray);
    } catch (Exception ex) {
        showErrorNotification(ex.getMessage());
    }
    }

    public static void jsonCreateComplain(TableView<Complain> complainTable) {
        try {
        ObservableList<Complain> data = complainTable.getItems();
        JSONArray jsonArray = new JSONArray();
        for (Complain item : data) {
            JSONObject jsonObject = new JSONObject();
            jsonObject.put("id", String.valueOf(item.getId()));
            jsonObject.put("number", item.getNumber());
            jsonObject.put("sender", item.getSender());
            jsonObject.put("type", item.getType());
            jsonObject.put("comment", item.getComment());

            jsonArray.put(jsonObject);
        }

        saveJsonFile("complain.json", jsonArray);
        } catch (Exception ex) {
            showErrorNotification(ex.getMessage());
        }
    }
}
