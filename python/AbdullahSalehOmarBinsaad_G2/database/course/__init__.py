from models import coursized

def courses():
	try:
		file = open('database/courses', 'r')
		lines = file.readlines()
		return [coursized(i.replace('\n', '').split(', ')) for i in lines]
		file.close()
	except:
		return []

def create(courseId, courseName, professorId):
	file = open('database/courses', 'a')
	file.write(f'{courseId.upper()}, {courseName.capitalize()}, {professorId}\n')
	print('Successfully created the course!')
	file.close()

def searchById(_id):
	_courses = courses()
	for course in _courses:
		if (course['id'] == _id):
			return course
			break
	return False