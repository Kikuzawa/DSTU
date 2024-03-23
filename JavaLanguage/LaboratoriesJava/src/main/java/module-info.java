module com.kikuzawa.laboratoriesjava {
    requires javafx.controls;
    requires javafx.fxml;
    requires javafx.graphics;

    opens com.kikuzawa.laboratoriesjava to javafx.fxml;
    exports com.kikuzawa.laboratoriesjava;
    exports com.kikuzawa.laboratoriesjava.classes;
    opens com.kikuzawa.laboratoriesjava.classes to javafx.fxml;
}