using System;

namespace _05Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string order = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());

            switch (order)
            {
                case "coffee": CoffeePrice(quantity); break;
                case "water": WaterPrice(quantity); break;
                case "coke": CokePrice(quantity); break;
                case "snacks": SnacksPrice(quantity); break;
                default:
                    break;
            }
        }

        public static void CoffeePrice (int quantity)
        {
            Console.WriteLine("{0:f2}",quantity*1.50);
        }

        public static void WaterPrice (int quantity)
        {
            Console.WriteLine("{0:f2}", quantity * 1.00);
        }

        public static void CokePrice (int quantity)
        {
            Console.WriteLine("{0:f2}", quantity * 1.40);
        }

        public static void SnacksPrice (int quantity)
        {
            Console.WriteLine("{0:f2}", quantity * 2.00);
        }
    }
}
