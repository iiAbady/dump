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