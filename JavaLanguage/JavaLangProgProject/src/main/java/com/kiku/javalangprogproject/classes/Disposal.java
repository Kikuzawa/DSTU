package com.kiku.javalangprogproject.classes;

public class Disposal {

    public int idDisposal;
    public String nameDisposal;
    public String reasonDisposal;
    public double quantityDisposal;

    public double getCostDisposal() {
        return costDisposal;
    }

    public void setCostDisposal(double costDisposal) {
        this.costDisposal = costDisposal;
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
    public void setIdDisposal(int idDisposal) {
        this.idDisposal = idDisposal;
    }

    public String getNameDisposal() {
        return nameDisposal;
    }

    public void setNameDisposal(String nameDisposal) {
        this.nameDisposal = nameDisposal;
    }

    public String getReasonDisposal() {
        return reasonDisposal;
    }

    public void setReasonDisposal(String reasonDisposal) {
        this.reasonDisposal = reasonDisposal;
    }

    public double getQuantityDisposal() {
        return quantityDisposal;
    }

    public void setQuantityDisposal(double quantityDisposal) {
        this.quantityDisposal = quantityDisposal;
    }

    public double getTotalDisposal() {
        return totalDisposal;
    }

    public void setTotalDisposal(double totalDisposal) {
        this.totalDisposal = totalDisposal;
    }

    public double totalDisposal;



}
