#Solution 1

'''
base_numbers = [1,2,3,4,5,6,7,8,9,10,11,12]
new_line = []

print "x", base_numbers

for x in range (1,13):
    new_line.append(x)
    for i in base_numbers:
        new_line.append(i*x)
    print new_line
    new_line = []
'''

#Solution 2

new_line = "x "

for y in range(1,13):
    new_line+=str(y)
    new_line+=str(" ")
print new_line
new_line = ""

for x in range(1,13):
    new_line+=str(x)
    new_line+=str(" ")
    for i in range (1,13):
        new_line+=str(i*x)
        new_line+=str(" ")
    print new_line
    new_line = ""