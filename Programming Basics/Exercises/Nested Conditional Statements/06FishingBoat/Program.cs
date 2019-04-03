using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06FishingBoat
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int persons = int.Parse(Console.ReadLine());

            double price = 0;

            if (season == "Spring")
            {
                price = 3000;
            }
            else if (season == "Summer" || season == "Autumn")
            {
                price = 4200;
            }
            else if (season == "Winter")
            {
                price = 2600;
            }

            if (persons <=6)
            {
                price = price - (price * 0.10);
            }
            else if (persons>6 && persons<=11)
            {
                price = price - (price * 0.15);
            }
            else if (persons>=12)
            {
                price = price - (price * 0.25);
            }

            if (persons %2==0 && season != "Autumn")
            {
                price = price - (price * 0.05);
            }

            if (budget >= price)
            {
                Console.WriteLine("Yes! You have {0:f2} leva left.",budget -price);
            }
            else
            {
                Console.WriteLine("Not enough money! You need {0:f2} leva.",price - budget);
            }
        }
    }
}
