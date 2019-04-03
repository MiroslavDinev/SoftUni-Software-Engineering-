using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());

            double studioPrice = 0.0;
            double apartmentPrice = 0.0;

            double studioDiscount = 0.00;
            double apartmentDiscount = 0.00;

            if (month == "May" || month == "October")
            {
                studioPrice = 50;
                apartmentPrice = 65;
            }
            else if (month == "June" || month == "September")
            {
                studioPrice = 75.20;
                apartmentPrice = 68.70;
            }
            else if (month == "July" || month == "August")
            {
                studioPrice = 76;
                apartmentPrice = 77;
            }

            if ((nights > 7 && nights < 14) && month == "May" || month == "October")
            {
                studioDiscount = 0.05;
            }
            else if (nights > 14 && month == "May" || month == "October")
            {
                studioDiscount = 0.30;
                apartmentDiscount = 0.10;
            }
            else if (nights > 14 && month == "June" || month == "September")
            {
                studioDiscount = 0.20;
                apartmentDiscount = 0.10;
            }
            else if (nights > 14 && month == "July" || month == "August")
            {
                apartmentDiscount = 0.10;
            }
            Console.WriteLine("Apartment: {0:f2} lv", apartmentPrice= nights * (apartmentPrice-(apartmentDiscount*apartmentPrice)));
            Console.WriteLine("Studio: {0:f2} lv", studioPrice= nights * (studioPrice-(studioDiscount*studioPrice)));
        }   
    }
}
