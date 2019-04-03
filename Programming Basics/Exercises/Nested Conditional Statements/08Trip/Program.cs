using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal budget = decimal.Parse(Console.ReadLine());
            string season = Console.ReadLine().ToLower();

            if (budget<=100)
            {
                if (season == "summer")
                {
                    decimal price = budget * 0.30M;
                    Console.WriteLine("Somewhere in Bulgaria");
                    Console.WriteLine("Camp - {0:f2}", price);
                }
                else if (season == "winter")
                {
                    decimal price = budget * 0.70M;
                    Console.WriteLine("Somewhere in Bulgaria");
                    Console.WriteLine("Hotel - {0:f2}", price);
                }
            }
            else if (budget > 100 && budget <= 1000)
            {
                if (season == "summer")
                {
                    decimal price = budget * 0.40M;
                    Console.WriteLine("Somewhere in Balkans");
                    Console.WriteLine("Camp - {0:f2}", price);
                }
                else if (season == "winter")
                {
                    decimal price = budget * 0.80M;
                    Console.WriteLine("Somewhere in Balkans");
                    Console.WriteLine("Hotel - {0:f2}", price);
                }
            }
            else
            {
                decimal price = budget * 0.90M;
                Console.WriteLine("Somewhere in Europe");
                Console.WriteLine("Hotel - {0:f2}",price);
            }
        }
    }
}
