using System;

namespace _07TheatrePromotion
{
    class Program
    {
        static void Main(string[] args)
        {
            string period = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            int price = 0;

            if (age >= 0 && age <= 18)
            {
                if (period == "Weekday")
                {
                    price = 12;
                }
                else if (period == "Weekend")
                {
                    price = 15;
                }
                else
                {
                    price = 5;
                }
            }
            else if (age > 18 && age <= 64)
            {
                if (period == "Weekday")
                {
                    price = 18;
                }
                else if (period == "Weekend")
                {
                    price = 20;
                }
                else
                {
                    price = 12;
                }
            }
            else if (age > 64 && age <= 122)
            {
                if (period == "Weekday")
                {
                    price = 12;
                }
                else if (period == "Weekend")
                {
                    price = 15;
                }
                else
                {
                    price = 10;
                }
            }
            else
            {
                Console.WriteLine("Error!");
                return;
            }

            Console.WriteLine("{0}$", price);
        }
    }
}
