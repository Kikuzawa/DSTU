from typing import Callable

from mimesis import Generic, Locale
from sqlalchemy import create_engine, Engine
from sqlalchemy.orm import sessionmaker, Session

from helpFunctions.tables import Base, Teacher, Position, Department


class DatabaseManager:
    def __init__(self, engine: Engine):
        self.engine = engine
        self.Base = Base
        self.Session = sessionmaker(bind=self.engine)

    def create_tables(self) -> None:
        self.Base.metadata.create_all(self.engine)

    def populate_data(self, fill_functions: Callable[[Session], None]):
        with self.Session() as session:
            fill_functions(session)
            session.flush()
            session.commit()

    @staticmethod
    def fill_positions(session: Session) -> None:
        positions_data: tuple[str, ...] = ('Декан', 'Заместитель декана',
                                           'Заведующий кафедрой', 'Старший преподаватель',
                                           'Ассистент', 'Лаборант', 'Доцент', 'Профессор')
        for title in positions_data:
            position = Position(title=title)
            session.add(position)

    @staticmethod
    def fill_departments(session: Session) -> None:
        departments_data: tuple[dict[str, str], ...] = (
            {'title': 'Высшая математика', 'institute': 'DSTU'},
            {'title': 'Прикладная математика', 'institute': 'DSTU'},
            {'title': 'ПОВТиАС', 'institute': 'DSTU'},
            {'title': 'КБИС', 'institute': 'DSTU'},
            {'title': 'Информатика и математика', 'institute': 'DSTU'},
            {'title': 'ВСиИБ', 'institute': 'DSTU'},
            {'title': 'Документоведение и архивоведение', 'institute': 'DSTU'},
            {'title': 'БЖИЗС', 'institute': 'DSTU'},
        )
        for department_data in departments_data:
            department = Department(**department_data)
            session.add(department)

    def fill_teachers(self: Session) -> None:
        fake = Generic(Locale.RU)

        for _ in range(200):
            teacher = Teacher(
                name=fake.person.full_name(),
                age=fake.random.randint(25, 65),
                department_id=fake.random.randint(1, 8),
                position_id=fake.random.randint(1, 8),
            )
            self.add(teacher)


# noinspection PyTypeChecker
def create_database() -> None:
    engine = create_engine('sqlite:///database.db',
                           echo=False)
    db_manager = DatabaseManager(engine)
    db_manager.create_tables()

    db_manager.populate_data(DatabaseManager.fill_positions)
    db_manager.populate_data(DatabaseManager.fill_departments)
    db_manager.populate_data(DatabaseManager.fill_teachers)
