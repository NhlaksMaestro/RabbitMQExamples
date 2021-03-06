#"""
#Routes for the flask rest application.
#"""
#from flask import jsonify
#from flask_restful import reqparse, abort, Resource, request
#from rabbitMQ_python_flask import appapi, db  # , jsonify
#from datetime import datetime
#from rabbitMQ_python_flask.models import UserModel
## from rabbitMQ_python_flask.models import EmployeeModel




#def getUserFromList(user_id):
#    return UserModel.query.filter_by(Id=user_id).first()



#def abort_if_user_doesnt_exist(user_id):
#    user = getUserFromList(user_id)
#    if user is None:
#        abort(404, message="User {} doesn't exist".format(user.serialize()))



#parser = reqparse.RequestParser()
#parser.add_argument('Id')


## User
## shows a User saved to PostGreSql Database, and lets you DELETE a User
#class User(Resource):
#    def get(self, user_id):
#        try:
#            abort_if_user_doesnt_exist(user_id)
#            user = getUserFromList(user_id)
#            return jsonify(user.serialize())
#        except Exception as e:
#            return(str(e))

#    def delete(self, user_id):
#        try:
#            abort_if_user_doesnt_exist(user_id)
#            userToDelete = getUserFromList(user_id)
#            db.session.delete(userToDelete)
#            db.session.commit()
#            return '', 204
#        except Exception as e:
#            return(str(e))

## Users
## shows a list of all Users saved to PostGreSql Database,
## lets you PUT to edit an existing User 
## lets you POST to add new User
#class Users(Resource):
#    def get(self):
#        try:
#            users = UserModel.query.all()
#            return jsonify([aUser.serialize() for aUser in users])
#        except Exception as e:
#            return(str(e))

#    def post(self):
#        try:
#            Name = request.json.get('Name')
#            Surname = request.json.get('Surname')
#            DateOfBirth = datetime.strptime(request.json.get('DateOfBirth'), '%dd/%mm/%yyyy')
#            createdUser = UserModel(
#                Name=Name, Surname=Surname, DateOfBirth=DateOfBirth.date())
#            db.session.add(createdUser)
#            db.session.commit()
#            return "User added. createdUser id={}".format(createdUser.Id), 201
#        except Exception as e:
#            return(str(e)), 304

#    def put(self):
#        print("put(self):")
#        try:
#            userId = int(request.json.get('Id'))
#            Name = request.json.get('Name')
#            Surname = request.json.get('Surname')
#            #date_time_obj = datetime.datetime.strptime(date_time_str, '%b %d %Y %I:%M%p')
#            DateOfBirth = datetime.strptime(request.json.get('DateOfBirth'), '%b %d %Y %I:%M%p')
#            #'Thu, 19 Mar 2020 00:00:00 GMT'"%b %d %Y %H:%M:%S"
#            print("userId ===== " + userId)
#            print("Name ===== " + Name)
#            print("Surname ===== " + Surname)
#            print("DateOfBirth ===== " + DateOfBirth)
            
#            userToUpdate = getUserFromList(userId)     
#            print("userToUpdate ===== " + userToUpdate.serialiaze())       
#            userToUpdate.Name = Name
#            print("userToUpdate.Name ===== " + userToUpdate.Name)    
#            userToUpdate.Surname = Surname
#            print("userToUpdate.Surname ===== " + userToUpdate.Surname)   
#            if DateOfBirth is not None:
#                 userToUpdate.DateOfBirth = DateOfBirth

#            print("userToUpdate.DateOfBirth ===== " + str(userToUpdate.DateOfBirth))   
#            db.session.update(userToUpdate)
#            db.session.commit()
#            return "User Details updated: {}".format(userToUpdate.serialize()), 200
#        except Exception as e:
#            return(str(e)), 304

###
## Actually setup the Api resource routing here
###
#appapi.add_resource(Users, '/users')
#appapi.add_resource(User, '/users/<user_id>')

## Employee
## shows a single Employee item and lets you delete a Employee item
## class Employee(Resource):
##    def get(self, employee_id):
##        abort_if_employee_doesnt_exist(employee_id)
##        empToReturn = getEmployeeFromList(employee_id)
##        return empToReturn
##        user = User.query.filter_by(id=id_).first()
##        return jsonify(user.serialize())
    
##    def get(self, employee_id):
##        user = User.query.filter_by(Id=employee_id).first()
##        return jsonify(user.serialize())

##    def delete(self, employee_id):
##        abort_if_employee_doesnt_exist(employee_id)
##        del EMPLOYEESLIST[getEmployeeFromList(employee_id)]
##        return '', 204

##    def put(self, employee_id):
##        empToReturn = EMPLOYEESLIST[getEmployeeFromList(employee_id)]
##        return empToReturn, 201

## Employees
## shows a list of all Employees, and lets you POST to add new Employee
## class Employees(Resource):
##    def get(self):
##        try:
##            users = User.query.all()
##            return  jsonify([aUser.serialize() for aUser in users])
##        except Exception as e:
##            return(str(e))

##    def post(self):
##        try:
##            Name = request.json.get('Name')
##            Surname = request.json.get('Surname')
##            DateOfBirth = datetime.strptime(request.json.get('DateOfBirth'), '%d/%m/%Y')
##            createdUser = User(Name=Name, Surname=Surname, DateOfBirth=DateOfBirth)
##            db.session.add(createdUser)
##            db.session.commit()
##            return "User added. createdUser id={}".format("created User")
##        except Exception as e:
##            return(str(e))

##    def put(self, employee_id):
##        empToReturn = EMPLOYEESLIST[getEmployeeFromList(employee_id)]
##        return empToReturn, 201


####
## Actually setup the Api resource routing here
####
## appapi.add_resource(Employees, '/employees')
## appapi.add_resource(Employee, '/employees/<employee_id>')
