using System;
using System.Linq;
using System.Collections.Generic;

namespace _02HelloFrance
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            decimal budget = decimal.Parse(Console.ReadLine());

            if (budget==0m)
            {
                Console.WriteLine(0.00);
                Console.WriteLine($"Profit: {0.00}");
                Console.WriteLine("Time to go.");
                return;
            }

            decimal initialBudget = budget;

            List<decimal> newPrices = new List<decimal>();

            string[] tokens = input.Split("|",StringSplitOptions.RemoveEmptyEntries);

            foreach (string currProductAndPrice in tokens)
            {
                string[] productAndPrice = currProductAndPrice.Split("->",StringSplitOptions.RemoveEmptyEntries);

                string nameOfProduct = productAndPrice[0];
                decimal productInitialPrice = decimal.Parse(productAndPrice[1]);

                if (nameOfProduct == "Clothes")
                {
                    if (productInitialPrice>50.00m)
                    {
                        continue;
                    }
                    else
                    {
                        if (budget-productInitialPrice>=0)
                        {
                            budget -= productInitialPrice;
                            decimal priceToAdd = productInitialPrice * 1.40m;
                            newPrices.Add(priceToAdd);
                        }
                    }
                }
                else if (nameOfProduct == "Shoes")
                {
                    if (productInitialPrice>35.00m)
                    {
                        continue;
                    }
                    else
                    {
                        if (budget - productInitialPrice >= 0)
                        {
                            budget -= productInitialPrice;
                            decimal priceToAdd = productInitialPrice * 1.40m;
                            newPrices.Add(priceToAdd);
                        }
                    }
                }
                else if (nameOfProduct == "Accessories")
                {
                    if (productInitialPrice >20.50m)
                    {
                        continue;
                    }
                    else
                    {
                        if (budget - productInitialPrice >= 0)
                        {
                            budget -= productInitialPrice;
                            decimal priceToAdd = productInitialPrice * 1.40m;
                            newPrices.Add(priceToAdd);
                        }
                    }
                }
            }

            decimal priceForSelling = newPrices.Sum();
            decimal totalMoney = priceForSelling + budget;

            for (int i = 0; i < newPrices.Count; i++)
            {
                Console.Write($"{newPrices[i]:f2} ");
            }
            Console.WriteLine();

            
            decimal spentMoney = initialBudget - budget;
            decimal profit = priceForSelling - spentMoney;
            Console.WriteLine($"Profit: {profit:f2}");

            if (totalMoney>=150m)
            {
                Console.WriteLine("Hello, France!");
            }
            else
            {
                Console.WriteLine("Time to go.");
            }
        }
    }
}
