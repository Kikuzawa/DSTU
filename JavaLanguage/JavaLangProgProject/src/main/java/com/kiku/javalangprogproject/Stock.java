package com.kiku.javalangprogproject;

public class Stock {

    public int idStock;

    public int getTotalStock() {
        return totalStock;
    }

    public void setTotalStock(int totalStock) {
        this.totalStock = totalStock;
    }

    public int totalStock;



    public Stock(int idStock, String nameStock, int quantityStock, int costStock, int total) {
        this.idStock = idStock;
        this.nameStock = nameStock;
        this.quantityStock = quantityStock;
        this.costStock = costStock;
        this.totalStock = quantityStock * costStock;
    }

    public int getIdStock() {
        return idStock;
    }

    public void setIdStock(int idStock) {
        this.idStock = idStock;
    }

    public String getNameStock() {
        return nameStock;
    }

    public void setNameStock(String nameStock) {
        this.nameStock = nameStock;
    }

    public int getQuantityStock() {
        return quantityStock;
    }

    public void setQuantityStock(int quantityStock) {
        this.quantityStock = quantityStock;
    }

    public int getCostStock() {
        return costStock;
    }

    public void setCostStock(int costStock) {
        this.costStock = costStock;
    }

    public String nameStock;
    public int quantityStock;
    public int costStock;


}