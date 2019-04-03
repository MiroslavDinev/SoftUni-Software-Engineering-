using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerAndChips
{
    class Program
    {
        static void Main(string[] args)
        {
            string fanName = Console.ReadLine();
            double budget = double.Parse(Console.ReadLine());
            int beerBottles = int.Parse(Console.ReadLine());
            int chipsPackages = int.Parse(Console.ReadLine());

            double beerPrice = 1.20;
            double chipsPrice = (beerBottles * beerPrice) * 0.45;
            double totalMoney =Math.Ceiling(chipsPrice * chipsPackages) + (beerPrice * beerBottles);

            double moneyLeft = budget - totalMoney;
            double moneyNeeded = totalMoney - budget;

            if (budget >= totalMoney)
            {
                Console.WriteLine("{0} bought a snack and has {1:f2} leva left.", fanName, moneyLeft);
            }
            else if (budget < totalMoney)
            {
                Console.WriteLine("{0} needs {1:f2} more leva!",fanName,Math.Abs(moneyNeeded));
            }
        }
    }
}
