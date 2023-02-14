class Map:
	def __init__(self):
		self.map = {}
	def add(self, key, value):
		self.map[key] = value
	def get(self, key):
		val = self.map.get(key)
		if val:
			return val
		else:
			return 'Not found' 
	def delete(self, key):
		self.map.__delitem__(key)
	def prompt(self):
		while True:
			y = input('Enter Command: ')
			if (y.lower().startswith("add")):
				key, val = y.split(' ')[1:]
				self.add(key, val)
				print(f'Added {val} to {key}')
			if (y.lower().startswith("get")):
				key = y.split(' ')[1]
				print(self.get(key))
			if (y.lower().startswith("delete")):
				key = y.split(' ')[1]
				print("Deleted!")
s = Map()
s.prompt()