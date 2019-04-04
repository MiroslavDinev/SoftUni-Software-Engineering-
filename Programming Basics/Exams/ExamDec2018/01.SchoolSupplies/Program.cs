using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SchoolSupplies
{
    class Program
    {
        static void Main(string[] args)
        {
            int pensPkgs = int.Parse(Console.ReadLine());
            int markersPkgs = int.Parse(Console.ReadLine());
            double liters = double.Parse(Console.ReadLine());
            double discount = double.Parse(Console.ReadLine());

            double discountPercent = discount / 100.0;

            double pensPrice = 5.80 * pensPkgs;
            double markersPrice = 7.20 * markersPkgs;
            double litersPrice = 1.20 * liters;

            double totalPrice = pensPrice + markersPrice + litersPrice;

            double afterDiscount = totalPrice - (totalPrice * discountPercent);

            Console.WriteLine("{0:f3}",afterDiscount);
        }
    }
}
