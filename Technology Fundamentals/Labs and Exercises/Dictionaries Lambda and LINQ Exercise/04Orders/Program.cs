using System;
using System.Collections.Generic;

namespace _04Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            var priceProduct = new Dictionary<string, decimal>();
            var quantityProduct = new Dictionary<string, int>();

            while (true)
            {
                string[] tokens = Console.ReadLine().Split();

                string product = tokens[0];

                if (product == "buy")
                {
                    break;
                }

                decimal price = decimal.Parse(tokens[1]);
                int quantity = int.Parse(tokens[2]);

                if (priceProduct.ContainsKey(product) == false || quantityProduct.ContainsKey(product) == false)
                {
                    priceProduct[product] = price;
                    quantityProduct[product] = quantity;
                }
                else
                {
                    priceProduct[product] = price;
                    quantityProduct[product] += quantity;
                }
            }

            foreach (var kvp in quantityProduct)
            {
                string product = kvp.Key;
                int quantity = kvp.Value;
                decimal price = priceProduct[product];
                decimal totalPrice = price * quantity;

                Console.WriteLine("{0} -> {1}", product, totalPrice);
            }
        }
    }
}
