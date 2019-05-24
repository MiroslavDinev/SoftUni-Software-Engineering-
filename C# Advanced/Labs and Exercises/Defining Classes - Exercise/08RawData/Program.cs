using System;
using System.Linq;
using System.Collections.Generic;

namespace _08RawData
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string model = tokens[0];
                int engineSpeed = int.Parse(tokens[1]);
                int enginePower = int.Parse(tokens[2]);
                int cargoWeight = int.Parse(tokens[3]);
                string cargoType = tokens[4];
                double tirePressure1 = double.Parse(tokens[5]);
                int year1 = int.Parse(tokens[6]);
                double tirePressure2 = double.Parse(tokens[7]);
                int year2 = int.Parse(tokens[8]);
                double tirePressure3 = double.Parse(tokens[9]);
                int year3 = int.Parse(tokens[10]);
                double tirePressure4 = double.Parse(tokens[11]);
                int year4 = int.Parse(tokens[12]);

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoWeight, cargoType);
                Tire[] tires = new Tire[4]
                {
                    new Tire(tirePressure1,year1),
                    new Tire(tirePressure2,year2),
                    new Tire(tirePressure3,year3),
                    new Tire(tirePressure4,year4),
                };

                Car car = new Car(model, engine, cargo, tires);

                cars.Add(car);
            }

            string input = Console.ReadLine();

            var filtered = cars.Where(x => x.Cargo.Type == input).ToList();

            if (input == "flamable")
            {
                foreach (Car car in filtered)
                {
                    if (car.Engine.Power>250)
                    {
                        Console.WriteLine(car.Model);
                    }
                }
            }
            else if (input == "fragile")
            {
                foreach (Car car in filtered.Where(c=>c.Tires.Any(t=>t.Pressure<1)))
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
    }
}
