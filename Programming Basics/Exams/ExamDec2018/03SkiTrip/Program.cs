using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03SkiTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            string evaluation = Console.ReadLine();

            int nightsSpent = days - 1;

            double pricePerNight = 0;
            double totalPrice = 0;

            if (type == "room for one person")
            {
                pricePerNight = 18.0;

                totalPrice = pricePerNight * nightsSpent;

                if (evaluation == "positive")
                {
                    totalPrice = totalPrice + (totalPrice * 0.25);
                }
                else if (evaluation == "negative")
                {
                    totalPrice = totalPrice - (totalPrice * 0.10);
                }
            }
            else if (type == "apartment")
            {
                pricePerNight = 25.0;

                totalPrice = pricePerNight * nightsSpent;

                if (nightsSpent < 10)
                {
                    totalPrice = totalPrice - (totalPrice * 0.30);
                }
                else if (nightsSpent >=10 && nightsSpent <=15)
                {
                    totalPrice = totalPrice - (totalPrice * 0.35);
                }
                else if (nightsSpent > 15)
                {
                    totalPrice = totalPrice - (totalPrice * 0.50);
                }

                if (evaluation == "positive")
                {
                    totalPrice = totalPrice + (totalPrice * 0.25);
                }
                else if (evaluation == "negative")
                {
                    totalPrice = totalPrice - (totalPrice * 0.10);
                }
            }
            else if (type == "president apartment")
            {
                pricePerNight = 35.0;

                totalPrice = pricePerNight * nightsSpent;

                if (nightsSpent < 10)
                {
                    totalPrice = totalPrice - (totalPrice * 0.10);
                }
                else if (nightsSpent >= 10 && nightsSpent <= 15)
                {
                    totalPrice = totalPrice - (totalPrice * 0.15);
                }
                else if (nightsSpent > 15)
                {
                    totalPrice = totalPrice - (totalPrice * 0.20);
                }

                if (evaluation == "positive")
                {
                    totalPrice = totalPrice + (totalPrice * 0.25);
                }
                else if (evaluation == "negative")
                {
                    totalPrice = totalPrice - (totalPrice * 0.10);
                }
            }

            Console.WriteLine("{0:f2}",totalPrice);

        }
    }
}
