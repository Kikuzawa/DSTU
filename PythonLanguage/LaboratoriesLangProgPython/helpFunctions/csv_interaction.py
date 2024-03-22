
import csv
import os
from typing import Any

# поиск абсолютного пути для приложения
CSV_FILE_PATH = os.path.join(os.path.dirname(os.path.abspath(__file__)), "output.csv")


def db_to_csv(data: dict):
    with open(CSV_FILE_PATH, 'w', newline='') as csv_file:
        csv_writer = csv.writer(csv_file)

        # Запись заголовков
        headers = ['teacher_id', 'name', 'age',
                   'position_id', 'position_title',
                   'department_id', 'department_title', 'institute']
        csv_writer.writerow(headers)

        # Запись данных в файл
        for teacher_id, teacher_data in data.items():
            row = [
                teacher_id,
                teacher_data['name'],
                teacher_data['age'],
                teacher_data['position']['id'],
                teacher_data['position']['title'],
                teacher_data['department']['id'],
                teacher_data['department']['title'],
                teacher_data['department']['institute']
            ]
            csv_writer.writerow(row)


def csv_to_db(flag=1) -> dict[Any, dict[str, dict[str, Any] | dict[str, Any] | Any]] | str:
    data_dict = {}

    with open(CSV_FILE_PATH, 'r', newline='') as csv_file:
        csv_reader = csv.reader(csv_file)
        next(csv_reader)  # Пропуск заголовков
        # Распаковал так имена для удобства, чтобы можно было нормально добавлять
        for row in csv_reader:
            teacher_id, name, age, position_id, position_title, department_id, department_title, institute = row

            data_dict[teacher_id] = {
                'name': name,
                'age': age,
                'position': {'id': position_id, 'title': position_title},
                'department': {'id': department_id, 'title': department_title, 'institute': institute}
            }
    if flag == 1:
        return data_dict
    else:
        inner_lines = '\n'.join('%s:%s' % (k, v) for k, v in data_dict.items())
        return """{%s}""" % inner_lines
