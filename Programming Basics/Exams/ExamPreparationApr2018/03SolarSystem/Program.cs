using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            string planet = Console.ReadLine();
            int daysSpent = int.Parse(Console.ReadLine());

            double distance = 0;
            double totalDays = 0;

            if (planet == "Mercury")
            {
                distance = 2 *0.61;

                if (daysSpent <=7)
                {
                    Console.WriteLine("Distance: {0:f2}",distance);
                    totalDays = distance * 226 +daysSpent;
                    Console.WriteLine("Total number of days: {0:f2}",totalDays);
                }
                else if (daysSpent >7)
                {
                    Console.WriteLine("Invalid number of days!");
                }
            }
            else if (planet == "Venus")
            {
                distance = 2 * 0.28;

                if (daysSpent <= 14)
                {
                    Console.WriteLine("Distance: {0:f2}", distance);
                    totalDays = distance * 226 + daysSpent;
                    Console.WriteLine("Total number of days: {0:f2}", totalDays);
                }
                else if (daysSpent > 14)
                {
                    Console.WriteLine("Invalid number of days!");
                }
            }
            else if (planet == "Mars")
            {
                distance = 2 * 0.52;

                if (daysSpent <= 20)
                {
                    Console.WriteLine("Distance: {0:f2}", distance);
                    totalDays = distance * 226 + daysSpent;
                    Console.WriteLine("Total number of days: {0:f2}", totalDays);
                }
                else if (daysSpent > 20)
                {
                    Console.WriteLine("Invalid number of days!");
                }
            }
            else if (planet == "Jupiter")
            {
                distance = 2 * 4.2;

                if (daysSpent <= 5)
                {
                    Console.WriteLine("Distance: {0:f2}", distance);
                    totalDays = distance * 226 + daysSpent;
                    Console.WriteLine("Total number of days: {0:f2}", totalDays);
                }
                else if (daysSpent > 5)
                {
                    Console.WriteLine("Invalid number of days!");
                }
            }
            else if (planet == "Saturn")
            {
                distance = 2 * 8.52;

                if (daysSpent <= 3)
                {
                    Console.WriteLine("Distance: {0:f2}", distance);
                    totalDays = distance * 226 + daysSpent;
                    Console.WriteLine("Total number of days: {0:f2}", totalDays);
                }
                else if (daysSpent > 3)
                {
                    Console.WriteLine("Invalid number of days!");
                }
            }
            else if (planet == "Uranus")
            {
                distance = 2 * 18.11;

                if (daysSpent <= 3)
                {
                    Console.WriteLine("Distance: {0:f2}", distance);
                    totalDays = distance * 226 + daysSpent;
                    Console.WriteLine("Total number of days: {0:f2}", totalDays);
                }
                else if (daysSpent > 3)
                {
                    Console.WriteLine("Invalid number of days!");
                }
            }
            else if (planet == "Neptune")
            {
                distance = 2 * 29.09;

                if (daysSpent <= 2)
                {
                    Console.WriteLine("Distance: {0:f2}", distance);
                    totalDays = distance * 226 + daysSpent;
                    Console.WriteLine("Total number of days: {0:f2}", totalDays);
                }
                else if (daysSpent > 2)
                {
                    Console.WriteLine("Invalid number of days!");
                }
            }
            else
            {
                Console.WriteLine("Invalid planet name!");
            }
        }
    }
}
