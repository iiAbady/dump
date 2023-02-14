fn = bin(50)[2:][::-1]
sn = bin(50)[2:][::-1]
lenFn, lenSn = len(fn), len(sn)
res = ''

if (lenFn < lenSn):
    fn += '0'.join(['0' for i in range(lenSn - lenFn)])
elif (lenSn < lenFn):
    sn += '0'.join(['0' for i in range(lenFn - lenSn)])

carry = 0
for i in range(len(fn)):
    count = 0
    if (fn[i] == '1' and sn[i] == '1'):
        count += 2
    elif (fn[i] == '1' or sn[i] == '1'):
        count += 1
    
    if (carry + count == 3):
        res += '1'
        carry = 1
    elif (carry + count == 2):
        res += '0'
        carry = 1
    elif (carry + count == 1):
        res += '1'
        carry = 0
    else:
        res += '0'
        carry = 0

if (carry): res += '1'
print(res[::-1])