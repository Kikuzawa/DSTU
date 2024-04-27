package com.kiku.javalangprogproject.Utils;

import javafx.beans.value.ObservableValue;
import javafx.collections.transformation.FilteredList;
import javafx.collections.transformation.SortedList;
import javafx.scene.control.TableColumn;
import javafx.scene.control.TableView;
import javafx.scene.control.TextField;

import static com.kiku.javalangprogproject.Utils.NotificationUtils.showErrorNotification;

public class TableSearchUtil {
    public static <T> void setupSearch(TableView<T> tableView, TextField searchField) {
        try {
            FilteredList<T> filteredData = new FilteredList<>(tableView.getItems(), b -> true);

            searchField.textProperty().addListener((observable, oldValue, newValue) -> filteredData.setPredicate(item -> {
                if (newValue == null || newValue.isEmpty()) {
                    return true;
                }
                String lowerCaseFilter = newValue.toLowerCase();

                for (TableColumn<T, ?> column : tableView.getColumns()) {
                    ObservableValue<?> cellValue = column.getCellObservableValue(item);
                    if (cellValue != null && cellValue.getValue() != null &&
                            cellValue.getValue().toString().toLowerCase().contains(lowerCaseFilter)) {
                        return true;
                    }
                }
                return false;
            }));

            SortedList<T> sortedData = new SortedList<>(filteredData);
            sortedData.comparatorProperty().bind(tableView.comparatorProperty());
            tableView.setItems(sortedData);
        } catch (Exception ex) {
            showErrorNotification(ex.getMessage());
        }
    }
}