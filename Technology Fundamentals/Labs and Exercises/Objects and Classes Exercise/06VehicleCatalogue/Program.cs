using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;

namespace _06VehicleCatalogue
{
    public class Program
    {
        public class Vehicles
        {
            public string Type { get; set; }
            public string Model { get; set; }
            public string Color { get; set; }
            public int HorsePower { get; set; }
        }
        public static void Main()
        {
            List<Vehicles> vehicles = new List<Vehicles>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                string[] tokens = input.Split();
                string type = tokens[0];
                string type1 = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(type);
                string model = tokens[1];
                string color = tokens[2];
                int hp = int.Parse(tokens[3]);

                vehicles.Add(new Vehicles
                {
                    Type = type1,
                    Model = model,
                    Color = color,
                    HorsePower = hp
                });
            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Close the Catalogue")
                {
                    break;
                }

                bool isPresent = vehicles.Any(x => x.Model == command);

                if (isPresent)
                {
                    var filtered = vehicles.Where(x => x.Model == command).ToList();

                    foreach (var currVehicle in filtered)
                    {
                        Console.WriteLine("Type: {0}", currVehicle.Type);
                        Console.WriteLine("Model: {0}", currVehicle.Model);
                        Console.WriteLine("Color: {0}", currVehicle.Color);
                        Console.WriteLine("Horsepower: {0}", currVehicle.HorsePower);
                    }
                }
            }

            var filterCars = vehicles.Where(x => x.Type == "Car").ToList();
            var filterTrucks = vehicles.Where(x => x.Type == "Truck").ToList();

            double totalCarHp = 0;

            foreach (var currCar in filterCars)
            {
                totalCarHp += currCar.HorsePower;
            }

            int totalCarsCount = filterCars.Count();
            double calcCarsHp = totalCarHp / totalCarsCount;

            double totalTruckHp = 0;

            foreach (var currTruck in filterTrucks)
            {
                totalTruckHp += currTruck.HorsePower;
            }

            int totalTrucksCount = filterTrucks.Count();
            double calcTruckHp = totalTruckHp / totalTrucksCount;

            if (totalCarsCount > 0)
            {
                Console.WriteLine("Cars have average horsepower of: {0:f2}.", calcCarsHp);
            }
            else
            {
                Console.WriteLine("Cars have average horsepower of: 0.00.");
            }
            if (totalTrucksCount > 0)
            {
                Console.WriteLine("Trucks have average horsepower of: {0:f2}.", calcTruckHp);
            }
            else
            {
                Console.WriteLine("Trucks have average horsepower of: 0.00.");
            }
        }
    }
}
