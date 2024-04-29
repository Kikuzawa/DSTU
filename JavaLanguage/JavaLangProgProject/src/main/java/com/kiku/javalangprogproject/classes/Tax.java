package com.kiku.javalangprogproject.classes;



public class Tax {

    // Класс "Налоги"
    public Integer idTax;
    public String monthTax;
    public Integer yearTax;
    public Double totalIncomeTax;
    public Double CostHouse = 1000000.0;
    public Double CostEarth = 7000000.0;

    public Tax(int idTax, String monthTax, Integer yearTax, Double totalIncomeTax, Double totalExpenseTax, Double procentEarthTax, Double houseTax, Double ndsTax) {
        this.idTax = idTax;
        this.monthTax = monthTax;
        this.yearTax = yearTax;
        this.totalIncomeTax = totalIncomeTax * 1.0;
        this.totalExpenseTax = totalExpenseTax * 1.0;
        this.procentEarthTax = procentEarthTax * 1.0;
        this.HouseTax = houseTax;
        this.NdsTax = ndsTax;
        this.baseTax = totalIncomeTax - totalExpenseTax;
        this.taxWithNDS = baseTax + NdsTax * baseTax / 100.0;
        this.taxWithNdsAndHouse = taxWithNDS + HouseTax * CostHouse / 100.0;
        this.finalTax = taxWithNdsAndHouse + CostEarth * procentEarthTax / 100.0;
        
    }

    public Double totalExpenseTax;

    public Integer getIdTax() {
        return idTax;
    }


    public String getMonthTax() {
        return monthTax;
    }


    public Integer getYearTax() {
        return yearTax;
    }


    public Double getTotalIncomeTax() {
        return totalIncomeTax;
    }


    public Double getTotalExpenseTax() {
        return totalExpenseTax;
    }


    public Double getProcentEarthTax() {
        return procentEarthTax;
    }


    public Double getHouseTax() {
        return HouseTax;
    }


    public Double getNdsTax() {
        return NdsTax;
    }


    public Double getBaseTax() {
        return baseTax;
    }


    public Double getTaxWithNDS() {
        return taxWithNDS;
    }


    public Double getTaxWithNdsAndHouse() {
        return taxWithNdsAndHouse;
    }


    public Double getFinalTax() {
        return finalTax;
    }


    public Double procentEarthTax;
    public Double HouseTax;
    public Double NdsTax;
    public Double baseTax;
    public Double taxWithNDS;
    public Double taxWithNdsAndHouse;
    public Double finalTax;
}
