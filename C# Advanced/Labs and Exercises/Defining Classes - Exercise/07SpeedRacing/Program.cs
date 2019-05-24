using System;
using System.Linq;
using System.Collections.Generic;

namespace _07SpeedRacing
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] carData = Console.ReadLine().Split();

                string model = carData[0];
                double fuelAmount = double.Parse(carData[1]);
                double fuelConsumption = double.Parse(carData[2]);

                Car car = new Car(model, fuelAmount, fuelConsumption);

                cars.Add(car);
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
                double distance = double.Parse(tokens[2]);

                Car currCar = cars.Where(x => x.Model == model).FirstOrDefault();

                currCar.Drive(distance);
            }

            foreach (Car car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
