from models import registerInput
import panels.startmenu
import database

def employee(thisEmployee):
	op = input(f"""\nWelcome Employee. {thisEmployee[2]}, choose an operation:
a. Add a course
b. Add a student
c. Register a student to a course
d. Display the degrees of student in all courses
e. Logout
► """)
	if (op.lower() == 'a'):
		print("""\nCourse Information:
-------------------""")
		courseId = registerInput('Course ID')
		courseName = registerInput('Name', False)
		professorId = registerInput('Professor ID')
		thisId = database.user.searchById(professorId, 'Professor')
		while not thisId:
			print('Couldn\'t find Professor ID, please try again!')
			professorId = registerInput('Professor ID')
			thisId = database.user.searchById(professorId, 'Professor')
		database.course.create(courseId, courseName, professorId)
		employee(thisEmployee)

	if (op.lower() == 'b'):
		print("""\nStudent Information:
--------------------""")
		firstName = registerInput('First Name', False)
		lastName = registerInput('Last Name', False)
		age = registerInput('Age', True, None, range(0, 120))
		database.student.create(firstName, lastName, age)
		employee(thisEmployee)

	if (op.lower() == 'c'):
		print("""\nRegistration:
-------------""")
		studentId = registerInput('Student ID', True)
		thisStudentID = database.student.searchById(studentId)
		while not thisStudentID:
			print('Couldn\'t find Student ID, please try again!')
			studentId = registerInput('Student ID', True)
			thisStudentID = database.student.searchById(studentId)
		courseId = registerInput('Course ID', True)
		thisCourseID = database.course.searchById(courseId)
		while not thisCourseID:
			print('Couldn\'t find Course ID, please try again!')
			courseId = registerInput('Course ID', True)
			thisCourseID = database.course.searchById(courseId)
		database.relations.registration(courseId, studentId)
		employee(thisEmployee)

	if (op.lower() == 'd'):
		print()
		studentID = registerInput('Student ID', True)
		thisStudentId = database.student.searchById(studentID)
		while not thisStudentId:
			studentID = registerInput('Student ID', True)
			thisStudentId = database.student.searchById(studentID)
			print('Couldn\'t find Student ID, please try again!')
		relations = database.relations.studentDegrees(studentID)
		print()
		print("""\nCourse       Degree
------       ------""")
		if (relations):
			for relation in relations:
				try:
					courseName = database.course.searchById(relation[0])[1]
				except:
					courseName = ''
				try:
					degree = relation[2]
				except:
					degree = ''
				print(f'{courseName}       {degree}')
		employee(thisEmployee)
	if (op.lower() == 'e'): panels.startmenu.main()
	else:
		print()
		employee(thisEmployee)