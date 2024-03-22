import csv
from random import randint

from mimesis import Person


def create_csv_file():
    person = Person()
    with open("resourses/students.csv", mode='w', encoding="UTF-8", newline='') as csv_file:
        writer = csv.writer(csv_file, delimiter=";")
        writer.writerow(['№', "ФИО", "Возраст", "Группа"])

        ivan_row = [
            1,
            "Иванов Иван",  # Тут можешь использовать свою функцию для генерации ФИО
            person.age(),  # И возраста
            f"БО - 111111"
        ]
        writer.writerow(ivan_row)

        writer.writerows(
            [
                [
                    i,
                    person.full_name(),
                    person.age(),
                    f"БО - {''.join(str(randint(1, 2)) for _ in range(6))}"
                ]
                for i in range(2, 500)
            ]
        )
