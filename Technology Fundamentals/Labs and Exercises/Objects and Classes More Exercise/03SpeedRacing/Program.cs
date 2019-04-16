using System;
using System.Linq;
using System.Collections.Generic;

namespace _03SpeedRacing
{
    public class Car
    {
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKm { get; set; }
        public double TravelledDistance { get; set; }

        public void Drive (int distance)
        {
            if (FuelAmount<distance * FuelConsumptionPerKm)
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
            else
            {
                FuelAmount -= distance * FuelConsumptionPerKm;
                TravelledDistance += distance;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();
            
            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string name = tokens[0];
                int fuelAmount = int.Parse(tokens[1]);
                double fuelPerKm = double.Parse(tokens[2]);

                cars.Add(new Car
                {
                    Model = name,
                    FuelAmount = fuelAmount,
                    FuelConsumptionPerKm = fuelPerKm
                });
            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                string[] tokens = command.Split();
                string model = tokens[1];
                int km = int.Parse(tokens[2]);

                cars.Where(x => x.Model == model).ToList().ForEach(x => x.Drive(km));
            }

            foreach (var currCar in cars)
            {
                Console.WriteLine($"{currCar.Model} {currCar.FuelAmount:f2} {currCar.TravelledDistance}");
            }
        }
    }
}
