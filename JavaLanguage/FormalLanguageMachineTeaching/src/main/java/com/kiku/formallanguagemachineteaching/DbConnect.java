package com.kiku.formallanguagemachineteaching;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.util.logging.Level;
import java.util.logging.Logger;

public class DbConnect {
    private static Connection connection;


    // Создание соединения к базе данных
    public static Connection getConnect (){
        try {
            String password = "root";
            String user = "root";
            String DB_NAME = "baiesfl";
            int PORT = 3306;
            String HOST = "127.0.0.1";
            connection = DriverManager.getConnection(String.format("jdbc:mysql://%s:%d/%s", HOST, PORT, DB_NAME), user, password);
        } catch (SQLException ex) {
            Logger.getLogger(DbConnect.class.getName()).log(Level.SEVERE, null, ex);
        }

        return connection;
    }
}
