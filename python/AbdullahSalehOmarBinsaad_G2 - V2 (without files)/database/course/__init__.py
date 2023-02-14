allcourses = []

def courses():
	return allcourses

def create(courseId, courseName, professorId):
	allcourses.append([courseId, courseName, int(professorId)])
	print('Successfully created the course!')
	
def searchById(_id):
	_courses = courses()
	for course in _courses:
		if (course[0] == _id):
			return course
			break
	return False