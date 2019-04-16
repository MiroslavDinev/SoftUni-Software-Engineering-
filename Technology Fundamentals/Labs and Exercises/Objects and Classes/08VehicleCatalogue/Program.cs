using System;
using System.Linq;
using System.Collections.Generic;

namespace _08VehicleCatalogue
{
    public class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Weight { get; set; }
    }
    public class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            List<Truck> trucks = new List<Truck>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                string[] tokens = input.Split("/");
                string type = tokens[0];

                if (type == "Car")
                {
                    string brand = tokens[1];
                    string model = tokens[2];
                    int hp = int.Parse(tokens[3]);

                    cars.Add(new Car
                    {
                        Brand = brand,
                        Model = model,
                        HorsePower = hp
                    });

                }
                else if (type == "Truck")
                {
                    string brand = tokens[1];
                    string model = tokens[2];
                    int weight = int.Parse(tokens[3]);

                    trucks.Add(new Truck
                    {
                        Brand = brand,
                        Model = model,
                        Weight = weight
                    });
                }
            }

            if (cars.Count>0)
            {
                Console.WriteLine("Cars:");

                foreach (var currCar in cars.OrderBy(x => x.Brand))
                {
                    Console.WriteLine($"{currCar.Brand}: {currCar.Model} - {currCar.HorsePower}hp");
                }
            }

            if (trucks.Count>0)
            {
                Console.WriteLine("Trucks:");

                foreach (var currTruck in trucks.OrderBy(x => x.Brand))
                {
                    Console.WriteLine($"{currTruck.Brand}: {currTruck.Model} - {currTruck.Weight}kg");
                }
            }  
        }
    }
}
