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

def range_every_two_odd(data): # Из выборки ряда оставляется каждый второй элемент
    data = [x for i, x in enumerate(data) if i % 2 != 0]
    return data

def range_every_four_odd(data): # Из выборки ряда оставляется каждый через 4 элемента, начиная с первого
    data = [data[i] for i in range(0, len(data), 5)]
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

print("Задание 1")

general1 = initialize_data()
variation_range1 = variation_range(general1)
mean1 = calculate_mean(variation_range1)
dispersion1 = calculate_dispersion(variation_range1, mean1)
standard_deviation1 = calculate_standard_deviation(dispersion1)

print("Генеральная совокупность: {}".format(general1))
print('Вариационный ряд Г.С.: {}'.format(variation_range1))
print('Среднее значение Г.С.: {}'.format(mean1))
print('Дисперсия Г.С.: {}'.format(dispersion1))
print('Среднее квадратичное отклонение Г.С.: {}'.format(standard_deviation1))

plot_frequency_polygon(variation_range1)
plot_histogram(variation_range1)


print("\nЗадание 2")

general2 = initialize_data()
selection2 = range_every_two_odd(general2)
variation_range2 = variation_range(selection2)
mean2 = calculate_mean(variation_range2)
dispersion2 = calculate_dispersion(variation_range2, mean2)
correct_dispersion2 = calculate_correct_dispersion(dispersion2, selection2)
standard_deviation2 = calculate_standard_deviation(dispersion2)
correct_standard_deviation2 = calculate_standard_deviation(correct_dispersion2)

print("Выборка из Генеральной Совокупности: {}".format(selection2))
print('Вариационный ряд выборки: {}'.format(variation_range2))
print('Среднее значение выборки: {}'.format(mean2))
print('Дисперсия выборки: {}'.format(dispersion2))
print('Дисперсия исправленная: {}'.format(correct_dispersion2))
print('Среднее квадратичное отклонение выборки: {}'.format(standard_deviation2))
print('Среднее квадратичное отклонение исправленное: {}'.format(correct_standard_deviation2))

plot_histogram(variation_range2)

print("\nЗадание 3")

general3 = initialize_data()
selection3 = range_every_four_odd(general3)
variation_range3 = variation_range(selection3)
mean3 = calculate_mean(variation_range3)
dispersion3 = calculate_dispersion(variation_range3, mean3)
correct_dispersion3 = calculate_correct_dispersion(dispersion3, selection3)
standard_deviation3 = calculate_standard_deviation(dispersion3)
correct_standard_deviation3 = calculate_standard_deviation(correct_dispersion3)

print("Выборка из Генеральной Совокупности: {}".format(selection3))
print('Вариационный ряд выборки: {}'.format(variation_range3))
print('Среднее значение выборки: {}'.format(mean3))
print('Дисперсия выборки: {}'.format(dispersion3))
print('Дисперсия исправленная: {}'.format(correct_dispersion3))
print('Среднее квадратичное отклонение выборки: {}'.format(standard_deviation3))
print('Среднее квадратичное отклонение исправленное: {}'.format(correct_standard_deviation3))

plot_frequency_polygon(variation_range3)



