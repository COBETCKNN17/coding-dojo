class Ninja {
    constructor(name) {
        this.name = name;
        this.health = 100;
        this.speed = 3;
        this.strength = 3;
    }

    sayName() {
        console.log("Hello my name is " + this.name);
    }

    showStats() {
        console.log("Name: " + this.name + " - Health: " + this.health + " - Speed: " + this.speed + " - Strength: " + this.strength);
    }

    drinkSake() {
        this.health += 10;
        console.log(this.name + " drinks some sake. Health is now " + this.health);
    }
}

class Sensei extends Ninja {
    constructor(name) {
        super(name);
        this.name = name;
        this.health = 200;
        this.speed = 10;
        this.strength = 10;
        this.wisdom = 10;
    }

    speakWisdom() {
        this.drinkSake();
        console.log(this.name + " says: Do not go where the path may lead, go instead where there is no path and leave a trail.")
    }
}


const ninja1 = new Ninja("Naruto");
ninja1.sayName();
ninja1.showStats();
ninja1.drinkSake();

const sensei1 = new Sensei("Kakashi");
sensei1.sayName();
sensei1.showStats();
sensei1.speakWisdom();