using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int chocolates = int.Parse(Console.ReadLine());
            double milk = double.Parse(Console.ReadLine());

            double chocoPrice = 0.65 * chocolates;
            double milkPrice = 2.70 * milk;
            double tangerines = Math.Floor(chocolates - (chocolates * 0.35));
            double tangerinesPrice = tangerines * 0.20;
            double totalPrice = tangerinesPrice + chocoPrice + milkPrice;

            if (budget >= totalPrice)
            {
                Console.WriteLine("You got this, {0:f2} money left!",budget-totalPrice);
            }
            else
            {
                Console.WriteLine("Not enough money, you need {0:f2} more!",totalPrice-budget);
            }
        }
    }
}
