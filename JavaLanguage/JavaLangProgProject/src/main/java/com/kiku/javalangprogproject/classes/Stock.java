package com.kiku.javalangprogproject.classes;

public class Stock {

    // Класс "Сырье"

    public int idStock;

    public double getTotalStock() {
        return totalStock;
    }


    public double totalStock;



    public Stock(int idStock, String nameStock, int quantityStock, int costStock) {
        this.idStock = idStock;
        this.nameStock = nameStock;
        this.quantityStock = quantityStock;
        this.costStock = costStock;
        this.totalStock = quantityStock * costStock;
    }

    public int getIdStock() {
        return idStock;
    }


    public String getNameStock() {
        return nameStock;
    }


    public double getQuantityStock() {
        return quantityStock;
    }


    public double getCostStock() {
        return costStock;
    }


    public String nameStock;
    public double quantityStock;
    public double costStock;


}
