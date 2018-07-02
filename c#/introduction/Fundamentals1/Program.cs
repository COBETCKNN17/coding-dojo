using System;
using System.Collections.Generic; // To use lists

namespace Fundamentals1
{
    class Program
    {
        public static void print1to255()
        {
            for (int i = 1; i <= 255; i++)
            {
                Console.WriteLine(i);
            }
        }

        public static void divideBy3and5()
        {
            for (int i = 1; i <= 100; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }

        public static void fizzBuzz()
        {
            for (int i = 1; i <= 100; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine("Fizzbuzz");
                }
                else if (i % 3 == 0)
                {
                    Console.WriteLine("Fizz");
                }
                else if (i % 5 == 0)
                {
                    Console.WriteLine("Buzz");
                }
                else
                {
                    Console.WriteLine(i);
                }

            }
        }

        static void Main(string[] args)
        {
            print1to255();
            divideBy3and5();
            fizzBuzz();
        }

    }
}
