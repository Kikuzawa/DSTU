import random

import numpy as np
import requests
from environs import Env
from mimesis import Address, Locale, Datetime
from mimesis.builtins import RussiaSpecProvider
from prettytable import PrettyTable
from russian_names import RussianNames

from classes import *

ENV = Env()
ENV.read_env()


def generate_table(array: np.ndarray) -> PrettyTable:  # функция генерации таблицы с помощью библиотеки prettytable

    table = PrettyTable()

    match type(array[0]).__name__:
        case "Student":
            table.field_names = ["Фамилия", "Инициалы", "Номер группы", "Оценки", "Средний балл"]
            _generate_table_students(table=table, students=array)

        case "Train":
            table.field_names = ["Номер поезда", "Пункт назначения", "Время отправления"]
            _generate_table_trains(table=table, trains=array)

    return table


def _generate_table_students(table: PrettyTable, students: np.ndarray) -> None:  # печать таблицы студентов
    sorting_key = [np.mean(student.grades) for student in
                   students]  # создание массива со средними баллами, поможет для сортировки
    sorting_indexes = np.argsort(sorting_key)  # получение индексов для сортировки
    table.add_rows(
        [
            student.last_name,
            student.initials,
            student.number_group,
            ', '.join(map(str, student.grades)),
            np.mean(student.grades).round(3)
        ]
        for student in students[sorting_indexes]
    )


def _generate_table_trains(table: PrettyTable, trains: np.ndarray) -> None:  # печать таблицы с поездами
    table.add_rows([train.number, train.dest, train.departure] for train in trains)


def generate_subscriber() -> Subscriber:  # функция генерации абонента для заполнения в массив
    person = RussianNames().get_person().split()

    return Subscriber(
        identification_number=np.random.randint(1000, 9999),
        surname=person[2],
        first_name=person[0],
        patronymic=person[1],
        address=Address(Locale.RU).address(),
        credit_card_number=np.random.randint(1000, 9999),
        debit=np.random.uniform(1000, 10000),
        credit=np.random.uniform(0, 5000),
        intercity_call_time=Datetime().time().replace(microsecond=0),
        local_call_time=Datetime().time().replace(microsecond=0))


def generate_buyer() -> Buyer:  # функция генерации покупателя для заполнения в массив
    # Генерируется русское имя в формате ИОФ
    person = RussianNames().get_person().split()

    return Buyer(
        name=person[0],
        patronymic=person[1],
        surname=person[2],
        address=Address(Locale.RU).address(),
        credit_card_number=int(RussiaSpecProvider().kpp()) // 100,
        bank_account_number=int(RussiaSpecProvider().bic()) // 100
    )


def generate_student() -> Student:  # генерация студента
    person = RussianNames().get_person().split()

    return Student(
        last_name=person[2],
        initials=f"{person[0][0]}.{person[1][0]}",
        number_group=np.random.randint(1, 10),
        grades=np.random.uniform(2, 5, 5).round()
    )


def generate_train(number: int) -> Train:  # генерация данных поезда
    destination = Address(Locale.RU)  # получение адресов
    return Train(
        dest=f"{destination.federal_subject()} г.{destination.city()}",
        number=number,
        departure=Datetime().time().replace(microsecond=0)
    )


def generate_book() -> Book:  # генерация данных о книге с интернет источника (через API)
    # noinspection HttpUrlsUsage
    books = requests.get("http://titlegen.us-east-1.elasticbeanstalk.com/api/v1/titlegen?type=song&no=4").json()['data']

    return Book(
        title=random.choice(books),
        author=RussianNames().get_person(),
        year=Datetime().year()
    )
