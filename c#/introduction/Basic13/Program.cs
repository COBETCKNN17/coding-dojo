using System;
using System.Collections.Generic; // To use lists

namespace Basic13
{
    class Program
    {

        // 1. Print 1-255

        public static void print1to255()
        {
            for (int i = 1; i <= 255; i++)
            {
                Console.WriteLine(i);
            }
        }

        // 2. Print odd numbers between 1-255
        
        public static void printOdds()
        {
            for (int i = 1; i <= 255; i++)
            {
                if (i % 2 == 1)
                {
                    Console.WriteLine(i);
                }
            }
        }    

        // 3. Print Sum
        
        public static void printSum()
        {
            int sum = 0;

            for (int i = 1; i <= 255; i++)
            {
                sum += i;
                Console.WriteLine("Number: " + i + " - Sum: " + sum);
            }
        }

        // 4. Iterating through an Array

        public static void iterateArray(Array arr)
        {
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }

        // 5. Find Max
        
        public static void findMax(int[] arr)
        {
            int max = arr[0];

            foreach (var item in arr)
            {
                if (item > max)
                {
                    max = item;
                }
            }

            Console.WriteLine("Max value is: " + max);
            
        }    

        // 6. Get Average
        
        public static void getAvg(int[] arr)
        {
           int sum = 0;
           int count = 0;

           foreach (var item in arr)
            {
                sum += item;
                count++;
            }

            int avg = sum/count;

            Console.WriteLine("Average is: " + avg);
        }

        // 7. Array with Odd Numbers

        public static void oddArray()
        {
            List<int> y = new List<int>();

            for(int i = 0; i <= 255; i++)
            {
                if(i % 2 != 0)
                {
                    y.Add(i);
                }
            }

            foreach (var item in y)
            {
                Console.WriteLine(item);
            }
        }

        // 8. Greater than Y
        
        public static void greaterThanY(int[] arr, int y)
        {
            int count = 0;

            foreach (var item in arr)
            {
                if (item > y)
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }    

        // 9. Square the Values
        
        public static void squareValues(int[] x)
        {
            for (int i = 0; i < x.Length; i++)
            {
                x[i] = x[i]*x[i];
            }

            foreach (var item in x)
            {
                Console.WriteLine(item);
            }
            
        }

        // 10. Eliminate Negative Numbers
        
        public static void eliminateNegatives(int[] arr)
        {
            for  (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < 0)
                {
                    arr[i] = 0;
                }

                Console.WriteLine(arr[i]);
            }
        }    

        // 11. Min, Max, and Average
        
        public static void minMaxAvg(int[] arr)
        {
            int max = arr[0];
            int min = arr[0];
            int sum = 0;
            int count = 0;

            foreach (var item in arr)
            {
                if (item > max)
                {
                    max = item;
                }
                if (item < min)
                {
                    min = item;
                }
                sum += item;
                count++;
            }

            int avg = sum/count;
            Console.WriteLine("Max is: " + max + " - Min is: " + min + " - Average is: " + avg);

        }

        // 12. Shifting the values in an array
        
        public static void arrayShift(int[] arr)
        {
            for (int i = 0; i < arr.Length-1; i++)
            {
                arr[i] = arr[i+1];
            }

            arr[arr.Length-1] = 0;

            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }    

        // 13. Number to String
        
        public static void numToString(int [] arr)
        {
            object[] newArr = new object[arr.Length];

            for  (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < 0)
                {
                    newArr[i] = "Dojo";
                }
                else
                {
                    newArr[i] = arr[i];
                }
            }

            foreach (var item in newArr)
            {
                Console.WriteLine(item);
            }

        }

        // Main

        static void Main(string[] args)
        {
            int[] newArray = {1,3,-5,7,-9,13};
            //print1to255();
            //printOdds();
            //printSum();
            //iterateArray(newArray);
            //findMax(newArray);
            //getAvg(newArray);
            //oddArray();
            //greaterThanY(newArray, 5);
            //squareValues(newArray);
            //eliminateNegatives(newArray);
            //minMaxAvg(newArray);
            //arrayShift(newArray);
            numToString(newArray);
        }

    }
}
