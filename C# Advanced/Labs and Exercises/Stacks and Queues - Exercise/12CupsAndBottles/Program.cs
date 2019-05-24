using System;
using System.Linq;
using System.Collections.Generic;

namespace _12CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cupsCapacity = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] bottlesCapacity = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int wasted = 0;

            Stack<int> bottles = new Stack<int>(bottlesCapacity);
            Stack<int> cups = new Stack<int>(cupsCapacity.Reverse());

            while (bottles.Count>0 && cups.Count>0)
            {
                int currBottle = bottles.Peek();
                int currCup = cups.Peek();

                if (currBottle == currCup)
                {
                    bottles.Pop();
                    cups.Pop();
                }
                else if (currBottle>currCup)
                {
                    wasted += currBottle - currCup;
                    bottles.Pop();
                    cups.Pop();
                }
                else
                {
                    currCup -= currBottle;
                    bottles.Pop();
                    cups.Pop();
                    cups.Push(currCup);
                }
            }

            if (bottles.Count>0)
            {
                Console.WriteLine("Bottles: " + string.Join(" ",bottles));
                Console.WriteLine($"Wasted litters of water: {wasted}");
            }
            else
            {
                Console.WriteLine("Cups: " + string.Join(" ", cups));
                Console.WriteLine($"Wasted litters of water: {wasted}");
            }
        }
    }
}
