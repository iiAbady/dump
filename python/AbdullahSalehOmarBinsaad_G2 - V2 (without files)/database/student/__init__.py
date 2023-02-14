allstudents = []

def students():
	return allstudents

def create(firstName, lastName, studentAge):
	_students = students()
	studentId = len(_students) + 2021100
	_students.append([studentId, firstName, lastName, studentAge])
	print('Sucessfully created the student!')

def searchById(_id):
	_students = students()
	for student in _students:
		if (student[0] == int(_id)):
			return student
			break
	return False
