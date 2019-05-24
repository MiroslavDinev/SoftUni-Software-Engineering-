using System;
using System.Linq;
using System.Collections.Generic;

namespace _03ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> shopProductPrice = new Dictionary<string, Dictionary<string, double>>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Revision")
                {
                    break;
                }

                string[] tokens = command.Split(", ");
                string shop = tokens[0];
                string product = tokens[1];
                double price = double.Parse(tokens[2]);

                if (!shopProductPrice.ContainsKey(shop))
                {
                    shopProductPrice.Add(shop, new Dictionary<string, double>());
                    shopProductPrice[shop].Add(product, price);
                }
                else
                {
                    shopProductPrice[shop].Add(product, price);
                }
            }

            foreach (var kvp in shopProductPrice.OrderBy(x=>x.Key))
            {
                string shop = kvp.Key;

                Console.WriteLine($"{shop}->");

                foreach (var inner in kvp.Value)
                {
                    string product = inner.Key;
                    double price = inner.Value;

                    Console.WriteLine($"Product: {product}, Price: {price}");
                }
            }
        }
    }
}
