using System;

namespace Human
{
    class Program
    {
        static void Main(string[] args)
        {
            Human Nat = new Human("Nat");
            Human Josh = new Human("Josh");

            Nat.attack(Josh);
        }
    }
}