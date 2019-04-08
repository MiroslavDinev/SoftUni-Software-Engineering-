using System;

namespace _03Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int personsCount = int.Parse(Console.ReadLine());
            string typeGroup = Console.ReadLine();
            string weekday = Console.ReadLine();

            double price = 0;
            double totalPrice = 0;

            if (weekday == "Friday")
            {
                if (typeGroup == "Students")
                {

                    if (personsCount >= 30)
                    {
                        totalPrice = 8.45 * personsCount;
                        totalPrice = totalPrice - (totalPrice * 0.15);
                    }
                    else
                    {
                        price = 8.45;
                        totalPrice = price * personsCount;
                    }
                }
                else if (typeGroup == "Business")
                {
                    if (personsCount >= 100)
                    {
                        price = 10.90;
                        totalPrice = price * (personsCount - 10);
                    }
                    else
                    {
                        totalPrice = 10.90 * personsCount;
                    }
                }
                else if (typeGroup == "Regular")
                {
                    if (personsCount >= 10 && personsCount <= 20)
                    {
                        totalPrice = 15.0 * personsCount;
                        totalPrice = totalPrice - (totalPrice * 0.05);
                    }
                    else
                    {
                        totalPrice = 15.0 * personsCount;
                    }
                }
            }
            else if (weekday == "Saturday")
            {
                if (typeGroup == "Students")
                {

                    if (personsCount >= 30)
                    {
                        totalPrice = 9.80 * personsCount;
                        totalPrice = totalPrice - (totalPrice * 0.15);
                    }
                    else
                    {
                        price = 9.80;
                        totalPrice = price * personsCount;
                    }
                }
                else if (typeGroup == "Business")
                {
                    if (personsCount >= 100)
                    {
                        price = 15.60;
                        totalPrice = price * (personsCount - 10);
                    }
                    else
                    {
                        totalPrice = 15.60 * personsCount;
                    }
                }
                else if (typeGroup == "Regular")
                {
                    if (personsCount >= 10 && personsCount <= 20)
                    {
                        totalPrice = 20.0 * personsCount;
                        totalPrice = totalPrice - (totalPrice * 0.05);
                    }
                    else
                    {
                        totalPrice = 20.0 * personsCount;
                    }
                }
            }
            if (weekday == "Sunday")
            {
                if (typeGroup == "Students")
                {

                    if (personsCount >= 30)
                    {
                        totalPrice = 10.46 * personsCount;
                        totalPrice = totalPrice - (totalPrice * 0.15);
                    }
                    else
                    {
                        price = 10.46;
                        totalPrice = price * personsCount;
                    }
                }
                else if (typeGroup == "Business")
                {
                    if (personsCount >= 100)
                    {
                        price = 16.0;
                        totalPrice = price * (personsCount - 10);
                    }
                    else
                    {
                        totalPrice = 16.0 * personsCount;
                    }
                }
                else if (typeGroup == "Regular")
                {
                    if (personsCount >= 10 && personsCount <= 20)
                    {
                        totalPrice = 22.5 * personsCount;
                        totalPrice = totalPrice - (totalPrice * 0.05);
                    }
                    else
                    {
                        totalPrice = 22.5 * personsCount;
                    }
                }
            }
            Console.WriteLine("Total price: {0:f2}", totalPrice);
        }
    }
}
