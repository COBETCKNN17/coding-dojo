using System;
using System.Collections.Generic;

namespace WizardNinjaSamurai
{
    public class Samurai: Human
    {
        public Samurai(string samName): base(samName)
        {
            name = samName;
            health = 200;
        }

        public void Meditate()
        {
            this.health = 200;
            Console.WriteLine(this.name + " meditates and regains all health!");
            Console.WriteLine(this.name + " now has " + this.health + " health.");
        }

        public string deathBlow(object target)
        {
            if(target is Human)
            {
                Human targeted = (Human)target;

                if(targeted.health < 50)
                {
                    targeted.health = 0;
                    Console.WriteLine(this.name + " has performed a death blow on " + targeted.name +"!!!");
                    Console.WriteLine(targeted.name + " now has " + targeted.health + " health.");
                    return this.name + " has performed a death blow on " + targeted.name;
                }
                else
                {
                    targeted.health -= (5 * this.strength);
                    Console.WriteLine(this.name + " attempted a death blow on " + targeted.name + ", but " + targeted.name + " was too healthy to die!");
                    Console.WriteLine(targeted.name + " now has " + targeted.health + " health.");
                    return this.name + " has attacked " + targeted.name;
                }
            }
            else 
            {
                Console.WriteLine("Invalid target!");
                return "Invalid target!";
            }
        }
    }
}