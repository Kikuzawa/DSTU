package com.kiku.javalangprogproject.classes;

public class Tax {
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

    public void setIdTax(Integer idTax) {
        this.idTax = idTax;
    }

    public String getMonthTax() {
        return monthTax;
    }

    public void setMonthTax(String monthTax) {
        this.monthTax = monthTax;
    }

    public Integer getYearTax() {
        return yearTax;
    }

    public void setYearTax(Integer yearTax) {
        this.yearTax = yearTax;
    }

    public Double getTotalIncomeTax() {
        return totalIncomeTax;
    }

    public void setTotalIncomeTax(Double totalIncomeTax) {
        this.totalIncomeTax = totalIncomeTax;
    }

    public Double getTotalExpenseTax() {
        return totalExpenseTax;
    }

    public void setTotalExpenseTax(Double totalExpenseTax) {
        this.totalExpenseTax = totalExpenseTax;
    }

    public Double getProcentEarthTax() {
        return procentEarthTax;
    }

    public void setProcentEarthTax(Double procentEarthTax) {
        this.procentEarthTax = procentEarthTax;
    }

    public Double getHouseTax() {
        return HouseTax;
    }

    public void setHouseTax(Double houseTax) {
        HouseTax = houseTax;
    }

    public Double getNdsTax() {
        return NdsTax;
    }

    public void setNdsTax(Double ndsTax) {
        NdsTax = ndsTax;
    }

    public Double getBaseTax() {
        return baseTax;
    }

    public void setBaseTax(Double baseTax) {
        this.baseTax = baseTax;
    }

    public Double getTaxWithNDS() {
        return taxWithNDS;
    }

    public void setTaxWithNDS(Double taxWithNDS) {
        this.taxWithNDS = taxWithNDS;
    }

    public Double getTaxWithNdsAndHouse() {
        return taxWithNdsAndHouse;
    }

    public void setTaxWithNdsAndHouse(Double taxWithNdsAndHouse) {
        this.taxWithNdsAndHouse = taxWithNdsAndHouse;
    }

    public Double getFinalTax() {
        return finalTax;
    }

    public void setFinalTax(Double finalTax) {
        this.finalTax = finalTax;
    }

    public Double procentEarthTax;
    public Double HouseTax;
    public Double NdsTax;
    public Double baseTax;
    public Double taxWithNDS;
    public Double taxWithNdsAndHouse;
    public Double finalTax;
}
