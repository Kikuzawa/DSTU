
package com.kiku.javalangprogproject.Database;

import java.io.FileInputStream;
import java.io.IOException;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.Statement;
import java.util.Properties;


//Класс для получения соединения с базой данных и проверки логина.
@SuppressWarnings("ALL")
public class ConnectionFactory {

    static final String driver = "com.mysql.cj.jdbc.Driver";
    static final String url = "jdbc:mysql://localhost:3306/inventory";
    static String username;
    static String password;

    Properties prop;

    Connection conn = null;
    Statement statement = null;
    ResultSet resultSet = null;


    public ConnectionFactory(){
        try {
            //Логин и пароль сохраняются как конфигурируемые свойства, чтобы избежать перекомпиляции.
            prop = new Properties();
            prop.loadFromXML(new FileInputStream("lib/DBCredentials.xml"));
        } catch (IOException e) {
            e.printStackTrace();
        }
        username = prop.getProperty("username");
        password = prop.getProperty("password");

        try {
            Class.forName(driver);
            conn = DriverManager.getConnection(url, username, password);
            statement = conn.createStatement();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }


    //* Этот код на Java определяет метод checkLogin, который выполняет запрос к базе данных
    // для проверки существования указанного username, password и userType в таблице users.
    // Если найдена соответствующая запись, возвращается true; в противном случае возвращается false.
    public boolean checkLogin(String username, String password, String userType){
        String query = "SELECT * FROM users WHERE username='"
                + username
                + "' AND password='"
                + password
                + "' AND usertype='"
                + userType
                + "' LIMIT 1";


        try {
            statement = conn.createStatement();
            resultSet = statement.executeQuery(query);
            if(resultSet.next()) return true;
        } catch (Exception ex) {
            ex.printStackTrace();
        }
        return false;
    }
}
