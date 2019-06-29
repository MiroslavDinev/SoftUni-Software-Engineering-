using System;
using System.Linq;
using System.Collections.Generic;

namespace _01SpaceshipCrafting
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] chemicalLiquidsInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] physicalItemsInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> liquids = new Queue<int>(chemicalLiquidsInput);
            Stack<int> physicalItems = new Stack<int>(physicalItemsInput);

            int totalGlass = 0;
            int totalAluminuim = 0;
            int totalLithium = 0;
            int totalCarbonFiber = 0;

            while (liquids.Any() && physicalItems.Any())
            {
                int currLiquid = liquids.Dequeue();
                int currPhysicalItem = physicalItems.Peek();

                if(currLiquid+currPhysicalItem==25)
                {
                    physicalItems.Pop();
                    totalGlass++;
                }
                else if (currLiquid + currPhysicalItem == 50)
                {
                    physicalItems.Pop();
                    totalAluminuim++;
                }
                else if (currLiquid + currPhysicalItem == 75)
                {
                    physicalItems.Pop();
                    totalLithium++;
                }
                else if (currLiquid + currPhysicalItem == 100)
                {
                    physicalItems.Pop();
                    totalCarbonFiber++;
                }
                else
                {
                    currPhysicalItem += 3;
                    physicalItems.Pop();
                    physicalItems.Push(currPhysicalItem);
                }
            }

            if(totalGlass!=0 && totalCarbonFiber!=0 && totalAluminuim!=0 && totalLithium!=0)
            {
                Console.WriteLine("Wohoo! You succeeded in building the spaceship!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to build the spaceship.");
            }

            if(liquids.Any())
            {
                Console.WriteLine($"Liquids left: {string.Join(", ",liquids)}");
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }

            if(physicalItems.Any())
            {
                Console.WriteLine($"Physical items left: {string.Join(", ",physicalItems)}");
            }
            else
            {
                Console.WriteLine("Physical items left: none");
            }

            Console.WriteLine($"Aluminium: {totalAluminuim}");
            Console.WriteLine($"Carbon fiber: {totalCarbonFiber}");
            Console.WriteLine($"Glass: {totalGlass}");
            Console.WriteLine($"Lithium: {totalLithium}");
        }
    }
}
