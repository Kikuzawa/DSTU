# noinspection PyBroadException
def lab1_1(text):
    try:
        text = text.split( )
        print(text)
        a, b, c = map(int, text)
        try:
            result = abs(1 - a * b ** c - a * (b ** 2 - c ** 2) + (b - c + a) * (12 + b) / (c - a))
            return f"Число a = {a}\n" \
                   f"Число b = {b}\n" \
                   f"Число c = {c}\n" \
                   f"Результат выражения |1 - a*b^c - a*(b^2-c^2) + (b-c+a)*(12+b)/(c-a)|= {str(result)}"
        except ZeroDivisionError:
            return "Ошибка! Деление на ноль недопустимо!"
    except:
        return "Введите целочисленные значения элементам a, b, c через пробел."


# noinspection PyBroadException
def lab1_2(text):
    try:
        stroka = text.split()
        mass = ''
        print(stroka)
        for x in range(1, len(stroka)):
            if x % 2 != 0:
                mass += str(stroka[x]) + ' '
        return f"Четные элементы: {mass}"
    except:
        return "Введите строку с пробелами, состояющую из чисел и строк (минимум два элемента)!"


# noinspection PyBroadException
def lab1_3(text):
    try:
        the_list = [float(text) for text in text.split()]
        result = 1
        for number in the_list:
            if number < 10:
                result *= number
        if result != 1:
            return f"Список: {the_list}\n" \
                   f"Результат умножения всех чисел меньше 10: {result}"
        else:
            return f"Список: {the_list}\n" \
                   f"Числа, меньше 10, не найдены => результат умножения: 0"
    except:
        return "Введите строку с пробелами, состояющую из чисел (минимум два числа)!"


# noinspection PyBroadException
def lab1_4(text):
    try:
        my_list = [float(text) for text in text.split()]
        sigma_num = sum(my_list)
        count_num = len(my_list)
        average_num = sigma_num / count_num
        if len(my_list) > 1:
            return f"Список: {my_list}\n" \
                   f"Среднее арифметическое всех чисел: {average_num}"
        else:
            return "Введите строку с пробелами, состояющую из чисел (минимум два числа)!"
    except:
        return "Введите строку с пробелами, состояющую из чисел (минимум два числа)!"


