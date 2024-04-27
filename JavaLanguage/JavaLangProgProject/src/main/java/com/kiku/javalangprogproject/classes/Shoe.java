package com.kiku.javalangprogproject.classes;

public class Shoe {

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

    public void setIdShoe(int idShoe) {
        this.idShoe = idShoe;
    }

    public String getNameShoe() {
        return nameShoe;
    }

    public void setNameShoe(String nameShoe) {
        this.nameShoe = nameShoe;
    }

    public Double getCostShoe() {
        return costShoe;
    }

    public void setCostShoe(Double costShoe) {
        this.costShoe = costShoe;
    }

    public String getColorShoe() {
        return colorShoe;
    }

    public void setColorShoe(String colorShoe) {
        this.colorShoe = colorShoe;
    }

    public String getStockShoe() {
        return stockShoe;
    }

    public void setStockShoe(String stockShoe) {
        this.stockShoe = stockShoe;
    }

    public String getSizeShoe() {
        return sizeShoe;
    }

    public void setSizeShoe(String sizeShoe) {
        this.sizeShoe = sizeShoe;
    }

    public String getComplection() {
        return complection;
    }

    public void setComplection(String complection) {
        this.complection = complection;
    }

    public String getSeasonShoe() {
        return seasonShoe;
    }

    public void setSeasonShoe(String seasonShoe) {
        this.seasonShoe = seasonShoe;
    }
}
