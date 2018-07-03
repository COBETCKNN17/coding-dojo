using System;
using System.Collections.Generic;

namespace WizardNinjaSamurai
{
    public class Ninja: Human
    {
        public Ninja(string ninName): base(ninName)
        {
            name = ninName;
            dexterity = 175;
        }

        public void getAway()
        {
            this.health -= 15;
            Console.WriteLine(this.name + "gets away but loses health!");
            Console.WriteLine(this.name + " now has " + this.health + " health.");
        }

        public string Steal(object target)
        {
            if(target is Human)
            {
                Attack(target);
                Console.WriteLine(this.name + " steals 10 health!");
                this.health += 10;
                Console.WriteLine(this.name + " now has " + this.health + " health.");
                return this.name + " stole health!";
            }
            else 
            {
                Console.WriteLine("Invalid target!");
                return "Invalid target!";
            }
        }
    }
}