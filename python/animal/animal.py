#Animal Parent Class

class Animal(object):
    def __init__(self):
        self.name = "Animal"
        self.health = 150

    def walk(self):
        print "Walking..."
        self.health -= 1
        return self

    def run(self):
        print "Running..."
        self.health -= 5
        return self

    def displayHealth(self):
        print "Health:", self.health
        return self

#Dog Class

class Dog(Animal):
    def __init__(self):
        super(Dog, self).__init__() 
        self.name = "Dog"

    def pet(self):
        print "Dog gets pet and heals!"
        self.health += 5
        return self

#Dragon Class

class Dragon(Animal):
    def __init__(self):
        super(Dragon, self).__init__() 
        self.name = "Dragon"
        self.health += 20

    def fly(self):
        print "Flying..."
        self.health -= 10
        return self

#Spider Class

class Spider(Animal):
    def __init__(self):
        super(Spider, self).__init__() 
        self.name = "Spider"
        self.health -= 10

Dog().walk().walk().walk().run().run().displayHealth().pet().displayHealth()
Dragon().run().run().run().displayHealth().fly().fly().displayHealth()

#Spider().fly()
#Confirmed that spider cannot fly

