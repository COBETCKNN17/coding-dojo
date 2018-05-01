class Bike():
    def __init__(self,price,max_speed,miles):
        self.price = price
        self.max_speed = max_speed
        self.miles = miles

    def displayInfo(self):
        print "The bike's price is:", self.price
        print "The bike's maximum speed is:", self.max_speed
        print "Total miles:", self.miles
        return self

    def ride(self):
        print "Riding..."
        self.miles += 10
        return self

    def reverse(self):
        if self.miles >=5:
            self.miles -= 5
            print "Reversing..."
        else:
            print "Cannot reverse any further!"
        return self

Bike(275, "35mph", 0).ride().ride().ride().reverse().displayInfo()
Bike(489, "45mph", 0).ride().ride().reverse().reverse().displayInfo()
Bike(2000, "55mph", 0).reverse().reverse().reverse().displayInfo()