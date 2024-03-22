from sqlalchemy import Column, Integer, String, ForeignKey
from sqlalchemy.ext.declarative import declarative_base

Base = declarative_base()


class Position(Base):
    __tablename__ = 'positions'
    id: int = Column(Integer, primary_key=True)
    title: str = Column(String)


class Department(Base):
    __tablename__ = 'departments'

    id: int = Column(Integer, primary_key=True)
    title: str = Column(String(25))
    institute: str = Column(String(50))


class Teacher(Base):
    __tablename__ = 'teachers'
    id: int = Column(Integer, primary_key=True)
    name: str = Column(String(50))
    age: int = Column(Integer)

    department_id: int = Column(Integer, ForeignKey('departments.id'))
    position_id: int = Column(Integer, ForeignKey('positions.id'))
