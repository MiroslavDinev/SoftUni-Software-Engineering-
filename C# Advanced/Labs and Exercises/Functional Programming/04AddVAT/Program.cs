using System;
using System.Linq;
using System.Collections.Generic;

namespace _04AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            List<decimal> prices = Console.ReadLine().Split(", ").Select(decimal.Parse).ToList();

            foreach (var price in prices)
            {
                Console.WriteLine($"{price*1.2m}");
            }
        }
    }
}
