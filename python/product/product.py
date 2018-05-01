class product():
    def __init__(self,price,name,weight,brand):
        self.price = price
        self.name = name
        self.weight = weight
        self.brand = brand
        self.status = "For Sale"
        self.tax_added = 0

    def displayInfo(self):
        print "Item:", self.name
        print "Brand:", self.brand
        print "Price:", self.price
        print "Weight:", self.weight
        print "Current Status:", self.status
        print " "
        return self

    def sellItem(self):
        if self.status == "For Sale":
            print self.name, "has been sold."
            print " "
            self.status = "Sold"
        else:
            print "This item is not for sale."
            print " "
        return self

    def addTax(self,tax):
        self.tax = tax
        if self.tax_added == 0:
            print "Adding tax..."
            self.price = self.price + (self.price * self.tax)
            self.tax_added = 1
            print "The adjusted price is:", self.price
            print " "
        else:
            print "This item already had tax added!"
            print " "
        return self

    def returnItem(self,returnReason):
        self.returnReason = returnReason
        if self.status == "Sold":
            print "Returning item..."
            print " "
            if self.returnReason == "Defective":
                self.status = "Damaged Return"
                self.price = 0
            elif self.returnReason == "New In Box":
                self.status = "For Sale"
            elif self.returnReason == "Open Box":
                self.status = "For Sale"
                self.price = (self.price * .80)
            else:
                print "Unknown reason for return. Cannot resell."
                print " "
                self.status = "Unknown Return Reason"
                self.price = 0
        else:
            print "This item has not been purchased, and cannot be returned."
            print " "
        return self



product(25.00,"Cool Shirt",2,"Tom's Very Cool Shirts").displayInfo().addTax(0.12).displayInfo().sellItem().returnItem("Open Box").displayInfo().sellItem()