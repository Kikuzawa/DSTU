package com.kiku.javalangprogproject.classes;

public class Supplier {

    public int idSupplier;
    public String nameSupplier;
    public String locationsSupplier;

    public Supplier(int idSupplier, String nameSupplier, String numberSupplier,String locationsSupplier, String stockSupplier) {
        this.idSupplier = idSupplier;
        this.nameSupplier = nameSupplier;
        this.numberSupplier = numberSupplier;
        this.locationsSupplier = locationsSupplier;
        this.stockSupplier = stockSupplier;

    }

    public String stockSupplier;

    public String getIdSupplier() {
        return String.valueOf(idSupplier);
    }


    public String getNameSupplier() {
        return nameSupplier;
    }


    public String getLocationsSupplier() {
        return locationsSupplier;
    }


    public String getStockSupplier() {
        return stockSupplier;
    }


    public String getNumberSupplier() {
        return numberSupplier;
    }


    public String numberSupplier;

}
