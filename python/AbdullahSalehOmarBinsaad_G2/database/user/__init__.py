import panels.startmenu
import panels.professor
import panels.employee
from models import userized

def users():
	try:
		file = open('database/users', 'r')
		return [userized(i.replace('\n', '').split(', ')) for i in file.readlines()]
		file.close()
	except:
		return []

def register(rtype, fname, lname, username, password):
	try:
		file = open('database/usersCount', 'r')
		usersCount = int(file.read(1))
		file.close()
	except:
		usersCount = 0
	userId = usersCount + 1
	_users = users()
	for user in _users:
		if (user['username']) == username:
			return print('\nUsername already exist!')
	if (_users):
		file = open('database/users', 'a')
		file.write('\n')
		file.close()
	file = open('database/users', 'a')
	file.write(f'{userId}, {rtype.capitalize()}, {fname}, {lname}, {username}, {password}')
	file.close()
	file = open('database/usersCount', 'w')
	file.write(str(userId))
	file.close()
	print('\nYou have registerd! please login!')

def search(username, password):
	_users = users()
	if (not _users):
		return 'NOUSERS'
	for user in users():
		if user['username'] == username and user['password'] == password:
			return user
			break
	return False

def searchById(_id, userType=None):
	_users = users()
	for user in _users:
		if (user["id"] == _id):
			if (userType):
				if (user["type"] == userType.capitalize()):
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
	if (user["type"] == 'Professor'):
		panels.professor.professor(user)
	else:
		panels.employee.employee(user)