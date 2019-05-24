using System;
using System.Linq;
using System.Collections.Generic;

namespace _07TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int countStations = int.Parse(Console.ReadLine());

            int currStation = 0;
            int fuel = 0;

            for (int i = 1; i <= countStations; i++)
            {
                int[] stationProps = Console.ReadLine().Split().Select(int.Parse).ToArray();

                int petrolAmount = stationProps[0];
                int distance = stationProps[1];

                fuel += petrolAmount;

                if (fuel>=distance)
                {
                    fuel -= distance;
                }
                else
                {
                    currStation = i;
                    fuel = 0;
                }
            }

            Console.WriteLine(currStation);
        }
    }
}
