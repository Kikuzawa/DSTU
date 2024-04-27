package com.kiku.javalangprogproject.classes;

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


    public String getNameShop() {
        return nameShop;
    }


    public String getLocationsShop() {
        return locationsShop;
    }


    public String getEmailShop() {
        return emailShop;
    }



    public String getNumberShop() {
        return numberShop;
    }


    public String getFioShop() {
        return fioShop;
    }


}
