import random
import numpy as np
import pandas as pd


# noinspection PyBroadException
def lab4_1(text):
    try:
        N = int(text)

        cols = []
        for i in range(N):
            sis = f'[{i+1}]'
            cols.append(str(sis))

        matrix = np.zeros((N, N))
        for i in range(N):
            for j in range(N):
                matrix[i][j] = int(random.randint(0, 100))

        df = pd.DataFrame(matrix, columns=cols, index=cols)

        matrix_list = [int(element) for row in matrix for element in row]
        sum_result = sum(matrix_list)

        return f"Случайная матрица:\n" \
               f"{df}\n" \
               f"Матрица в виде списка: {matrix_list}\n" \
               f"Сумма всех значений элементов матрицы: {sum_result}"
    except:
        return 'Введите размер (целое число) квадратной матрицы N'


# noinspection PyBroadException
def lab4_2(text):
    try:
        a, b = map(int, text.split())
        my_list = [110, 29, 38, 47, 56, 65, 74, 83, 92, 101]
        spis = my_list
        print('Исходный список: ', my_list)
        del my_list[3:8]
        my_list.extend([a, b])
        print('Обновленный список:', my_list)
        return f"Введены числа a={a} и b={b}\n" \
               f"Исходный список: {spis}\n" \
               f"Обновленный список: {my_list}"
    except:
        return "Введите два целых числа!"


# noinspection PyBroadException
def lab4_3():
    try:
        my_len = [['БО-331101', ['Акулова Алена', 'Бабушкина Ксения', '...']],
                  ['БОВ-421102', ['...']],
                  ['БО-331103', ['...']]]

        my_len_np = np.array(my_len, dtype=object)

        output_lines = []

        for group in my_len_np:
            group_name = group[0]
            students = group[1]
            output_lines.append(f"<{group_name}>")
            for student in students:
                output_lines.append(student)
        width = 80

        output_text = "\n".join(output_lines)

        return output_text.center(width)
    except:
        return ""


# noinspection PyBroadException
def lab4_4():
    try:
        my_len = [
            ['БО-331101', ['Акулова Алена', 'Бабушкина Ксения', 'Петрушка Андрей', 'Ивкушева Мария']],
            ['БОВ-421102', ['Алексеев Кирилл', 'Шишков Михаил']],
            ['БО-331103', ['Паровозов Аркадий', 'Панкратов Сергей']]
        ]
        mass = []
        ''
        for group_info in my_len:
            group_name = group_info[0]

            for student_name in group_info[1]:
                last_name, first_name = student_name.split()
                if last_name.startswith('П') and first_name.startswith('А'):
                    sss = last_name + ' ' + first_name + ' Группа: ' + group_name
                    mass.append(sss)
        matrix = '\n'.join(' '.join(str(cell) for cell in row) for row in mass)
        return matrix
    except:
        return ''
