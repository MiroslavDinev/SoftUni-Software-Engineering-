using System;
using System.Collections.Generic;

namespace _04ListOfProducts
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> products = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string product = Console.ReadLine();
                products.Add(product);
            }
            products.Sort();

            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine("{0}.{1}", i + 1, products[i]);
            }
        }
    }
}
