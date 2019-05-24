using System;
using System.Linq;
using System.Collections.Generic;

namespace _10CarSalesman
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int engineLines = int.Parse(Console.ReadLine());

            List<Engine> engines = new List<Engine>();

            for (int i = 0; i < engineLines; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);

                string model = tokens[0];
                int power = int.Parse(tokens[1]);

                Engine engine = new Engine(model, power);

                if (tokens.Length==4)
                {
                    int displacement = int.Parse(tokens[2]);
                    string efficiency = tokens[3];

                    engine.Displacement = displacement;
                    engine.Efficinecy = efficiency;
                }
                else if (tokens.Length==3)
                {
                    bool isDisplacement = int.TryParse(tokens[2], out int displacement);

                    if (isDisplacement)
                    {
                        engine.Displacement = displacement;
                    }
                    else
                    {
                        engine.Efficinecy = tokens[2];
                    }
                }

                engines.Add(engine);
            }

            int numCars = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < numCars; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = tokens[0];
                Engine engine = engines.Where(x => x.Model == tokens[1]).FirstOrDefault();

                Car car = new Car(model, engine);

                if (tokens.Length==4)
                {
                    double weight = double.Parse(tokens[2]);
                    string color = tokens[3];

                    car.Weight = weight;
                    car.Color = color;
                }
                else if (tokens.Length==3)
                {
                    bool isWeight = double.TryParse(tokens[2], out double weight);

                    if (isWeight)
                    {
                        car.Weight = weight;
                    }
                    else
                    {
                        car.Color = tokens[2];
                    }
                }

                cars.Add(car);
            }

            foreach (Car car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
