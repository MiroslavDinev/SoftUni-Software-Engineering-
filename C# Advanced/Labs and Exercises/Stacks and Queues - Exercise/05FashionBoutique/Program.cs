using System;
using System.Collections.Generic;
using System.Linq;

namespace _05FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int capacity = int.Parse(Console.ReadLine());

            int racksCount = 1;

            Stack<int> clothesValues = new Stack<int>(input);

            int sum = 0;

            int currCapacity = capacity;

            while (clothesValues.Count>0)
            {
                int currValue = clothesValues.Peek();

                if (sum+currValue < currCapacity)
                {
                    sum += currValue;
                    clothesValues.Pop();
                }
                else if (sum + currValue == currCapacity)
                {
                    clothesValues.Pop();
                    sum = 0;
                    currCapacity = capacity;

                    if (clothesValues.Count>0)
                    {
                        racksCount++;
                    }
                }
                else
                {
                    sum = 0;
                    currCapacity = capacity;
                    racksCount++;
                }
            }

            Console.WriteLine(racksCount);
        }
    }
}
