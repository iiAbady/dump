# def funnel(word, word2):
# 	w = list(word)
# 	for i, _ in enumerate(w):
# 		r = w.pop(i)
# 		if ''.join(w) == word2:
# 			return True
# 		else:
# 			w.insert(i, r)
# 	return False

def changer(*s):
	# y = ''.join(214214214)
	# print(y)
	"{0:x}".format(''.join(s))
	
print(changer('100, 2, 0')