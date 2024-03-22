from labs.lab07 import *
from labs.lab09 import *

try:
    # noinspection PyArgumentList
    def selection_save(selected_module, selected_function, text):
        if selected_module == "Лабораторная 7":
            if selected_function == 'Задача 2':
                pass
            elif selected_function == 'Задача 3':
                return lab7_4(text)
        elif selected_module == "Лабораторная 9":
            if selected_function == 'Задача 1':
                return save_lab9(text,1)
            if selected_function == 'Задача 2':
                return save_lab9(text, 2)
            if selected_function == 'Задача 3':
                return save_lab9(text, 3)

except Exception as e:
    print(e)