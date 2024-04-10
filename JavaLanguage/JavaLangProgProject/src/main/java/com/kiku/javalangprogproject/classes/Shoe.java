package com.kiku.javalangprogproject.classes;

public class Shoe {

    int id;
    String name;
    Double cost;
    String color;
    String stock;
    String size;
    String season;
    String complection;


    public Shoe(int id, String name, Double cost, String color, String stock, String size, String season, String complection) {
        this.id = id;
        this.name = name;
        this.cost = cost;
        this.color = color;
        this.stock = stock;
        this.size = size;
        this.season = season;
        this.complection = complection;
    }

    public String getId() {
        return Integer.toString(id);
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public Double getCost() {
        return cost;
    }

    public void setCost(Double cost) {
        this.cost = cost;
    }

    public String getColor() {
        return color;
    }

    public void setColor(String color) {
        this.color = color;
    }

    public String getStock() {
        return stock;
    }

    public void setStock(String stock) {
        this.stock = stock;
    }

    public String getSize() {
        return size;
    }

    public void setSize(String size) {
        this.size = size;
    }

    public String getComplection() {
        return complection;
    }

    public void setComplection(String complection) {
        this.complection = complection;
    }

    public String getSeason() {
        return season;
    }

    public void setSeason(String season) {
        this.season = season;
    }
}
