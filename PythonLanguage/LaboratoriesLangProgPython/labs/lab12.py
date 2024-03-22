import os

from sqlalchemy import text
from sqlalchemy.engine import create_engine
from sqlalchemy.orm import sessionmaker

from helpFunctions.fill_tables1 import create_database
from helpFunctions.tables1 import *

file_path = os.path.join(os.path.dirname(os.path.abspath(__file__)), "database1.db")

if not os.path.exists(file_path):
    create_database()

SESSION = sessionmaker(bind=create_engine(f'sqlite:///{file_path}', echo=False))()


def lab12_1():
    # noinspection PyUnresolvedReferences
    return str([country.name for country in SESSION.query(Country).filter(Country.name.like('A%')).all()])


def lab12_2():
    query = text("""
    SELECT main.cities.name
    FROM main.cities, main.streets
    WHERE main.streets.city_id == main.cities.id
    GROUP BY main.streets.city_id
    HAVING COUNT(main.streets.city_id) > 5
    """)
    return '\n'.join(row[0] for row in SESSION.execute(query))


# noinspection PyTypeChecker
def lab12_3():
    country_name = 'РФ'  # Замените на фактическое название страны

    # Находим страну по названию
    country = SESSION.query(Country).filter_by(name=country_name).first()

    if country:
        # Если страна найдена, выводим все улицы для неё
        streets = (
            SESSION.query(Street.name)
            .join(City, Street.city_id == City.id)
            .join(Country, City.country_id == Country.id)
            .filter(Country.name == country_name)
            .all()
        )
        return '\n'.join(street.name for street in streets)


# noinspection PyShadowingNames
def show_db():
    import sqlite3

    # Соединение с базой данных
    conn = sqlite3.connect('database1.db')

    # Создание курсора
    cursor = conn.cursor()
    # Выполнение запроса для получения всех записей с данными из всех трех таблиц
    cursor.execute(
        'SELECT * FROM countries, cities, streets WHERE countries.id = cities.country_id AND cities.id = streets.city_id')

    # Получение всех записей
    result = cursor.fetchall()

    country_dict = {}
    for row in result:
        country_name = row[1]
        city_name = row[3]
        street_name = row[6]

        if country_name not in country_dict:
            country_dict[country_name] = {}

        if city_name not in country_dict[country_name]:
            country_dict[country_name][city_name] = []

        country_dict[country_name][city_name].append(street_name)

    text = ''
    for country_name, cities in country_dict.items():
        text += str(country_name) + '\n      '
        for city_name, streets in cities.items():
            text += '==>>' + str(city_name) + '\n             -->' + str(streets) + '\n      '
        text += '\n==============\n'

    conn.close()
    return text
