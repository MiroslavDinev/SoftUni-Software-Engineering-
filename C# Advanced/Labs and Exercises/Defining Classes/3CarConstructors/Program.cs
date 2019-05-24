using System;

namespace _3CarConstructors
{
    class Program
    {
        static void Main(string[] args)
        {
            string make = Console.ReadLine();
            string model = Console.ReadLine();
            int year = int.Parse(Console.ReadLine());
            double fuelQuantity = double.Parse(Console.ReadLine());
            double fuelConsumption = double.Parse(Console.ReadLine());

            Car car = new Car();
            Car otherCar = new Car(make, model, year);
            Car anotherCar = new Car(make, model, year, fuelQuantity, fuelConsumption);
        }
    }
}
