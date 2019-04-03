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
            double milkInL = double.Parse(Console.ReadLine());

            double chocoPrice = 0.65 * chocolates;
            double milkPrice = milkInL * 2.70;
            double tangerines =Math.Floor(chocolates - (chocolates * 0.35));
            double tangerinesPrice = tangerines * 0.20;
            double total = tangerinesPrice + milkPrice + chocoPrice;

            if (budget >=total)
            {
                Console.WriteLine("You got this, {0:f2} money left!",budget-total);
            }
            else
            {
                Console.WriteLine("Not enough money, you need {0:f2} more!",total-budget);
            }
        }
    }
}
