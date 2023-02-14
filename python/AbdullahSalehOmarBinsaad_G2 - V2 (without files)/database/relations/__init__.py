import database
allrelations = []

def relations():
	return allrelations

def registration(courseId, studentId):
	_relations = relations()
	for relation in _relations:
		if (relation[0] == courseId and relation[1] == studentId):
			return print('The student is already registered in the course!')
	_relations.append([courseId, studentId, 0])
	print('Sucessfully registered the student to the course!')

def studentDegrees(studentID):
	_relations = relations()
	studentRelations = []
	for relation in _relations:
		if (relation[1] == studentID):
			studentRelations.append(relation)
	return studentRelations

def courseDegrees(courseID):
	_relations = relations()
	courseRelations = []
	for relation in _relations:
		if (relation[0] == courseID):
			courseRelations.append(relation)
	return courseRelations

def editDegree(studentID, courseID, oldDegree, newDegree):
	_relations = relations()
	_relations.remove([courseID, studentID, oldDegree])
	_relations.append([courseID, studentID, newDegree])
	print('Successfully edited the student\'s degree!')