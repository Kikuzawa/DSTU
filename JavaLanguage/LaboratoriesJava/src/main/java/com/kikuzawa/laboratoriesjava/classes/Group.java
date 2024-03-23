package com.kikuzawa.laboratoriesjava.classes;

import java.util.LinkedList;
// класс Group -> лабораторная 4
public class Group {
    final String groupName;
    final LinkedList<Student> students;

    public Group(String groupName) {
        this.groupName = groupName;
        this.students = new LinkedList<>();
    }

    public void addStudent(Student student) {
        students.add(student);
    }

    @Override
    public String toString() {
        return "Group{" +
                "groupName='" + groupName + '\'' +
                ", students=" + students +
                '}';
    }
}
