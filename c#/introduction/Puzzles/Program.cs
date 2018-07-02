using System;
using System.Collections.Generic;
using System.Text;

namespace Puzzles
{
    class Program
    {

        public static void randomArray()
        {
            int[] randomArr = new int[10];
            Random random = new Random();
            
            for(int i = 0; i < randomArr.Length; i++)
            {
                randomArr[i] = random.Next(5,25);
            }

            int min = randomArr[0];
            int max = randomArr[0];
            int sum = 0;

            for (int i = 0; i < randomArr.Length; i++)
            {
                if (min > randomArr[i])
                {
                    min = randomArr[i];
                }
                else if (max < randomArr[i])
                {
                    max = randomArr[i];
                }

                sum += randomArr[i];
            }

            foreach (var item in randomArr)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Max value is: " + max + " - Min vlaue is: " + min + " - Sum: " + sum);
        }
        

        public static String coinFlip()
        {
            Random random = new Random();
            int coin = random.Next(0,2);

            Console.WriteLine("Flipped a coin!");

            if (coin == 0)
            {
                Console.WriteLine("Heads");
                return "Heads";
            }
            else
            {
                Console.WriteLine("Tails");
                return "Tails";
            }
        }

        public static Double multiCoinFlip(int num)
        {
            int headCount = 0;
            int tailCount = 0;

            for (int i = 1; i <= num; i++)
            {
                if(coinFlip()=="Heads")
                {
                    headCount++;
                }

                else
                {
                    tailCount++;
                }
            }

            Console.WriteLine("Total Heads: " + headCount + " - Total Tails: " + tailCount);

            if (headCount < tailCount)
            {
                return ((Double)tailCount/(Double)headCount);
            }

            else
            {
                return ((Double)tailCount/(Double)headCount);
            }
        }

        public static String[] Names()
        {
            String[] nameArr = {"Todd", "Tiffany", "Charlie", "Geneva", "Sydney"};
            String[] randomArr = new string[nameArr.Length];
            Random random = new Random();

            List<String> randomNames = new List<String>();  
            String thisName = "";

            while (randomNames.Count < 5)
            {
                thisName = nameArr[random.Next(0,nameArr.Length)];

                if(!randomNames.Contains(thisName))
                {
                    randomNames.Add(thisName);
                }  
            }

            int i = 0;

            List<String> namesOverFive = new List<String>();

            Console.WriteLine("New Name Order:");

            foreach (String item in randomNames)
            {
                randomArr[i] = item;

                Console.WriteLine(randomArr[i]);

                if ((int)(randomArr[i].Length) > 5)
                {
                    namesOverFive.Add(randomArr[i]);
                }

                i++;
            }
            
            Console.WriteLine("---");
            Console.WriteLine("Names With More Than Five Characters:");

            foreach (String item in namesOverFive)
            {
                Console.WriteLine(item);   
            }

            
            string[] returnArr = new string[randomNames.Count];
            returnArr = randomNames.ToArray();

            return returnArr;
                
        }

        static void Main(string[] args)
        {
            //randomArray();
            //coinFlip();
            //multiCoinFlip(5);
            Names();
        }
    }
}
