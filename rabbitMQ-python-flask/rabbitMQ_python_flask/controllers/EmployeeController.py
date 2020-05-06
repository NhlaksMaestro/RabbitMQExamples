
class HelloWorld(Resource):
    def get(self):
        return {'hello': 'world',
                'datetime': str(datetime.now())}
    

EMPLOYEESLIST = [{
        'Id': '5e721d159cbbd4e4a1e75d38',
        'FirstName': 'Reds',
        'LastName': 'Sloan',
        'DateOfBirth': '16/05/1995'
    },
    {
        'Id': '5e721d159cbbd4e4a1e75d39',
        'FirstName': 'Sams',
        'LastName': 'Loans',
        'DateOfBirth': '12/04/1975'
    },
    {
        'Id': '5e732a4394b1133d74d83d6f',
        'FirstName': 'Gee',
        'LastName': 'Gangster',
        'DateOfBirth': '12/01/1978'
    }]

def getEmployeeFromList(employee_id):
    for emp in EMPLOYEESLIST:
        if(emp["Id"] == employee_id):
            return emp
    return {}

def abort_if_employee_doesnt_exist(employee_id):
    emp = getEmployeeFromList(employee_id)
    if emp not in EMPLOYEESLIST:
        abort(404, message="Employee {} doesn't exist".format(emp))