mixType = ["pegasus", 88, "unicorn", 10, 33, "dog"]
intType = [2,3,1,7,4,12]
stringType = ['magical','unicorns']

l = mixType

string = ""
vsum = 0
listOne = l[0]
exit = False

for i in l:
    if isinstance(i, basestring):
        string += " " + i
    elif isinstance(i, int):
        vsum = vsum + i
    for x in l:
        if (type(x) != type(listOne)) and exit == False:
            print "The list you entered is of mixed type."
            exit = True
        if (isinstance(listOne, basestring)) and exit == False:
            print "The list you entered is of string type."
            exit = True
        if (isinstance(listOne, int)) and exit == False:
            print "The list you entered is of integer type."
            exit = True

print "New String:", string
print "Sum of Ints:", vsum