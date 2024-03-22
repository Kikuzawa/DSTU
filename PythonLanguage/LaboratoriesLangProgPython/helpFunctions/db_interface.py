from sqlalchemy.engine import create_engine
from sqlalchemy.orm import sessionmaker

from helpFunctions.tables import *

engine = create_engine('sqlite:///database.db', echo=False)
session = sessionmaker(bind=engine)()

__all__ = [
    "remove_by_position", "remove_by_name", "remove_by_department",
    "add_new_position", "add_new_department", "add_new_teacher",
    "change_teacher_name", "change_department"
]


def remove_by_name(data: tuple[str, ...]) -> bool:
    name_to_delete = data[-1].strip().title()
    teacher_to_delete = session.query(Teacher).filter_by(name=name_to_delete).first()
    if teacher_to_delete:
        session.delete(teacher_to_delete)
        session.commit()
        return True


# noinspection DuplicatedCode
def remove_by_department(data: tuple[str, ...]) -> bool:
    department_to_delete = data[-1].strip()
    # Получаем объект кафедры из базы данных
    if department := session.query(Department).filter_by(title=department_to_delete).first():
        # Получаем всех преподавателей, связанных с кафедрой
        teachers_to_delete = session.query(Teacher).filter_by(department_id=department.id).all()

        # Удаляем каждого преподавателя
        for teacher in teachers_to_delete:
            session.delete(teacher)

        # Удаляем саму кафедру
        session.delete(department)
        # Зафиксировать изменения в базе данных
        session.commit()
        return True


# noinspection DuplicatedCode
def remove_by_position(data: tuple[str, ...]) -> bool:
    position_to_delete = data[-1].strip().title()
    # Получаем объект должности из базы данных
    if position := session.query(Position).filter_by(title=position_to_delete).first():
        # Получаем всех преподавателей, связанных с должностью
        teachers_to_delete = session.query(Teacher).filter_by(position_id=position.id).all()
        # Удаляем каждого преподавателя
        for teacher in teachers_to_delete:
            session.delete(teacher)
        # Удаляем полностью должность
        session.delete(position)
        # Сохраняем изменения
        session.commit()
        return True


def add_new_position(data: tuple[str, ...]) -> bool:
    position_to_add = data[-1].strip().capitalize()
    # Если уже существует в таблице, то мы добавлять не будем
    if session.query(Position).filter_by(title=position_to_add).first():
        return True

    # Добавляем новую должность, если все-таки не было в таблице
    new_position = Position(title=position_to_add)
    session.add(new_position)
    session.commit()
    return True


# noinspection PyTypeChecker
def add_new_department(data: tuple[str, ...]) -> bool:
    department_to_add, university = map(str.capitalize, map(str.strip, data[-2:]))
    # Если уже существует в таблице, то мы добавлять не будем
    if session.query(Department).filter_by(title=department_to_add, institute=university).first():
        return True

    # Добавляем новую кафедру, если все-таки не было в таблице
    new_department = Department(title=department_to_add, institute=university)
    session.add(new_department)
    session.commit()
    return True


# noinspection PyTypeChecker,PyUnresolvedReferences
def add_new_teacher(data: tuple[str, ...]) -> bool:
    name, age, department_title, institute, position_title = map(str.title, map(str.strip, data[-5:]))
    department_title, institute = map(str.upper, (department_title, institute))

    # находим ID кафедры относительно названия
    department_id = session.query(Department.id).filter_by(title=department_title, institute=institute).first()
    if department_id is None:
        new_department = Department(title=department_title, institute=institute)
        session.add(new_department)
        session.commit()

    # находим ID звания относительно названия
    position_id = session.query(Position.id).filter_by(title=position_title).first()
    if position_id is None:
        new_position = Position(title=position_title)
        session.add(new_position)
        session.commit()

    # Если существует уже данный преподаватель, то не добавляем его в БД
    # noinspection PyUnresolvedReferences
    if session.query(Teacher).filter_by(name=name,
                                        age=age,
                                        department_id=department_id[0],
                                        position_id=position_id[0]).scalar():
        return True

    # noinspection PyUnresolvedReferences
    new_teacher = Teacher(name=name, age=age, department_id=department_id[0], position_id=position_id[0])
    session.add(new_teacher)
    session.commit()
    return True


def change_teacher_name(data: tuple[str, ...]) -> bool:
    old_name, new_name = map(str.strip, data[-2:])

    if teacher_to_replace := session.query(Teacher).filter_by(name=old_name).first():
        print(teacher_to_replace)
        teacher_to_replace.name = new_name
        session.commit()
        return True


def change_department(data: tuple[str, ...]) -> bool:
    old_name, new_name = map(str.strip, data[-2:])

    if department_to_replace := session.query(Department).filter_by(title=old_name).first():
        department_to_replace.title = new_name
        session.commit()
        return True
