from models import studentized

def students():
	try:
		file = open('database/students', 'r')
		return [studentized(i.replace('\n', '').split(', ')) for i in file.readlines()]
		file.close()
	except:
		return []

def create(firstName, lastName, studentAge):
	try:
		file = open('database/studentCount', 'r')
		studentCount = int(file.readline(1))
		file.close()
	except:
		studentCount = 0
	studentId = studentCount + 2021100
	file = open('database/students', 'a')
	file.write(f'{studentId}, {firstName}, {lastName}, {studentAge}\n')
	file.close()
	studentCount += 1
	file = open('database/studentCount', 'w')
	file.write(f'{studentCount}')
	file.close()
	print('Sucessfully created the student!')

def searchById(_id):
	_students = students()
	for student in _students:
		if (student['id'] == _id):
			return student
			break
	return False
