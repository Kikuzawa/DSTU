import numpy as np

matrix = np.array(
    [
        [1, 2, 3, 4, 5, 6, 7, 8],
        [8, 7, 6, 5, 4, 3, 2, 1],
        [2, 3, 4, 5, 6, 7, 8, 9],
        [9, 8, 7, 6, 5, 4, 3, 2],
        [1, 3, 5, 7, 9, 7, 5, 3],
        [3, 1, 5, 3, 2, 6, 5, 7],
        [1, 7, 5, 9, 7, 3, 1, 5],
        [2, 6, 3, 5, 1, 7, 3, 2]],
    dtype=np.uint8)


# noinspection PyShadowingNames
def lab10_1(matrix):
    matrix = np.where(matrix < 5, np.square(matrix), matrix)
    return str(matrix)


# noinspection PyShadowingNames
def lab10_2(matrix):
    masked_array = np.where(matrix % 2 == 0, matrix, 0)  # заменяем нечетные элементы на 0
    sum_of_evens = np.sum(masked_array, axis=1)  # суммируем по строкам

    return str(sum_of_evens)


# noinspection PyShadowingNames
def lab10_3(matrix):
    masked_array = np.where(matrix % 2 == 0, matrix, 0)  # заменяем нечетные элементы на 0
    sum_of_evens = np.sum(masked_array, axis=0)  # суммируем по строкам

    return str(sum_of_evens)


# noinspection PyShadowingNames
def lab10_4(matrix):
    sum_less_than_5 = np.sum(matrix[matrix < 5])
    sum_greater_or_equal_5 = np.sum(matrix[matrix >= 5])

    if sum_less_than_5 > sum_greater_or_equal_5:
        return f"Сумма элементов меньше 5 больше ->\n{sum_less_than_5} > {sum_greater_or_equal_5}"
    elif sum_less_than_5 < sum_greater_or_equal_5:
        return f"Сумма элементов больше или равных 5 больше ->\n{sum_less_than_5} < {sum_greater_or_equal_5}"
    else:
        return f"Суммы равны ->\n{sum_less_than_5} = {sum_greater_or_equal_5}"


# noinspection PyShadowingNames
def lab10_5(matrix):
    matrix = np.where(matrix == 5, np.square(matrix), matrix)
    return str(matrix)


# noinspection PyShadowingNames
def lab10_6(matrix):
    clean_matrix = np.zeros_like(matrix)
    return str(clean_matrix)


# noinspection PyShadowingNames
def lab10_7(matrix):
    count = np.count_nonzero(matrix == 3)
    return str(count)


# noinspection PyShadowingNames,PyBroadException
def lab10_8(matrix, column_number):
    try:
        column_number = int(column_number)
        if column_number > 0:
            column_sum = np.sum(matrix[:, column_number - 1])
            return str(column_sum)
        else:
            return "Введите целое число от 1 до 8!"
    except:
        return "Введите целое число от 1 до 8!"
