using System;
using System.Collections.Generic;
using System.Text;

namespace _5SpecialCars
{
    public class Engine
    {
        private int horsePower;
        private double cubicCapacity;

        public int HorsePower { get; set; }

        public double CubicCapacity { get; set; }

        public Engine(int horsePower, double cubicCapacity)
        {
            this.HorsePower = horsePower;
            this.CubicCapacity = cubicCapacity;
        }
    }

    public class Tire
    {
        private int year;
        private double pressure;

        public int Year { get; set; }

        public double Pressure { get; set; }

        public Tire(int year, double pressure)
        {
            this.Year = year;
            this.Pressure = pressure;
        }
    }

    public class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;
        private Engine engine;
        private Tire[] tires;

        public Car()
        {
            this.Make = "VW";
            this.Model = "Golf";
            this.Year = 2025;
            this.FuelQuantity = 200;
            this.FuelConsumption = 10;
        }

        public Car(string make, string model, int year) : this()
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption) : this(make, model, year)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, Engine engine, Tire[] tires)
            : this(make, model, year, fuelQuantity, fuelConsumption)
        {
            this.Engine = engine;
            this.Tires = tires;
        }

        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; set; }

        public Engine Engine { get; set; }

        public Tire[] Tires { get; set; }

        public void Drive(double distance)
        {
            bool isEnoughFuel = this.FuelQuantity - ((distance * this.FuelConsumption) / 100) >= 0;

            if (isEnoughFuel)
            {
                this.FuelQuantity -= (distance * this.FuelConsumption) / 100;
            }
            else
            {
                throw new InvalidOperationException("Not enough fuel to perform this trip!");
            }
        }

        public string WhoAmI()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Make: {this.Make}");
            result.AppendLine($"Model: {this.Model}");
            result.AppendLine($"Year: {this.Year}");
            result.AppendLine($"Fuel: {this.FuelQuantity:f2}L");
            return result.ToString();
        }

        class Program
        {
            static void Main(string[] args)
            {
                List<Tire[]> tireSets = new List<Tire[]>();

                while (true)
                {
                    string command = Console.ReadLine();

                    if (command == "No more tires")
                    {
                        break;
                    }

                    string[] tokens = command.Split();

                    int year1 = int.Parse(tokens[0]);
                    int year2 = int.Parse(tokens[2]);
                    int year3 = int.Parse(tokens[4]);
                    int year4 = int.Parse(tokens[6]);
                    double pressure1 = double.Parse(tokens[1]);
                    double pressure2 = double.Parse(tokens[3]);
                    double pressure3 = double.Parse(tokens[5]);
                    double pressure4 = double.Parse(tokens[7]);

                    var tires = new Tire[4]
                    {
                    new Tire(year1,pressure1),
                    new Tire(year2,pressure2),
                    new Tire (year3,pressure3),
                    new Tire(year4,pressure4),
                    };

                    tireSets.Add(tires);
                }

                List<Engine> engines = new List<Engine>();

                while (true)
                {
                    string command = Console.ReadLine();

                    if (command == "Engines done")
                    {
                        break;
                    }

                    string[] tokens = command.Split();

                    int horsePower = int.Parse(tokens[0]);
                    double cubicCapacity = double.Parse(tokens[1]);

                    Engine engine = new Engine(horsePower, cubicCapacity);

                    engines.Add(engine);
                }

                List<Car> cars = new List<Car>();



                while (true)
                {
                    string command = Console.ReadLine();

                    if (command == "Show special")
                    {
                        break;
                    }

                    string[] tokens = command.Split();

                    string make = tokens[0];
                    string model = tokens[1];
                    int year = int.Parse(tokens[2]);
                    double fuelQuantity = double.Parse(tokens[3]);
                    double fuelConsumption = double.Parse(tokens[4]);
                    int engineIndex = int.Parse(tokens[5]);
                    int tiresIndex = int.Parse(tokens[6]);

                    int horsePower = engines[engineIndex].HorsePower;

                    double pressureSum = 0;

                    var neededSet = tireSets[tiresIndex];

                    foreach (var tire in neededSet)
                    {
                        pressureSum += tire.Pressure;
                    }

                    Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], tireSets[tiresIndex]);
                    car.Engine.HorsePower = horsePower;

                    if (pressureSum >= 9 && pressureSum <= 10 && car.Year >= 2017 && horsePower > 330)
                    {
                        cars.Add(car);
                    }
                }

                foreach (var car in cars)
                {
                    car.Drive(20);

                    Console.WriteLine($"Make: {car.Make}");
                    Console.WriteLine($"Model: {car.Model}");
                    Console.WriteLine($"Year: {car.Year}");
                    Console.WriteLine($"HorsePowers: {car.Engine.HorsePower}");
                    Console.WriteLine($"FuelQuantity: {car.FuelQuantity}");
                }
            }
        }
    }
}
