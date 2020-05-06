"""
The flask application package.
"""
from rabbitMQ_python_flask import db

class UserModel(db.Model):
    __tablename__ = 'user'
    Id = db.Column(db.Integer(), primary_key=True)
    Name = db.Column(db.String(255))
    Surname = db.Column(db.String(255))
    DateOfBirth = db.Column(db.DateTime)

    def __init__(self, Name, Surname, DateOfBirth):
        self.Name = Name
        self.Surname = Surname
        self.DateOfBirth = DateOfBirth

    def serialize(self):
        return {
            'Id': self.Id,
            'Name': self.Name,
            'Surname': self.Surname,
            'DateOfBirth': self.DateOfBirth
        }

