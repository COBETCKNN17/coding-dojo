using System;

namespace WizardNinjaSamurai
{
    public class Human
    {
        public string name;
        public int health { get; set; }
        public int strength { get; set; }
        public int intelligence { get; set; }
        public int dexterity { get; set; }

        public Human(string name)
        {
            this.name = name;
            strength = 3;
            dexterity = 3;
            intelligence = 3;
            health = 100;
        }

        public Human(string name, int strength, int intelligence, int dexterity, int health)
        {
            this.name = name;
            this.strength = strength;
            this.intelligence = intelligence;
            this.dexterity = dexterity;
            this.health = health;
        }        

        public string Attack(object target)
        {
            if(target is Human)
            {
                Human targeted = (Human)target;
                targeted.health -= (5 * this.strength);
                Console.WriteLine(this.name + " has attacked " + targeted.name);
                Console.WriteLine(targeted.name + " now has " + targeted.health + " health.");
                return this.name + " has attacked " + targeted.name;
            }
            else 
            {
                Console.WriteLine("Invalid target!");
                return "Invalid target!";
            }
        }       
    }
}