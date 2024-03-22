import os
import re
from typing import Callable
from sqlalchemy import create_engine, text
from sqlalchemy.orm import sessionmaker
from helpFunctions.csv_interaction import db_to_csv, csv_to_db
from helpFunctions.fill_tables import create_database
from helpFunctions.tables import *
from helpFunctions.db_interface import *

file_path = os.path.join(os.path.dirname(os.path.abspath(__file__)), "database.db")

if not os.path.exists(file_path):
    create_database()

SESSION = sessionmaker(bind=create_engine(f'sqlite:///{file_path}', echo=False))()


def lab11_1(flag=None):
    # SQL-запрос для извлечения данных из нескольких таблиц
    # Join объединяет наши данные, чтобы они были вместе
    query_result = SESSION.query(Teacher, Position, Department).join(Position).join(Department).all()

    data_dict = {}
    for teacher, position, department in query_result:
        data_dict[teacher.id] = {
            'name': teacher.name,
            'age': teacher.age,
            'position': {'id': position.id, 'title': position.title},
            'department': {'id': department.id, 'title': department.title, 'institute': department.institute}
        }
    if flag == 1:
        inner_lines = '\n'.join('%s:%s' % (k, v) for k, v in data_dict.items())
        return """{%s}""" % inner_lines
    else:
        return data_dict


def lab11_2(string: str) -> str:
    pattern_and_functions: list[tuple[re.Pattern, Callable]] = [
        (re.compile(r'^Удалить (преподавателя)? (.+)$', re.I | re.U), remove_by_name),
        (re.compile(r"^Удалить всех с кафедры (.+)$", re.I | re.U), remove_by_department),
        (re.compile(r"^Удалить всех,? кто имеет звание -(.+)$", re.I | re.U), remove_by_position),
        (re.compile(r"^Добавить новое звание - (.+)$", re.I | re.U), add_new_position),
        (re.compile(r"^Добавить новую кафедру[:\-]? (.+) в университет (.+)$", re.I | re.U), add_new_department),
        (re.compile(r"^Добавить нового преподавателя (.+) с возрастом (\d+) на кафедру (.+) в университет (.+)"
                    r" на должность (.+)$", re.I | re.U), add_new_teacher),
        (re.compile(r"^Изменить имя преподавателя с (.+) на (.+)$", re.I | re.U), change_teacher_name),
        (re.compile(r"^Изменить название кафедры с (.+) на (.+)$", re.I | re.U), change_department)
    ]

    for pattern, func in pattern_and_functions:
        if res := pattern.fullmatch(string.strip()):
            return f"'{string}' - выполнено!\nСписок\n" + lab11_1(1) if func(
                res.groups()) else "Не выполнено!\nСписок\n" + lab11_1(1)
    return f"Неправильный ввод данных\nСписок:\n" + lab11_1(1)


def lab11_3():
    # SQL код выполняется не построчно, как Python.
    # Здесь такая последовательность FROM -> JOIN -> SELECT
    query = text(
        """
        SELECT teachers.name, departments.title AS department_title, positions.title AS position_title
        FROM teachers
        JOIN departments ON teachers.department_id = departments.id
        JOIN positions ON teachers.position_id = positions.id
        """
    )

    result = SESSION.execute(query)

    return "\n".join(
        f"ФИО - {row[0]}\n"
        f"Название кафедры - {row[1]}\n"
        f"Должность преподавателя - {row[2]}\n"
        for row in result
    )


def lab11_4():
    query = text(
        """
        SELECT departments.title AS department_title, COUNT(teachers.id) AS teacher_count
        FROM teachers
        JOIN departments ON teachers.department_id = departments.id
        GROUP BY teachers.department_id;
        """
    )

    result = SESSION.execute(query)

    return '\n'.join(f"Кафедра: {row[0]}, Количество преподавателей: {row[1]}" for row in result)


def lab11_5(decree: str):
    if re.fullmatch(r"(Записать|Вписать)\s?(данные|информацию)?", decree, re.I):
        res: dict = lab11_1(flag=0)
        db_to_csv(res)
        return "Готово"

    if re.fullmatch(r"(Считать|Прочитать)\s?(данные|информацию)?", decree, re.I):
        return csv_to_db(flag=0)

    return "Неправильно ввели данные"
