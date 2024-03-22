import csv


def read_file(path: str = None) -> list:
    if path.isspace():
        path = "resourses\students.csv"
    with open(path, encoding="UTF-8") as csv_file:
        reader = csv.reader(csv_file, delimiter=";")
        reader.__next__()
        return list(reader)


def lab8_1(flag):
    try:
        k = "resourses\students.csv"
        if flag == 0:
            return 'Словарь:\n{' + "\n".join(
                {"'" + person[0] + "': [" + person[1] + ', ' + person[2] + ', ' + person[3] + ']': person[1:] for person
                 in read_file(k)}) + "}"
        elif flag == 1:
            return {person[0]: person[1:] for person in read_file(k)}
    except Exception as e:
        return str(e)


# noinspection PyBroadException,DuplicatedCode
def lab8_2(string=None):
    try:
        ls = string.split()
        data = lab8_1(1)
        match str(ls[0]):
            case '[1]':
                if len(ls) > 3:
                    pass
                else:
                    name = ' '.join(ls[1:3])
                    for key, value in data.items():
                        # noinspection DuplicatedCode
                        if value[0] == name:
                            input = str({key: value})
                            value[1] = str(int(value[1]) + int(1))
                            inner_lines = '\n'.join('%s:%s' % (k, v) for k, v in data.items())
                            return 'Исходное: ' + input + '\nИТОГ:' + str(
                                {key: value}) + "\nСловарь\n" + """{%s}""" % inner_lines
            case '[2]':
                if len(ls) > 5:
                    pass
                else:
                    name1 = ' '.join(ls[1:3])
                    name2 = ' '.join(ls[3:5])
                    for key, value in data.items():
                        if value[0] == name1:
                            input = str({key: value})
                            value[0] = name2
                            inner_lines = '\n'.join('%s:%s' % (k, v) for k, v in data.items())
                            return 'Исходное: ' + input + '\nИТОГ:' + str(
                                {key: value}) + "\nСловарь\n" + """{%s}""" % inner_lines
            case '[3]':
                if len(ls) > 2:
                    pass
                else:
                    number = ls[1]
                    for key, value in data.items():
                        # noinspection DuplicatedCode
                        if key == number:
                            input = str({key: value})
                            value[1] = str(int(value[1]) + int(1))
                            inner_lines = '\n'.join('%s:%s' % (k, v) for k, v in data.items())
                            return 'Исходное: ' + input + '\nИТОГ:' + str(
                                {key: value}) + "\nСловарь\n" + """{%s}""" % inner_lines
            case '[4]':
                if len(ls) > 6:
                    pass
                else:
                    name = ' '.join(ls[1:3])
                    group = ' '.join(ls[3:6])
                    for key, value in data.items():
                        if value[0] == name:
                            input = str({key: value})
                            value[2] = group
                            inner_lines = '\n'.join('%s:%s' % (k, v) for k, v in data.items())
                            return 'Исходное: ' + input + '\nИТОГ:' + str(
                                {key: value}) + "\nСловарь\n" + """{%s}""" % inner_lines
            case '[5]':
                try:
                    number = ls[1]
                    man = data.pop(number)
                    inner_lines = '\n'.join('%s:%s' % (k, v) for k, v in data.items())
                    return 'ИТОГ:' + str(man) + "\nСловарь\n" + """{%s}""" % inner_lines
                except KeyError:
                    return "Нет такого ключа"
            case '[6]':
                inner_lines1 = '\n'.join('%s:%s' % (k, v) for k, v in data.items())
                for key, value in data.items():
                    if int(value[1]) > 22:
                        value[1] = int(value[1]) - 1
                inner_lines = '\n'.join('%s:%s' % (k, v) for k, v in data.items())
                return 'Словарь\n' + """{%s}""" % inner_lines + '\n===\nИсходный словарь\n' + """{%s}""" % inner_lines1
            case '[7]':
                return '\n'.join({str({x: data[x]}): data[x] for x in data if int(data[x][1]) != 23})
            case '[8]':
                for key, value in data.items():
                    if value[0].split()[0] == "Иванов":
                        value[1] = int(value[1]) + 1
                inner_lines = '\n'.join('%s:%s' % (k, v) for k, v in data.items())
                return 'Словарь\n' + """{%s}""" % inner_lines
            case '[9]':
                for key, value in data.items():
                    lst = value[0].split()
                    if lst[0] == "Иванов":
                        lst[0] = "Сидоров"
                        value[0] = ' '.join(lst)
                inner_lines = '\n'.join('%s:%s' % (k, v) for k, v in data.items())
                return 'Словарь\n' + """{%s}""" % inner_lines
            case '[10]':
                for key, value in data.items():
                    value[0], value[2] = value[2], value[0]
                inner_lines = '\n'.join('%s:%s' % (k, v) for k, v in data.items())
                return 'Словарь\n' + """{%s}""" % inner_lines
        return 'Вы ввели\n>> ' + str(string) + ' <<\nНо что-то пошло не так'
    except:
        return lab8_1(0)


# noinspection PyBroadException
def lab8_3(string=None):
    try:
        ls = string.split()
        data = lab8_1(1)
        match str(ls[0]):
            case '[1]':
                data = {x: data[x] for x in data if data[x][-1] == "БО - 111111"}
                inner_lines = '\n'.join('%s:%s' % (k, v) for k, v in data.items())

                return 'Словарь\n' + """{%s}""" % inner_lines
            case '[2]':
                data = {x: data[x] for x in data if 1 <= int(x) <= 10}
                inner_lines = '\n'.join('%s:%s' % (k, v) for k, v in data.items())
                return 'Словарь\n' + """{%s}""" % inner_lines
            case '[3]':
                data = {x: data[x] for x in data if int(data[x][1]) == 22}
                inner_lines = '\n'.join('%s:%s' % (k, v) for k, v in data.items())
                return 'Словарь\n' + """{%s}""" % inner_lines
            case '[4]':
                data = {x: data[x] for x in data if data[x][0].split()[0] == "Иванов"}
                inner_lines = '\n'.join('%s:%s' % (k, v) for k, v in data.items())
                return 'Словарь\n' + """{%s}""" % inner_lines
            case '[5]':
                data = {x: data[x] for x in data if data[x][0].split()[0].endswith("a")}
                inner_lines = '\n'.join('%s:%s' % (k, v) for k, v in data.items())
                return 'Словарь\n' + """{%s}""" % inner_lines
            case '[6]':
                data = {x: data[x] for x in data if int(data[x][1]) % 2 == 0}
                inner_lines = '\n'.join('%s:%s' % (k, v) for k, v in data.items())
                return 'Словарь\n' + """{%s}""" % inner_lines
            case '[7]':
                data = {x: data[x] for x in data if '5' in data[x][1]}
                inner_lines = '\n'.join('%s:%s' % (k, v) for k, v in data.items())
                return 'Словарь\n' + """{%s}""" % inner_lines
            case '[8]':
                data = {x: data[x] for x in data if len(data[x][-1]) > 11}
                inner_lines = '\n'.join('%s:%s' % (k, v) for k, v in data.items())
                return 'Словарь\n' + """{%s}""" % inner_lines
            case '[9]':
                data = {x: data[x] for x in data if int(x) % 2 == 0}
                inner_lines = '\n'.join('%s:%s' % (k, v) for k, v in data.items())
                return 'Словарь\n' + """{%s}""" % inner_lines
            case '[10]':
                data = {x: data[x] for x in data if data[x][-1].endswith("1")}
                inner_lines = '\n'.join('%s:%s' % (k, v) for k, v in data.items())
                return 'Словарь\n' + """{%s}""" % inner_lines
        return 'Вы ввели\n>> ' + str(string) + ' <<\nНо что-то пошло не так'
    except:
        return lab8_1(0)
