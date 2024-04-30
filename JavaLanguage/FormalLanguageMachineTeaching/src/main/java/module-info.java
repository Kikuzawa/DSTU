module com.kiku.formallanguagemachineteaching {
    requires javafx.controls;
    requires javafx.fxml;
    requires java.sql;


    opens com.kiku.formallanguagemachineteaching to javafx.fxml;
    exports com.kiku.formallanguagemachineteaching;
}