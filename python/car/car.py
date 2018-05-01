class Car():
    def __init__(self,price,speed,fuel,mileage):
        self.price = price
        self.speed = speed
        self.fuel = fuel
        self.mileage = mileage
        self.tax = 0

    def displayInfo(self):
        print "Car Info:"
        print "Price:", self.price
        print "Speed:", self.speed
        print "Fuel:", self.fuel
        print "Mileage:", self.mileage
        if self.price > 10000:
            self.tax = 0.15
        else:
            self.tax = 0.12
        print "Tax:", self.tax
        print " "
        return self

Car(2000, "95mph", "Full", "15mpg").displayInfo()
Car(25000, "5mph", "Not Full", "105mpg").displayInfo()
Car(8500, "15mph", "Half Full", "95mpg").displayInfo()
Car(290000, "200mph", "Full", "5mpg").displayInfo()
Car(100, "1mph", "Empty", "1mpg").displayInfo()
Car(65000, "100mph", "Half Full", "55mpg").displayInfo()
