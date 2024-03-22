from sqlalchemy import Column, Integer, String, ForeignKey
from sqlalchemy.ext.declarative import declarative_base
from sqlalchemy.orm import relationship

Base = declarative_base()


class Country(Base):
    __tablename__ = 'countries'
    id = Column(Integer, primary_key=True)
    name = Column(String(50), nullable=False)
    cities = relationship('City', back_populates='country')


class City(Base):
    __tablename__ = 'cities'
    id = Column(Integer, primary_key=True)
    name = Column(String, nullable=False)
    country_id = Column(Integer, ForeignKey('countries.id'))
    streets = relationship('Street', back_populates='city')
    country = relationship('Country', back_populates='cities')


class Street(Base):
    __tablename__ = 'streets'
    id = Column(Integer, primary_key=True)
    name = Column(String, nullable=False)
    city_id = Column(Integer, ForeignKey('cities.id'))
    city = relationship('City', back_populates='streets')
