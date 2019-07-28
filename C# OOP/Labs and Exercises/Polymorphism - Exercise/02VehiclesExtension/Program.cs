using System;
using System.Collections.Generic;

namespace _02VehiclesExtension
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            VehicleFactory vehicleFactory = new VehicleFactory();

            string[] carArgs = Console.ReadLine().Split();

            var car = vehicleFactory.Create(carArgs);

            vehicles.Add(car);

            string[] truckArgs = Console.ReadLine().Split();

            var truck = vehicleFactory.Create(truckArgs);

            vehicles.Add(truck);

            string[] busArgs = Console.ReadLine().Split();

            var bus = vehicleFactory.Create(busArgs);

            vehicles.Add(bus);

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] tokens = Console.ReadLine().Split();

                string action = tokens[0];

                if (action == "Drive")
                {
                    string type = tokens[1];
                    double distance = double.Parse(tokens[2]);

                    if (type == "Car")
                    {
                        Console.WriteLine(car.Drive(distance));
                    }
                    else if (type == "Truck")
                    {
                        Console.WriteLine(truck.Drive(distance));
                    }
                    else
                    {
                        Console.WriteLine(bus.Drive(distance));
                    }
                }
                else if (action == "Refuel")
                {
                    try
                    {
                        string type = tokens[1];
                        double amount = double.Parse(tokens[2]);

                        if (type == "Car")
                        {
                            car.Refuel(amount);
                        }
                        else if (type == "Truck")
                        {
                            truck.Refuel(amount);
                        }
                        else
                        {
                            bus.Refuel(amount);
                        }
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }                   
                }
                else
                {
                    double distance = double.Parse(tokens[2]);

                    Bus bus1 = (Bus)bus;
                    Console.WriteLine(bus1.DriveEmpty(distance)); 
                }
            }

            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }
        }
    }
}
