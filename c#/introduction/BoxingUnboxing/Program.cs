using System;
using System.Collections.Generic; // To use lists

namespace BoxingUnboxing
{
    class Program
    {
        public static void BoxingUnboxing()
        {
            List<object> newList = new List<object>();
                newList.Add(7);
                newList.Add(28);
                newList.Add(-1);
                newList.Add(true);
                newList.Add("chair");

            int total = new int();
            total = 0;

            foreach (var item in newList)
            {
                Console.WriteLine(item);
                    if (item is int)
                    {
                        total += (int)item;
                    }
            }
            
            Console.WriteLine(total);

        }

        static void Main(string[] args)
        {
            BoxingUnboxing();
        }
    }
}
