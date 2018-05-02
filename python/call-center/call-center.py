#Call Class

class Call(object):
    def __init__(self,uid,name,number,time,reason):
        self.uid = uid
        self.name = name
        self.number = number
        self.time = time
        self.reason = reason

    def display(self):
        print "Unique ID: ", self.uid
        print "Caller Name: ", self.name
        print "Caller Phone Numer: ", self.number
        print "Time of Call: ", self.time
        print "Reason for Call: ", self.reason
        print " "
        return self

#Call Center Class

class CallCenter(object):
    def __init__(self):
        self.calls = []
        self.queue = 0

    def add(self, newCall):
        self.calls.append(newCall)
        self.queue += 1
        print "New call added to queue. Total queue:", self.queue
        print " "
        return self

    def remove(self):
        if self.queue > 0:
            del self.calls[0]
            self.queue -= 1
            print "Resolved call removed from queue. Total queue:", self.queue
            print " "
        else:
            print "Queue is empty!"
            print " "
        return self

    def info(self):
        print "Current Waiting Calls:"
        print " "
        for i in self.calls:
            print "ID:", i.uid, "- Caller", i.name, "called from", i.number, "at", i.time, "because", i.reason
            print " "
        return self

    def removeByNumber(self,num):
        x = 0
        for i in self.calls:
            if i.number == num:
                self.calls.pop(x)
                print "Removed caller", num
                print " "
            else:
                x = x + 1
        return self

call1 = Call(123,"Nat","123-456-7890","12:50pm","needs technical support")
call2 = Call(124,"Will","123-583-9893","1:50pm","wants so many refunds")
call3 = Call(125,"Balazs","123-975-0032","12:50am","bored and can't sleep")
call4 = Call(126,"Josh","123-338-9364","5:03am","just because")

newCall = CallCenter()
newCall.add(call1)
newCall.add(call2)
newCall.add(call3)
newCall.info()
newCall.remove()
newCall.remove()
newCall.add(call4)
newCall.info()
newCall.removeByNumber("123-975-0032")
newCall.info()
