package com.kiku.javalangprogproject.classes;

public class Stock {

    public int idStock;

    public double getTotalStock() {
        return totalStock;
    }

    public void setTotalStock(int totalStock) {
        this.totalStock = totalStock;
    }

    public double totalStock;



    public Stock(int idStock, String nameStock, int quantityStock, int costStock, double total) {
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

    public double getQuantityStock() {
        return quantityStock;
    }

    public void setQuantityStock(int quantityStock) {
        this.quantityStock = quantityStock;
    }

    public double getCostStock() {
        return costStock;
    }

    public void setCostStock(int costStock) {
        this.costStock = costStock;
    }

    public String nameStock;
    public double quantityStock;
    public double costStock;


}
