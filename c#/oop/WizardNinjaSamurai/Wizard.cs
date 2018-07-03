using System;
using System.Collections.Generic;

namespace WizardNinjaSamurai
{
    public class Wizard: Human
    {
        public Wizard(string wizName): base(wizName)
        {
            name = wizName;
            intelligence = 25;
            health = 50;
        }

        public void Heal()
        {
            this.health += intelligence * 10;
            Console.WriteLine(this.name + "is healing!");
            Console.WriteLine(this.name + " now has " + this.health + " health.");
        }

        public string Fireball(object target)
        {
            if(target is Human)
            {
                Human targeted = (Human)target;
                Random random = new Random();

                targeted.health -= random.Next(20, 50);
                Console.WriteLine(this.name + " has cast fireball on " + targeted.name);
                Console.WriteLine(targeted.name + " now has " + targeted.health + " health.");
                return this.name + " has cast fireball on " + targeted.name;
            }
            else 
            {
                Console.WriteLine("Invalid target!");
                return "Invalid target!";
            }
        }
    }
}