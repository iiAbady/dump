import database
from models import registerInput

# Start Menu
def main():
	startMenu = input("""Welcome to Faculty System, Choose an operation:
a. Login
b. Create Account
► """)


	## Login
	if (startMenu == 'a'):
		print("""\nLogin:
------""")
		username = input('► Enter Username: ')
		password = input('► Enter Password: ')
		database.user.login(username, password)
	## Register
	elif (startMenu == 'b'):
		print("""\nUser Information:
------""")
		userType = registerInput('User Type', True, ['Employee', 'Professor'])
		firstName = registerInput('First Name')
		lastName = registerInput('Last Name')
		username = registerInput('Username')
		password = registerInput('Password')
		database.user.register(userType, firstName, lastName, username, password)
		main()
	else:
		print()
		main()