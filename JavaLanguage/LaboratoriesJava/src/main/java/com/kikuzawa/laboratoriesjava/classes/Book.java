package com.kikuzawa.laboratoriesjava.classes;


public record Book(String title) implements Comparable<Book> {

    @Override
    public int compareTo(Book other) {
        return this.title.compareTo(other.title());
    }
}