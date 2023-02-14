import database
from models import relationzed

def relations():
	try:
		file = open('database/sc_relations', 'r')
		return [relationzed(i.replace('\n', '').split(', ')) for i in file.readlines()]
		file.close()
	except:
		return []

def registration(courseId, studentId):
	_relations = relations()
	for relation in _relations:
		if (relation['course'] == courseId and relation['student'] == studentId):
			return print('The student is already registered in the course!')
	file = open('database/sc_relations', 'a')
	file.write(f'{courseId}, {studentId}, 0\n')
	print('Sucessfully registered the student to the course!')
	file.close()

def studentDegrees(studentID):
	_relations = relations()
	studentRelations = []
	for relation in _relations:
		if (relation['student'] == studentID):
			studentRelations.append(relation)
	return studentRelations

def courseDegrees(courseID):
	_relations = relations()
	courseRelations = []
	for relation in _relations:
		if (relation['course'] == courseID):
			courseRelations.append(relation)
	return courseRelations

def editDegree(studentID, courseID, degree):
	file = open('database/sc_relations', 'r')
	lines = file.readlines()
	i = 0
	for line in lines:
		[courseId, studentId, _] = line.replace('\n', '').split(', ')
		if (courseID == courseId and studentID == studentId):
			break
		else:
			i += 1
	lines[i] = f'{courseID}, {studentID}, {degree}\n'
	file = open('database/sc_relations', 'w')
	file.writelines(lines)
	file.close()
	print('Successfully edited the student\'s degree!')