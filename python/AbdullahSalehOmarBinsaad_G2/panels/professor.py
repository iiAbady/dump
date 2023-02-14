import panels.startmenu
import database
from models import registerInput

def professor(thisProfessor):
	op = input(f"""\nWelcome Professor. {thisProfessor["firstName"]}, choose an operation:
a. Display the students registered in your course
b. Add the degrees of students
c. Logout
► """)
	if (op.lower() == 'a'):
		courseID = registerInput('Course ID')
		thisCourse = database.course.searchById(courseID)
		while not thisCourse:
			print('Couldn\'t find Course ID, please try again!')
			courseID = registerInput('Course ID')
			thisCourse = database.course.searchById(courseID)
		if (thisProfessor['id'] != thisCourse['professorId']):
			print('Sorry you don\'t have permissions to view this course degreed!')
			professor(thisProfessor)
		courseDegrees = database.relations.courseDegrees(courseID)
		print("""\nThe students registered in this course are:
-------------------------------------------""")
		i = 1
		for relation in courseDegrees:
			student = database.student.searchById(relation['student'])
			print(f'{i}. {student["firstName"]} {student["lastName"]}')
		print()
		professor(thisProfessor)

	if (op.lower() == 'b'):
		print()
		courseId = registerInput('Course ID')
		thiscourse = database.course.searchById(courseId)
		while not thiscourse:
			print('Couldn\'t find Course ID, please try again!')
			courseId = registerInput('Course ID')
			thiscourse = database.course.searchById(courseId)
		if (thisProfessor['id'] != thiscourse['professorId']):
			print('Sorry you don\'t have permissions to edit this course degrees!')
			professor(thisProfessor)
		coursedgrees = database.relations.courseDegrees(courseId)
		for relation in coursedgrees:
			newDgree = registerInput(f'the degree of student {relation["student"]}', True, None, range(0, 101))
			database.relations.editDegree(relation["student"], relation["course"], newDgree)
		professor(thisProfessor)
	if (op.lower() == 'c'): panels.startmenu.main()
