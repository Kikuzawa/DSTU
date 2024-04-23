package com.kiku.javalangprogproject;

import com.kiku.javalangprogproject.classes.*;
import javafx.collections.ObservableList;
import javafx.scene.control.TableView;
import org.json.JSONArray;
import org.json.JSONObject;

import java.io.File;
import java.io.FileWriter;
import java.io.IOException;

public class CreateJsonFromTable {


    private static String basePath;

    public static void jsonCreateShoe(TableView<Shoe> shoesTable) {

        ObservableList<Shoe> data = shoesTable.getItems();

        JSONArray jsonArray = new JSONArray();
        for (Shoe item : data) {
            JSONObject jsonObject = new JSONObject();
            jsonObject.put("id", item.getId());
            jsonObject.put("name", item.getName());
            jsonObject.put("cost", item.getCost().toString());
            jsonObject.put("color", item.getColor());
            jsonObject.put("stock", item.getStock());
            jsonObject.put("size", item.getSize());
            jsonObject.put("season", item.getSeason());
            jsonObject.put("complection", item.getComplection());
            jsonArray.put(jsonObject);
        }

        saveJsonFile("shoes.json", jsonArray);
    }

    public static void jsonCreateShops(TableView<Shop> shopsTable) {

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

    }

    public static void jsonCreateSuppliers(TableView<Supplier> suppliersTable) {

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

    }

    public static void jsonCreateDisposal(TableView<Disposal> disposalTable) {

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
    }

    public static void jsonCreateStock(TableView<Stock> stockTable){

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
    }


    private static void saveJsonFile(String name, JSONArray jsonArray) {
        String basePath = name;
        try {
            try (FileWriter file = new FileWriter(name)) {
                file.write("[");
                for (int i = 0; i < jsonArray.length(); i++) {
                    file.write(jsonArray.getJSONObject(i).toString());
                    if (i < jsonArray.length() - 1) {
                        file.write(",");
                    }
                }
                file.write("]");
            }
        } catch (IOException e) {
            throw new RuntimeException(e);
        }

    }

}
