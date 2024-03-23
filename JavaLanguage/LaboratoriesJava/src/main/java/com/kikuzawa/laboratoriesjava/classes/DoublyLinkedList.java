package com.kikuzawa.laboratoriesjava.classes;

import java.util.HashSet;
// класс двусвязных списков
public class DoublyLinkedList {
    @SuppressWarnings("InnerClassMayBeStatic")
    private class Node {
        int data;
        Node prev;
        Node next;

        public Node(int data) {
            this.data = data;
        }
    }

    private Node head;
    private Node tail;
    private int size;

    public void clone(DoublyLinkedList original){
        this.head = original.head;
        this.tail = original.tail;
        this.size = original.size;
    }

    // Инициализация списка
    public DoublyLinkedList() {
        head = null;
        tail = null;
        size = 0;
    }

    // Добавление элемента в начало списка
    public void addToFront(int data) {
        Node newNode = new Node(data);
        if (head == null) {
            head = newNode;
            tail = newNode;
        } else {
            head.prev = newNode;
            newNode.next = head;
            head = newNode;
        }
        size++;
    }

    // Добавление элемента в конец списка
    public void addToEnd(int data) {
        Node newNode = new Node(data);
        if (tail == null) {
            head = newNode;
        } else {
            tail.next = newNode;
            newNode.prev = tail;
        }
        tail = newNode;
        size++;
    }

    // Показ всех элементов списка
    public String display() {
        Node current = head;
        StringBuilder result = new StringBuilder();
        while (current != null) {
            result.append(current.data).append(" ");
            current = current.next;
        }
        return result.toString();
    }

    // Удаление всех элементов списка
    public void clear() {
        head = null;
        tail = null;
        size = 0;
    }

    // Определение количества элементов списка
    public int getSize() {
        return size;
    }

    // Проверка списка на пустоту
    public boolean isEmpty() {
        return size == 0;
    }

    // Удаление первого элемента
    public void removeFirst() {
        if (size == 0) {
            return;
        }
        head = head.next;
        if (head == null) {
            tail = null;
        } else {
            head.prev = null;
        }
        size--;
    }

    // Удаление последнего элемента
    public void removeLast() {
        if (size == 0) {
            return;
        }
        tail = tail.prev;
        if (tail == null) {
            head = null;
        } else {
            tail.next = null;
        }
        size--;
    }

    // Поиск данного значения в списке
    public boolean contains(int data) {
        Node current = head;
        while (current != null) {
            if (current.data == data) {
                return true;
            }
            current = current.next;
        }
        return false;
    }

    // Поиск наибольшего и наименьшего значений в списке
    public int findMin() {
        if (size == 0) {
            return Integer.MIN_VALUE;
        }
        int min = head.data;
        Node current = head.next;
        while (current != null) {
            if (current.data < min) {
                min = current.data;
            }
            current = current.next;
        }
        return min;
    }

    public int findMax() {
        if (size == 0) {
            return Integer.MAX_VALUE;
        }
        int max = head.data;
        Node current = head.next;
        while (current != null) {
            if (current.data > max) {
                max = current.data;
            }
            current = current.next;
        }
        return max;
    }

    // Удаление элемента списка с данным значением
    public void remove(int data) {
        Node current = head;
        while (current != null) {
            if (current.data == data) {
                if (current == head) {
                    removeFirst();
                } else if (current == tail) {
                    removeLast();
                } else {
                    current.prev.next = current.next;
                    current.next.prev = current.prev;
                    size--;
                }
                return;
            }
            current = current.next;
        }
    }

    // Удаление всех элементов списка с данным значением
    public void removeAll(int data) {
        Node current = head;
        while (current != null) {
            Node toDelete = current;
            current = current.next;
            if (toDelete.data == data) {
                if (toDelete == head) {
                    removeFirst();
                } else if (toDelete == tail) {
                    removeLast();
                } else {
                    toDelete.prev.next = toDelete.next;
                    toDelete.next.prev = toDelete.prev;
                    size--;
                }
            }
        }
    }

    // Изменение всех элементов списка с данным значением на новое
    public void replace(int oldValue, int newValue) {
        Node current = head;
        while (current != null) {
            if (current.data == oldValue) {
                current.data = newValue;
            }
            current = current.next;
        }
    }

    // Определение, является ли список симметричным
    public boolean isSymmetric() {
        Node front = head;
        Node back = tail;
        while (front != null && back != null) {
            if (front.data != back.data) {
                return false;
            }
            front = front.next;
            back = back.prev;
        }
        return true;
    }

    // Определение, можно ли удалить из списка каких-нибудь два элемента так, чтобы новый список оказался упорядоченным
    public boolean canRemoveTwoElementsToMakeSorted() {
        if (size < 3) {
            return true;
        }
        Node current = head;
        while (current != null && current.next != null) {
            if (current.data > current.next.data) {
                Node nextNext = current.next.next;
                if ((current.prev == null || current.prev.data <= current.next.data) &&
                        (nextNext == null || current.data <= nextNext.data)) {
                    return true;
                }
                if ((current.prev == null || current.prev.data <= nextNext.data) && current.next.data <= nextNext.data) {
                    return true;
                }
            }
            current = current.next;
        }
        return false;
    }

    // Определение, сколько различных значений содержится в списке
    public int countUniqueValues() {
        HashSet<Integer> uniqueValues = new HashSet<>();
        Node current = head;
        while (current != null) {
            uniqueValues.add(current.data);
            current = current.next;
        }
        return uniqueValues.size();
    }

    // Удаление из списка элементов, значения которых уже встречались в предыдущих элементах
    public void removeDuplicates() {
        HashSet<Integer> seenValues = new HashSet<>();
        Node current = head;
        while (current != null) {
            if (seenValues.contains(current.data)) {
                Node toDelete = current;
                current = current.next;
                if (toDelete == head) {
                    removeFirst();
                } else if (toDelete == tail) {
                    removeLast();
                } else {
                    toDelete.prev.next = toDelete.next;
                    toDelete.next.prev = toDelete.prev;
                    size--;
                }
            } else {
                seenValues.add(current.data);
                current = current.next;
            }
        }
    }

    // Изменение порядка элементов на обратный
    public void reverse() {
        Node current = head;
        Node temp = null;
        while (current != null) {
            temp = current.prev;
            current.prev = current.next;
            current.next = temp;
            current = current.prev;
        }
        if (temp != null) {
            head = temp.prev;
        }
    }

    // Сортировка элементов списка двумя способами (изменение указателей, изменение значений элементов)

    // Сортировка путем изменения указателей
    public void sortLinkedListByPointers() {
        Node current, index;
        int temp;
        if (head == null) {
        } else {
            for (current = head; current != null; current = current.next) {
                for (index = current.next; index != null; index = index.next) {
                    if (current.data > index.data) {
                        temp = current.data;
                        current.data = index.data;
                        index.data = temp;
                    }
                }
            }
        }
    }

    // Сортировка путем изменения значений элементов
    public void sortLinkedListByValues() {
        int[] arr = new int[size];
        Node current = head;
        int index = 0;
        while (current != null) {
            arr[index] = current.data;
            current = current.next;
            index++;
        }
        for (int i = 0; i < size; i++) {
            for (int j = i + 1; j < size; j++) {
                if (arr[i] > arr[j]) {
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }
        }
        current = head;
        index = 0;
        while (current != null) {
            current.data = arr[index];
            current = current.next;
            index++;
        }
    }
}