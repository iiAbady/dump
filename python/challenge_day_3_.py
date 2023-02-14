def getMaxiumSubArray():
    a = [1,2,-1,-2,2,1,-2,1,4,-5,4]
    default_max = max(a)
    firstStep = False
    res = 0
    applied_indexes = []

    def checkNegative(lst: list[int]) -> bool:
        for j in lst:
            if j > 0:
                return False
        return True

    if checkNegative(a):
        return max(a)

    else:
        for i in range(len(a)-1):
            if not firstStep and a[i] < 0:
                continue
            if a[i] + a[i+1] > 0:
                firstStep = True
                if not i in applied_indexes:
                    print(a[i])
                    res += a[i]
                    applied_indexes.append(i)
                if not i+1 in applied_indexes:
                    print(a[i+1])
                    res += a[i+1]
                    applied_indexes.append(i+1)

        def checkIfSteps(lst: list[int]) -> list[int]:
            if lst:
                prev_num = lst[0]
                res = []
                for j in range(1, len(lst)):
                    if not prev_num == lst[j] - 1:
                        res = [prev_num, lst[j]]
                    prev_num = lst[j]
                return res
    
        missed_nums = checkIfSteps(applied_indexes)

        if missed_nums:
            for i in range(missed_nums[0] + 1, missed_nums[1]):
                res += a[i]


    return res if res > default_max else default_max

def getSumOfTwoNumbersWithoutOperator():
    fn = bin(8)[2:]
    sn = bin(5)[2:]
    len_fn = len(fn)
    len_sn = len(sn)
    if (len_fn > len_sn):
        sn = f"{''.join(['0' for i in range(len_fn - len_sn)])}{sn}"
    elif (len_sn > len_fn):
        fn = f"{''.join(['0' for i in range(len_fn - len_sn)])}{fn}"
    
    for i in range(len(fn) - 1, -1, -1):
        1001
        1011
        