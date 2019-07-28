using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_RawData
{   
    public class RawData
    {
        static void Main(string[] args)
        {
            CarCatalogue carCatalogue = new CarCatalogue();

            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                carCatalogue.Add(parameters);              
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                List<string> fragile = carCatalogue.GetCars()
                    .Where(x => x.Cargo.CargoType == "fragile" && x.Tires.Any(y => y.Pressure < 1))
                    .Select(x => x.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, fragile));
            }
            else
            {
                List<string> flamable = carCatalogue.GetCars()
                    .Where(x => x.Cargo.CargoType == "flamable" && x.Engine.EnginePower > 250)
                    .Select(x => x.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, flamable));
            }
        }
    }
}
