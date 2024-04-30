package com.kiku.formallanguagemachineteaching;

public class Message {
    String message;
    String status;


    public Message(String message, String status) {
        this.message = message;
        this.status = status;
    }

    public String getMessage() {
        return message;
    }

    public String getStatus() {
        return status;
    }

}
