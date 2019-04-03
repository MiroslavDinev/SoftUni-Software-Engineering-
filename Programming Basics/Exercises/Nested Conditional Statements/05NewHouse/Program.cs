using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05NewHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            string flower = Console.ReadLine();
            int numFlowers = int.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());

            double price = 0;

            if (flower == "Roses")
            {
                price = 5.00;
            }
            else if (flower == "Dahlias")
            {
                price = 3.80;
            }
            else if (flower == "Tulips")
            {
                price = 2.80;
            }
            else if (flower == "Narcissus")
            {
                price = 3.00;
            }
            else if (flower == "Gladiolus")
            {
                price = 2.50;
            }

            double totalPrice = price * numFlowers;

            if (flower == "Roses" && numFlowers>80)
            {
                totalPrice = totalPrice - (totalPrice * 0.10);
            }
            else if (flower == "Dahlias" && numFlowers>90)
            {
                totalPrice = totalPrice - (totalPrice * 0.15);
            }
            else if (flower == "Tulips" && numFlowers>80)
            {
                totalPrice = totalPrice - (totalPrice * 0.15);
            }
            else if (flower == "Narcissus" && numFlowers<120)
            {
                totalPrice = totalPrice + (totalPrice * 0.15);
            }
            else if (flower == "Gladiolus" && numFlowers<80)
            {
                totalPrice = totalPrice + (totalPrice * 0.20);
            }

            if (budget >= totalPrice)
            {
                Console.WriteLine($"Hey, you have a great garden with {numFlowers} {flower} and {budget - totalPrice:f2} leva left.");
            }
            else
            {
                Console.WriteLine("Not enough money, you need {0:f2} leva more.",totalPrice-budget);
            }
        }
    }
}
