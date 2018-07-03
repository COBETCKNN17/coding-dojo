using System;

namespace WizardNinjaSamurai
{
    class Program
    {
        static void Main(string[] args)
        {
            Wizard Nat = new Wizard("Nat");
            Ninja Josh = new Ninja("Josh");
            Human Balazs = new Human("Balazs");
            Samurai Will = new Samurai("Will");

            Nat.Attack(Josh);
            Nat.Fireball(Josh);
            Josh.Steal(Nat);
            Will.Attack(Balazs);
            Josh.getAway();
            Nat.Heal();
            Will.Meditate();
            Will.deathBlow(Nat);
            Will.deathBlow(Josh);
        }
    }
}