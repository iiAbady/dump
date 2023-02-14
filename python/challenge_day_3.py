a = [5,4,-1,7,8]
res = 0
lst = []
applied_indexes = []

for i in range(len(a)-1):
    if res == 0 and a[i] < 0:
        continue
    if a[i] + a[i+1] > 0:
        if not i in applied_indexes:
            print(a[i])
            res += a[i]
            applied_indexes.append(i)
        if not i+1 in applied_indexes:
            print(a[i+1])
            res += a[i+1]
            applied_indexes.append(i+1)
    

print(res)