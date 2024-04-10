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

    public void setIdSupplier(int idSupplier) {
        this.idSupplier = idSupplier;
    }

    public String getNameSupplier() {
        return nameSupplier;
    }

    public void setNameSupplier(String nameSupplier) {
        this.nameSupplier = nameSupplier;
    }

    public String getLocationsSupplier() {
        return locationsSupplier;
    }

    public void setLocationsSupplier(String locationsSupplier) {
        this.locationsSupplier = locationsSupplier;
    }

    public String getStockSupplier() {
        return stockSupplier;
    }

    public void setStockSupplier(String stockSupplier) {
        this.stockSupplier = stockSupplier;
    }

    public String getNumberSupplier() {
        return numberSupplier;
    }

    public void setNumberSupplier(String numberSupplier) {
        this.numberSupplier = numberSupplier;
    }

    public String numberSupplier;

}
