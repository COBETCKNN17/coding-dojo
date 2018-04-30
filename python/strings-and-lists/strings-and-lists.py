#Find and Replace
words = "It's thanksgiving day. It's my birthday,too!"
print words.index("day")
newWords = words.replace("day","month",1)
print newWords

#Min and Max
x = [2,54,-2,7,12,98]
vmin = x[0]
vmax = x[0]

for num in x:
    if num > vmax:
        vmax = num
    if num < vmin:
        vmin = num
print "Minimum value: ", vmin
print "Maximum value: ", vmax

#First and Last
y = ["hello",2,54,-2,7,12,98,"world"]
print [y[0], y[-1]]

#New List
z = [19,2,54,-2,7,12,98,32,10,-3,6]
z.sort()

half = len(z)/2
firstHalf = z[:half]
secondHalf = z[half:]
newZ = []

newZ.append(firstHalf)

for number in secondHalf:
    newZ.append(number)

print [newZ]


