package com.kiku.javalangprogproject.classes;

public class Disposal {

    // Класс "Утилизация"

    public int idDisposal;
    public String nameDisposal;
    public String reasonDisposal;
    public double quantityDisposal;

    public double getCostDisposal() {
        return costDisposal;
    }


    public double costDisposal;


    public int getIdDisposal() {
        return idDisposal;
    }

    public Disposal(int idDisposal, String nameDisposal, String reasonDisposal, double quantityDisposal, double costDisposal, double totalDisposal) {
        this.idDisposal = idDisposal;
        this.nameDisposal = nameDisposal;
        this.reasonDisposal = reasonDisposal;
        this.quantityDisposal = quantityDisposal;
        this.costDisposal = costDisposal;
        this.totalDisposal = totalDisposal;
    }

    public String getString(){
        return idDisposal + ' ' + nameDisposal + ' ' + reasonDisposal + ' ' + quantityDisposal + ' ' + costDisposal + ' ' + totalDisposal;
    }

    public String getNameDisposal() {
        return nameDisposal;
    }


    public String getReasonDisposal() {
        return reasonDisposal;
    }


    public double getQuantityDisposal() {
        return quantityDisposal;
    }


    public double getTotalDisposal() {
        return totalDisposal;
    }


    public double totalDisposal;



}
