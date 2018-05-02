#Part One

'''

class MathDojo(object):
    def __init__(self):
        self.total = 0

    def add(self, *x):
        self.addNum = 0
        for value in x:
            self.addNum += value
        self.total += self.addNum
        return self

    def subtract(self, *y):
        self.subNum = 0
        for value in y:
            self.subNum += value
        self.total -= self.subNum
        return self

md = MathDojo().add(2).add(2,5).subtract(3,2).total
print md

'''
#Part Two & Three

class MathDojo(object):
    def __init__(self):
        self.total = 0

    def add(self, *x):
        for i in range(0, len(x)):
            if type(x[i]) is tuple or type(x[i]) is list:
                for num in x[i]: 
					self.total += num
            else:
                self.total += x[i]
        return self

    def subtract(self, *y):
        for i in range(0, len(y)):
            if type(y[i]) is tuple or type(y[i]) is list:
                for num in y[i]: 
					self.total -= num
            else:
                self.total -= y[i]
        return self

md = MathDojo().add([1], 3,4).add([3,5,7,8], (2,4.3,1.25)).subtract(2, [2,3], [1.1,2.3]).total
print md