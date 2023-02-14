fn = 19
sn = 17
num = ''


y = bin(fn)[2:][::-1]
x = bin(sn)[2:][::-1]

diff = len(x) - len(y)
diff1 = len(y) - len(x)

print(y)
print(x)

if diff > diff1:
    repeated = ''.join(['0' for i in range(diff)])
    y += repeated

elif diff1 > diff:
    repeated = ''.join(['0' for i in range(diff1)])
    x += repeated

before = False
for i in range(len(x)):
    print(f"first num: {y[i]}, second number: {x[i]}")
    if (x[i] == '1'  and y[i] == '1'):
        if (not before):
            num += '0'
            before = True
        num +='1'
    elif (x[i] != y[i]):
        num += '1'
        before = False
    else:
        num += '0'
        before = False

print(num[::-1])