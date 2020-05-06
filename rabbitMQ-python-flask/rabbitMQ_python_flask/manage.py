"""
This script runs the config for environment.
"""
from flask_script import Manager
from flask_migrate import Migrate, MigrateCommand
from rabbitMQ_python_flask import app, db

migrate = Migrate(app, db)
manager = Manager(app)

manager.add_command('db', MigrateCommand)

if __name__ == '__main__':
    manager.run()
