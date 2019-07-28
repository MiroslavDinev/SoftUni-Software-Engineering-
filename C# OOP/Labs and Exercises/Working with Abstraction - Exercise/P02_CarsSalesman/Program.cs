using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P02_CarsSalesman
{     
    public class CarSalesman
    {
        static void Main(string[] args)
        {
            EngineFactory engineFactory = new EngineFactory();
            CarFactory carFactory = new CarFactory(engineFactory);

            int engineCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < engineCount; i++)
            {
                string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                engineFactory.Add(parameters);
            }

            int carCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carCount; i++)
            {
                string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                carFactory.Add(parameters);
            }

            foreach (var car in carFactory.GetCars())
            {
                Console.WriteLine(car);
            }
        }
    }
}
