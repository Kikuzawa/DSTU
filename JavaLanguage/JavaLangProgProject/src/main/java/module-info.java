module com.kiku.javalangprogproject {
    requires javafx.controls;
    requires javafx.fxml;
    requires javafx.graphics;
    requires javafx.base;

    requires mysql.connector.java;
    requires java.sql;

    opens com.kiku.javalangprogproject to javafx.fxml;
    exports com.kiku.javalangprogproject;
    opens com.kiku.javalangprogproject.Database to javafx.base;

}