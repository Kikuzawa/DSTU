import csv
import os
from prettytable import PrettyTable


# noinspection PyBroadException
def lab5_1(path: str):
    try:
        file_count = len([f for f in os.listdir(path) if os.path.isfile(os.path.join(path, f))])
        return f'Количество файлов: {file_count}'
    except:
        return "Введите путь директории!"


def create_csv_file():
    pass


# noinspection PyBroadException
def lab5_2():
    try:
        table = PrettyTable()
        if not os.path.exists("resourses\students.csv"):
            create_csv_file()
        with open("resourses\students.csv", encoding="UTF-8") as csv_file:
            reader = csv.reader(csv_file, delimiter=";")
            table.field_names = reader.__next__()
            result = sorted(reader, key=lambda row: int(row[0]))
            table.add_rows(result)
        return str(table)
    except:
        return ''


# noinspection PyShadowingNames,PyBroadException
def lab5_3(group_to_update, flag):
    try:
        table = PrettyTable()
        updated_rows = []
        with open("resourses\students.csv", encoding="UTF-8") as csv_file:
            reader = csv.reader(csv_file, delimiter=";")
            table.field_names = reader.__next__()
            result = sorted(reader, key=lambda row: int(row[2]))
            for row in result:
                if str(row[3]) == group_to_update:
                    row[2] = str(int(row[2]) + 1)
                updated_rows.append(row)
            result = sorted(updated_rows, key=lambda row: row[2])
            table.add_rows(result)


        if flag == 1:
            with open("resourses\students.csv", mode="w", newline='', encoding="UTF-8") as csv_file:
                writer = csv.writer(csv_file, delimiter=";")
                writer.writerow(table.field_names)
                writer.writerows(updated_rows)

        return str(table)
    except:
        return 's'

def lab5_4(text):
    lab5_3(text, flag=1)
    pass

#print(lab5_1('C:\Users\5555k\PycharmProjects\GUI_MY'))
#print(lab5_2())
#print(lab5_3('БО-111111', 0))
#print(lab5_4('БО-111111'))