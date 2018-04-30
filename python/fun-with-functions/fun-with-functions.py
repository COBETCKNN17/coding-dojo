#Odd/Even

def odd_even ():
    for i in range(1,2000):
        if i % 2 == 0:
            print "Number is", i, ". This is an even number."
        else:
            print "Number is", i, ". This is an odd number."

odd_even()

#Multiply

def multiply (a,num):
    arrNew = []

    for i in a:
        arrNew.append(i*num)
    return arrNew

b = multiply([2,4,10,16], 5)
print b