import re
from functools import partial

import arrow

from helpFunctions.help_functions import *


def lab14_1(what_to_do: str) -> PrettyTable | str:
    students: np.ndarray[Student, ...] = np.array([generate_student() for _ in range(50)])  # <<
    if re.fullmatch("Вывести всех студентов имеющих только оценки 4 или 5", what_to_do.strip()):
        students = np.array([student for student in students if all(grade in (4, 5) for grade in student.grades)])

        if students.size == 0:
            return "Нет таких учеников"

    table = generate_table(students)
    return table


def lab14_2(what_to_do: str) -> str | PrettyTable:
    # noinspection PyBroadException
    try:
        list_trains = np.array([generate_train(number) for number in range(1, 51)])

        trains = Trains(trains=list_trains)

        if reg := re.fullmatch(r"^Вывести информацию о поезде под номером (\d+)$", what_to_do.strip(), re.I):
            table = PrettyTable()
            table.field_names = [f'{trains[trains.find(int(reg.group(1)))].info}']
            return table

        if re.fullmatch(r"^Отсортировать поезда по пункту назначения|Отсортировать$", what_to_do.strip(), re.I):
            trains.sort(lambda train: (train.dest, train.departure))
            return generate_table(trains.trains)

        if re.fullmatch(r"^Вывести всю таблицу расписания поездов$", what_to_do.strip(), re.I):
            return generate_table(trains.trains)

        table = PrettyTable()
        table.field_names = [f'Введите предложение']
        return table
    except:
        pass


def lab14_3(string: str):
    if res := re.fullmatch(r"^Найти сумму значений (?:переменных)?(\d+) (\d+)$", string.strip(), re.I):
        var = TwoVariables(*map(int, res.groups()))
        return f"{var.sum()}"

    if res := re.fullmatch(r"^Найти наибольшее значение (\d+) (\d+)$", string.strip(), re.I):
        var = TwoVariables(*map(int, res.groups()))
        return f"{var.max_variable()}"

    if res := re.fullmatch(r"^Изменить переменные с (\d+ \d+) на (\d+ \d+)$", string.strip(), re.I):
        var = TwoVariables(*map(int, res.group(1).split()))
        var.modify(*map(int, res.group(2).split()))
        return f"{var}"


def lab14_4(what_to_do: str):
    # noinspection PyBroadException
    try:
        books = [generate_book() for _ in range(9)] + [Book(title="Муму", author="Тургенев Иван Сергеевич", year=1852)]

        library = Library(books=books)

        patterns: list = [
            (r'Добавить книгу ([\d\-\.A-Яа-яA-Za-z\s ]+)', library.append),
            (r"Удалить книгу ([\d\-\.A-Яа-яA-Za-z\s ]+)", library.remove),
            (r"Найти книгу по автору - ([\d\-\.A-Яа-яA-Za-z\s ]+)", partial(library.search_books, "author")),
            (r"Найти книгу по названию - ([\d\-\.A-Яа-яA-Za-z\s ]+)", partial(library.search_books, "title")),
            (r"Найти книгу по году - (\d+)", partial(library.search_books, "year")),
            (r"Отсортировать книги по годам", partial(Library.sort_books, key=lambda book: book.year)),
            (r"Отсортировать книги по авторам", partial(Library.sort_books, key=lambda book: book.author)),
            (r"Отсортировать книги по названиям", partial(Library.sort_books, key=lambda book: book.title))
        ]

        for pattern, method in patterns:
            if res := re.fullmatch(pattern, what_to_do.strip(), re.I):
                if re.match("Отсортировать", what_to_do.strip(), re.I):
                    table = PrettyTable()
                    table.field_names = ['Данные']
                    table.add_rows([i] for i in method(library))
                    return str(table)

                result = method(res.group(1))
                return str(result if result is not None else library.to_pretty_table())

        return ''
    except:
        return ''


def lab14_5(what_to_do: str):
    buyers = [generate_buyer() for _ in range(50)]

    if re.fullmatch(r"Вывести список покупателей в алфавитном порядке", what_to_do.strip()):
        buyers.sort(key=lambda x: x.full_name)
        return '\n\n'.join(map(str, buyers))

    pattern = r"Вывести список покупателей, у которых номер кредитной карточки находится в диапазоне от (\d+) до (\d+)"
    if res := re.fullmatch(pattern, what_to_do.strip()):
        min_num, max_num = map(int, res.groups())
        return '\n\n'.join(map(str, filter(lambda buyer: min_num <= buyer.credit_card_number <= max_num, buyers)))


def lab14_6(what_to_do: str):
    subscribers = [generate_subscriber() for _ in range(80)]

    patterns = [
        (r"Вывести сведения относительно абонентов, у которых время превышает (\d{2}:\d{2}:\d{2})",
         lambda x, mat: x.local_call_time > arrow.get(mat.group(1), "HH:mm:ss").time()),
        (r"Вывести сведения относительно абонентов, которые пользовались междугородной связью",
         lambda x, _: x.intercity_call_time > arrow.get("00:01:00", "HH:mm:ss").time()),
        (r"Вывести список абонентов в алфавитном порядке", None)
    ]

    for pattern, condition in patterns:
        if match := re.fullmatch(pattern, what_to_do.strip()):
            if condition is None:
                iterable = sorted(subscribers, key=lambda x: x.full_name)
            else:
                iterable = filter(lambda x: condition(x, match), subscribers)

            return '\n\n'.join(map(str, iterable))

    return "Неверный формат ввода"
