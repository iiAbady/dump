def registerInput(opreation, delSpace=True, allowedTypes=None, _range=None):
	op = input(f'► Enter {opreation}: ')
	while op.isspace():
		op = input(f'► Enter {opreation} Again: ')
	if (delSpace):
		while len(op.split()) > 1:
			op = input(f'► Enter {opreation} Again: ')
	if (allowedTypes):
		while op.capitalize() not in allowedTypes:
			op = input(f'► Enter {opreation} Again: ')
	if (_range):
		while int(op) not in _range:
			op = input(f'► Enter {opreation} Again: ')
	return op.strip()

def userized(userList):
	return {
		"id": userList[0],
		"type": userList[1],
		"firstName": userList[2],
		"lastName": userList[3],
		"username": userList[4],
		"password": userList[5]
	}

def studentized(studentList):
	return {
		"id": studentList[0],
		"firstName": studentList[1],
		"lastName": studentList[2]
	}

def coursized(courseList):
	return {
		"id": courseList[0],
		"courseName": courseList[1],
		"professorId": courseList[2]
	}

def relationzed(relationList):
	return {
		"course": relationList[0],
		"student": relationList[1],
		"degree": relationList[2]
	}