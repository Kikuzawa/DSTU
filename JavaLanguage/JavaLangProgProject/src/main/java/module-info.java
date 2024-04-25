module com.kiku.javalangprogproject {
    requires javafx.controls;
    requires javafx.fxml;
    requires javafx.graphics;
    requires javafx.base;

    requires mysql.connector.java;
    requires java.sql;
    requires javafx.media;
    requires java.desktop;
    requires org.apache.poi.ooxml;
    requires org.json;
    requires org.apache.pdfbox;
    requires itextpdf;
    requires javafx.web;


    opens com.kiku.javalangprogproject.Database to javafx.base;
    exports com.kiku.javalangprogproject.classes;
    opens com.kiku.javalangprogproject.classes to javafx.base, javafx.fxml;
    exports com.kiku.javalangprogproject;
    opens com.kiku.javalangprogproject to javafx.fxml;
    exports com.kiku.javalangprogproject.controllers;
    opens com.kiku.javalangprogproject.controllers to javafx.fxml;
    exports com.kiku.javalangprogproject.config;
    exports com.kiku.javalangprogproject.reportGenerators;
    opens com.kiku.javalangprogproject.reportGenerators to javafx.fxml;
    opens com.kiku.javalangprogproject.config to javafx.base, javafx.fxml;


}