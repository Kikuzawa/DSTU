package com.kiku.javalangprogproject.classes;

public class Shoe {

    // Класс "Обувь"
    int idShoe;
    String nameShoe;
    Double costShoe;
    String colorShoe;
    String stockShoe;
    String sizeShoe;
    String seasonShoe;
    String complection;


    public Shoe(int idShoe, String nameShoe, Double costShoe, String colorShoe, String stockShoe, String sizeShoe, String seasonShoe, String complection) {
        this.idShoe = idShoe;
        this.nameShoe = nameShoe;
        this.costShoe = costShoe;
        this.colorShoe = colorShoe;
        this.stockShoe = stockShoe;
        this.sizeShoe = sizeShoe;
        this.seasonShoe = seasonShoe;
        this.complection = complection;
    }

    public String getIdShoe() {
        return Integer.toString(idShoe);
    }


    public String getNameShoe() {
        return nameShoe;
    }


    public Double getCostShoe() {
        return costShoe;
    }


    public String getColorShoe() {
        return colorShoe;
    }


    public String getStockShoe() {
        return stockShoe;
    }


    public String getSizeShoe() {
        return sizeShoe;
    }


    public String getComplection() {
        return complection;
    }


    public String getSeasonShoe() {
        return seasonShoe;
    }


}
