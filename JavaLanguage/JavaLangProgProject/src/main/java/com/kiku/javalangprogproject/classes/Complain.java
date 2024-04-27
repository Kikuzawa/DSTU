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



    public String getSender() {
        return sender;
    }



    public String getType() {
        return type;
    }


    public String getComment() {
        return comment;
    }


    String comment;
}
