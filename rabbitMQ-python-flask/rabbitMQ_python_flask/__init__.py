"""
The flask application package.
"""
from flask import Flask, jsonify
from flask_restful import Api
from flask_sqlalchemy import SQLAlchemy
from flask_script import Manager
from flask_migrate import Migrate, MigrateCommand

#ENV_DB_CONNECTION_DSN = postgresql:///RabbitMQExampleDB
app = Flask(__name__)
app.config['SQLALCHEMY_DATABASE_URI']='postgresql://pgadmin:Bwl@20202@localhost/RabbitMQExampleDB'#postgresql://user:secret@localhost
app.config['SQLALCHEMY_TRACK_MODIFICATIONS'] = False

db = SQLAlchemy(app)
appapi = Api(app)


import rabbitMQ_python_flask.views
import rabbitMQ_python_flask.controllers
import rabbitMQ_python_flask.models
import rabbitMQ_python_flask.manage
from rabbitMQ_python_flask.controllers.UserController import User, Users


appapi.add_resource(Users, '/users')
appapi.add_resource(User, '/users/<user_id>')