package com.kiku.javalangprogproject;

public class Shop {

    public int idShop;
    public String nameShop;
    public String locationsShop;
    public String emailShop;

    public Shop(int idShop, String nameShop, String locationsShop, String emailShop, String numberShop, String fioShop) {
        this.idShop = idShop;
        this.nameShop = nameShop;
        this.locationsShop = locationsShop;
        this.emailShop = emailShop;
        this.numberShop = numberShop;
        this.fioShop = fioShop;
    }

    public String numberShop;
    public String fioShop;

    public String getIdShop() {
        return Integer.toString(idShop);
    }

    public void setIdShop(int idShop) {
        this.idShop = idShop;
    }

    public String getNameShop() {
        return nameShop;
    }

    public void setNameShop(String nameShop) {
        this.nameShop = nameShop;
    }

    public String getLocationsShop() {
        return locationsShop;
    }

    public void setLocationsShop(String locationsShop) {
        this.locationsShop = locationsShop;
    }

    public String getEmailShop() {
        return emailShop;
    }

    public void setEmailShop(String emailShop) {
        this.emailShop = emailShop;
    }

    public String getNumberShop() {
        return numberShop;
    }

    public void setNumberShop(String numberShop) {
        this.numberShop = numberShop;
    }

    public String getFioShop() {
        return fioShop;
    }

    public void setFioShop(String fioShop) {
        this.fioShop = fioShop;
    }
}
