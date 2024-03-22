import random


# noinspection PyBroadException
def lab2_1(text):
    try:
        my_number = 19
        while True:
            user_number = int(text)
            if user_number == my_number:
                return f"my_number - {my_number} = user_number - {user_number}"
            else:
                return f"my_number - {my_number} ≠ user_number - {user_number}\nКонец программы"
    except:
        return "Введите целое число user_number!"


# noinspection PyBroadException
def lab2_2(text):
    try:
        the_list = text.split()

        new_list = []
        for word in the_list:
            if word[-1] == "r":
                new_list.append(word)
        if new_list:
            return f"Слова: {new_list}"
        else:
            return "Такие слова не найдены!"
    except:
        return "Введите строку со словами через пробел"


# noinspection PyBroadException
def lab2_3():
    try:
        random_string = ""
        for _ in range(6):
            digit = str(random.randint(0, 9))
            random_string += digit

        while '3' not in random_string:
            random_i = random.randint(0, 5)
            random_string = random_string[:random_i] + '3' + random_string[random_i + 1:]
        return f"Случайная строка: {random_string}"
    except:
        return ''


# noinspection PyBroadException
def lab2_4(text):
    try:
        my_string = text
        result = "".join([symbol for symbol in my_string if symbol == 'Л'])
        if my_string != '':
            return f'Введена строка: {my_string}\n' \
                   f'Результат: {result}'
        else:
            return "Ввод пустой, введите строку!"
    except:
        return "Введите строку"