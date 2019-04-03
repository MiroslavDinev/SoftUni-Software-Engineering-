using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceToMoon
{
    class Program
    {
        static void Main(string[] args)
        {
            double avgSpeed = double.Parse(Console.ReadLine());
            double fuelPer100Km = double.Parse(Console.ReadLine());

            int distance = 2 * 384400;
            double hours =Math.Ceiling((distance / avgSpeed) +3);
            double fuelNeeded = (distance * fuelPer100Km)/ 100;

            Console.WriteLine(hours);
            Console.WriteLine(fuelNeeded);
        }
    }
}
