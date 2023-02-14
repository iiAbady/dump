from models import registerInput
import panels.startmenu
import database

def professor(thisProfessor):
	op = input(f"""\nWelcome Professor. {thisProfessor[2]}, choose an operation:
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
		if (thisProfessor[0] != thisCourse[2]):
			print('Sorry you don\'t have permissions to view this course degreed!')
			professor(thisProfessor)
		courseDegrees = database.relations.courseDegrees(courseID)
		print("""\nThe students registered in this course are:
-------------------------------------------""")
		i = 1
		for relation in courseDegrees:
			student = database.student.searchById(relation[1])
			print(f'{i}. {student[1]} {student[2]}')
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
		if (thisProfessor[0] != thiscourse[2]):
			print('Sorry you don\'t have permissions to edit this course degrees!')
			professor(thisProfessor)
		coursedgrees = database.relations.courseDegrees(courseId)
		for relation in coursedgrees:
			newDgree = registerInput(f'the degree of student {relation[1]}', True, None, range(0, 101))
			database.relations.editDegree(relation[1], relation[0], relation[2], newDgree)
		professor(thisProfessor)
	if (op.lower() == 'c'): panels.startmenu.main()
