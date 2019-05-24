using System;
using System.Linq;
using System.Collections.Generic;

namespace _06ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> cars = new HashSet<string>();

            while (true)
            {
                string car = Console.ReadLine();

                if (car == "END")
                {
                    break;
                }

                string[] tokens = car.Split(", ");
                string direction = tokens[0];
                string carNum = tokens[1];

                if (direction=="IN")
                {
                    cars.Add(carNum);
                }
                else
                {
                    if (cars.Contains(carNum))
                    {
                        cars.Remove(carNum);
                    }
                }
            }

            if (cars.Count==0)
            {
                Console.WriteLine("Parking Lot is Empty");
                return;
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
