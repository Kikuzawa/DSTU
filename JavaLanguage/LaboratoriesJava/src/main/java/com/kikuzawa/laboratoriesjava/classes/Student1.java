package com.kikuzawa.laboratoriesjava.classes;

import java.util.*;

public class Student1 {
    final String lastName;
    final String firstName;
    final String middleName;
    final int birthYear;
    final int course;
    public final String groupNumber;
    public final List<Integer> grades;

    public Student1(String lastName, String firstName, String middleName, int birthYear, int course, String groupNumber, List<Integer> grades) {
        this.lastName = lastName;
        this.firstName = firstName;
        this.middleName = middleName;
        this.birthYear = birthYear;
        this.course = course;
        this.groupNumber = groupNumber;
        this.grades = grades;
    }

    public double getAverageGrade() {
        return grades.stream().mapToDouble(Integer::doubleValue).average().orElse(0.0);
    }

    public String toString() {
        return lastName + " " + firstName + " " + middleName + " (Course: " + course + ", Group: " + groupNumber + ")";
    }

    public int getCourse() {
        return course;
    }

    public int getBirthYear() {
        return birthYear;
    }
}
