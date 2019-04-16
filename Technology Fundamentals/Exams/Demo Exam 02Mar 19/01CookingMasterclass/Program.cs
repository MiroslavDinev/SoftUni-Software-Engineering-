using System;

namespace _01CookingMasterclass
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double pricePkgFlour = double.Parse(Console.ReadLine());
            double priceSingleEgg = double.Parse(Console.ReadLine());
            double priceSingleApron = double.Parse(Console.ReadLine());

            double totalEggPrice = students * 10 * priceSingleEgg;

            double apronsNeeded = Math.Ceiling(students * 1.2);
            double totalApronPrice = apronsNeeded * priceSingleApron;

            int freePkgFlour = students / 5;
            int flourToBuy = students - freePkgFlour;
            double totalPriceFlour = flourToBuy * pricePkgFlour;

            double totalCost = totalApronPrice + totalEggPrice + totalPriceFlour;

            if (totalCost>budget)
            {
                Console.WriteLine($"{totalCost-budget:f2}$ more needed.");
            }
            else
            {
                Console.WriteLine($"Items purchased for {totalCost:f2}$.");
            }
        }
    }
}
