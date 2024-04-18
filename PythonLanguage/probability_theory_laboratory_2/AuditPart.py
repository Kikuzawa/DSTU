from math import sqrt

import numpy as np
from scipy.interpolate import interp1d
import matplotlib.pyplot as plt


def calculate_mean(data): # Среднее арифметическое из выборки ряда
    sum = 0
    for i in range(len(data)):
        sum = sum + float(data[i])
    return sum / len(data)

def calculate_dispersion(data, mean): # Дисперсия из выборки ряда
    sum = 0
    for i in range(len(data)):
        sum = sum + pow((float(data[i]) - mean), 2)
    return sum / len(data)

def calculate_correct_dispersion(dispersion, data): # Исправленная дисперсия
    return dispersion * (len(data) / (len(data) - 1))

def calculate_standard_deviation(dispersion): # Стандартное отклонение
    return sqrt(dispersion)

def variation_range(data): # Вариационный ряд
    variation_range = data.copy()
    variation_range.sort()
    return variation_range

def range_every_four_odd(data): # Из выборки ряда оставляется каждый через 4 элемента, начиная с первого
    data = [data[i] for i in range(1, len(data), 4)]
    return data



def plot_frequency_polygon(data): # Печать полигона частот
    data_counts = {}
    for value in data:
        if value in data_counts:
            data_counts[value] += 1
        else:
            data_counts[value] = 1

    values = sorted(data_counts.keys())
    frequencies = [data_counts[value] for value in values]  # Update frequencies to display count

    plt.figure(figsize=(10, 6))
    plt.plot(values, frequencies, linestyle='-')  # Plot values against frequencies
    plt.xlabel('Значения выборки')
    plt.ylabel('Количество совпадений')
    plt.title('Полигон частот')
    plt.grid(True)

    plt.show()

def plot_histogram(data): # Печать гистограммы
    plt.hist(data, bins=25)
    plt.xlabel('Значения выборки')
    plt.ylabel('Высота')
    plt.title('Гистограмма (25 отрезков)')
    plt.grid(True)
    plt.show()

def initialize_data(): # Инициализация данных из файла
    p = open('test_statistics.txt')
    q = p.read().split('\n')
    data = []
    for i in range(len(q)):
        data.append(round(float(q[i]), 3))
    return data


general = initialize_data()
selection = range_every_four_odd(general)
variation_range = variation_range(selection)
mean = calculate_mean(variation_range)
dispersion = calculate_dispersion(variation_range, mean)
correct_dispersion = calculate_correct_dispersion(dispersion, selection)
standard_deviation = calculate_standard_deviation(dispersion)
correct_standard_deviation = calculate_standard_deviation(correct_dispersion)

print("Выборка из Генеральной Совокупности: {}".format(selection))
print('Вариационный ряд выборки: {}'.format(variation_range))
print('Среднее значение выборки: {}'.format(mean))
print('Дисперсия выборки: {}'.format(dispersion))
print('Дисперсия исправленная: {}'.format(correct_dispersion))
print('Среднее квадратичное отклонение выборки: {}'.format(standard_deviation))
print('Среднее квадратичное отклонение исправленное: {}'.format(correct_standard_deviation))

# Здесь не обязательно выводить полигон частот и гистограмму
plot_frequency_polygon(variation_range)
plot_histogram(variation_range)

print("n = ", len(selection))

