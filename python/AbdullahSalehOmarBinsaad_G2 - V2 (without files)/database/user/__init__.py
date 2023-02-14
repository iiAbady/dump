import panels.startmenu
import panels.professor
import panels.employee
allusers = []

def users():
	return allusers

def register(rtype, fname, lname, username, password):
	_users = users()
	userid = len(_users) + 1
	for user in _users:
		if user[4] == username:
			return print('Username already exists!')
	_users.append([userid, rtype.capitalize(), fname, lname, username, password])
	print('\nYou have registerd! please login!')

def search(username, password):
	_users = users()
	if (not _users):
		return 'NOUSERS'
	for user in users():
		if user[4] == username and user[5] == password:
			return user
			break
	return False

def searchById(_id, userType=None):
	_users = users()
	for user in _users:
		if (user[0] == int(_id)):
			if (userType):
				if (user[1] == userType.capitalize()):
					return user
					break
				else:
					continue
			return user
			break
	return False

def login(username, password):
	user = search(username, password)
	if (user == 'NOUSERS'):
		print('No users exist! please register first.\n')
		panels.startmenu.main()
	elif (not user):
		print('Username or password does\'t exist.\n')
		panels.startmenu.main()
	if (user[1] == 'Professor'):
		panels.professor.professor(user)
	else:
		panels.employee.employee(user)