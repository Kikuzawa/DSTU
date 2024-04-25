package com.kiku.javalangprogproject.classes;

public class Complain {
    Integer id;

    public Complain(Integer id, String number, String sender, String type, String comment) {
        this.id = id;
        this.number = number;
        this.sender = sender;
        this.type = type;
        this.comment = comment;
    }

    String number;
    String sender;
    String type;

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public String getNumber() {
        return number;
    }

    public void setNumber(String number) {
        this.number = number;
    }

    public String getSender() {
        return sender;
    }

    public void setSender(String sender) {
        this.sender = sender;
    }

    public String getType() {
        return type;
    }

    public void setType(String type) {
        this.type = type;
    }

    public String getComment() {
        return comment;
    }

    public void setComment(String comment) {
        this.comment = comment;
    }

    String comment;
}
