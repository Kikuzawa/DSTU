import csv


def read_file(path: str = None) -> list:
    if path.isspace():
        path = "resourses\students.csv"
    with open(path, encoding="UTF-8") as csv_file:
        reader = csv.reader(csv_file, delimiter=";")
        reader.__next__()
        return list(reader)


def save_dict_to_file(dictionary, filename):
    with open(filename, 'w', newline='', encoding='utf-8') as file:
        writer = csv.writer(file, delimiter=';')
        writer.writerow(['№', 'ФИО', 'Возраст', 'Группа'])
        for key, value in dictionary.items():
            writer.writerow([key, value[0], value[1], value[2]])


def ret_data():
    k = "resourses\students.csv"
    return {person[0]: person[1:] for person in read_file(k)}


# noinspection PyBroadException,PyShadowingNames
def lab9_1(string, flag):
    try:
        data = ret_data()
        ls = string.split()
        key = ls[0]
        value = ls[1:]
        data.update({key: value})
        inner_lines = '\n'.join('%s:%s' % (k, v) for k, v in data.items())
        scale = 'ИТОГ:' + str({key: value})
        if flag == 1:
            save_dict_to_file(data, 'students.csv')
        return scale + "\nНовый словарь\n" + """{%s}""" % inner_lines
    except:
        return 'Вы ввели\n>> ' + str(string) + ' <<\nНо что-то пошло не так'


# noinspection PyBroadException,PyGlobalUndefined
def lab9_2(string, flag):
    global inner_lines
    try:
        data = ret_data()
        ls = string.split()
        if len(ls) != 7:
            return 'Вы ввели\n>> ' + str(string) + ' <<\nНо что-то пошло не так'
        else:
            number = ls[0]
            name = " ".join(ls[1:3])
            age = ls[3]
            group = " ".join(ls[4:7])

            for key, value in data.items():
                if key == number:
                    value[0] = name
                    value[1] = age
                    value[2] = group
                    inner_lines = '\n'.join('%s:%s' % (k, v) for k, v in data.items())
            if flag == 1:
                save_dict_to_file(data, 'students.csv')
            return string + "\nИсходный Словарь\n" + """{%s}""" % inner_lines
    except:
        return 'Вы ввели\n>> ' + str(string) + ' <<\nНо что-то пошло не так'


# noinspection PyBroadException,PyShadowingNames
def lab9_3(number, flag):
    try:
        data = ret_data()
        chel = data.pop(number)
        inner_lines = '\n'.join('%s:%s' % (k, v) for k, v in data.items())
        print(data)
        if flag == 1:
            save_dict_to_file(data, 'students.csv')
        return f'Удален\n{chel}\nСловарь\n' + """{%s}""" % inner_lines
    except:
        return 'Вы ввели\n>> ' + str(number) + ' <<\nНо что-то пошло не так (Проверьте правильность номера)'


# noinspection PyBroadException
def lab9_4(number):
    try:
        data = ret_data()
        for key, value in data.items():
            if key == number:
                return str({key: value})
    except:
        return 'Вы ввели\n>> ' + str(number) + ' <<\nНо что-то пошло не так'


# noinspection PyBroadException
def save_lab9(text, flag):
    try:
        match flag:
            case 1:
                lab9_1(text, 1)
            case 2:
                lab9_2(text, 1)
            case 3:
                lab9_3(text, 1)
    except:
        return 'Ошибка'
