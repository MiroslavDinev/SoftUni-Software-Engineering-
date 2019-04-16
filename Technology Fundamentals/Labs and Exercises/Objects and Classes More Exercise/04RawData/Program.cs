using System;
using System.Linq;
using System.Collections.Generic;

namespace _04RawData
{
    public class Car
    {
        public string Model { get; set; }
        public int EngineSpeed { get; set; }
        public int EnginePower { get; set; }
        public int CargoWeight { get; set; }
        public string CargoType { get; set; }
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
                int engSpeed = int.Parse(tokens[1]);
                int engPower = int.Parse(tokens[2]);
                int cargoWeight = int.Parse(tokens[3]);
                string cargoType = tokens[4];

                cars.Add(new Car
                {
                    Model = name,
                    EngineSpeed = engSpeed,
                    EnginePower = engPower,
                    CargoWeight = cargoWeight,
                    CargoType = cargoType
                });
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                var filtered = cars.Where(x => x.CargoType == "fragile" && x.CargoWeight<1000);

                foreach (var currCar in filtered)
                {
                    
                    Console.WriteLine(currCar.Model);
                    
                }
            }
            else if (command == "flamable")
            {
                var filtered = cars.Where(x => x.CargoType == "flamable" && x.EnginePower > 250);

                foreach (var currCar in filtered)
                {                
                    Console.WriteLine(currCar.Model);                   
                }
            }
        }
    }
}
