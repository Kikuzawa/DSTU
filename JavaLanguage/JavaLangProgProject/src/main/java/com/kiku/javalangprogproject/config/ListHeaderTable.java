package com.kiku.javalangprogproject.config;


public class ListHeaderTable {
    public static final String[] ASSORTIMENT = {"id", "name", "cost", "color", "stock", "size", "season", "complection"};
    public static final String[] SHOPS = {"id", "name", "location", "email", "number", "fio"};
    public static final String[] SUPPLIERS = {"id", "name", "number", "location", "stock"};
    public static final String[] DISPOSAL = {"id", "name", "reason", "quantity", "total", "cost"};
    public static final String[] STOCK = {"id", "name", "quantity", "cost", "total"};

    public static final String[] TAX = {"id", "month", "year", "totalIncome", "totalExpense", "procentEarthTax", "procentHouseTax", "NDS", "baseTax", "taxWithNDS", "taxWithNdsAndHouse", "finalTax"};


    public static final String[] COMPLAIN = {"id", "number", "sender", "type", "comment"};
}
