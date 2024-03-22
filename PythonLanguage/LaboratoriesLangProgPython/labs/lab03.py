import numpy as np
import pandas as pd
import string
import random


# noinspection PyBroadException
def lab3_1(text):
    try:
        input_string = str(text)
        string_without_punct = ''.join(char for char in input_string if char.isalpha() or char.isspace())
        words = string_without_punct.split()
        new_words = [word for word in words if 5 <= len(word) <= 10]
        new_string = ' '.join(new_words)
        if new_string != '':
            return f"Новая строка: {new_string}"
        else:
            return 'Введена пустая строка или слов, соответствующих условию, не существует!'
    except:
        return 'Введена пустая строка!'


# noinspection PyBroadException
def lab3_2():
    try:
        my_string = "Ф;И;О;Возраст;Категория;_Иванов;Иван;Иванович;23 года;Студент 3 курса;_Петров;Семен;Игоревич;22 года;Студент 2 курса"

        parts = my_string.split(';')

        data = np.array(parts).reshape(-1, 5)
        df = pd.DataFrame(data[1:], columns=data[0])

        return f"{df.to_string(index=False)}"
    except:
        return ''


# noinspection PyBroadException
def lab3_3():
    try:
        # noinspection PyShadowingNames
        def filter_students_by_age(my_string):
            student_notes = my_string.split(";_")
            filtered_students = []

            for note in student_notes:
                fields = note.split(";")
                age = fields[1]

                if "год" in age and int(age.split()[0]) > 21:
                    filtered_students.append(fields)

            return filtered_students

        my_string = "ФИО;Возраст;Категория;_Иванов Иван Иванович;23 года;Студент 3 курса;_Петров Семен Игоревич;22 года;Студент 2 курса;_Иванов Семен Игоревич;22 года;Студент 2 курса;_Акибов Ярослав Наумович;23 года;Студент 3 курса;_Борков Станислав Максимович;21 год;Студент 1 курса;_Петров Семен Семенович;21 год;Студент 1 курса;_Романов Станислав Андреевич;23 года;Студент 3 курса;_Петров Всеволод Борисович;21 год;Студент 2 курса"
        result = filter_students_by_age(my_string)
        matrix2='\n'.join(' '.join(str(cell) for cell in row) for row in result)
        return matrix2
    except:
        return ''


# noinspection PyBroadException
def lab3_4(text):
    try:
        lang_word = int(text)
        rand_sym = ''.join(random.choice(string.ascii_letters + ' ' + string.digits) for _ in range(lang_word))

        count_symbols = len(rand_sym)
        count_words = len(rand_sym.split())

        return f"Случайная строка: {rand_sym}\n" \
               f"Количество символов: {count_symbols}\n" \
               f"Количество слов: {count_words}"
    except:
        return "Введите длину строки (целое число)!"