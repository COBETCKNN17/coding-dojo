one = "*"
two = " "
line = ""

for x in range (1,10):
    if x % 2 == 0:
        for i in range (1,10):
            if i % 2 == 0:
                line+=str(one)
            else:
                line+=str(two)
        print line
        line = ""
    else:
        for i in range (1,10):
            if i % 2 == 1:
                line+=str(one)
            else:
                line+=str(two)
        print line
        line = ""