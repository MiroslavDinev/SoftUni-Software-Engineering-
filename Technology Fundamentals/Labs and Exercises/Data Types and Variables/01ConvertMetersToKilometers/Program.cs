using System;

namespace _01ConvertMetersToKilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            double meters = double.Parse(Console.ReadLine());

            double km = meters / 1000.0;

            Console.WriteLine("{0:f2}", km);
        }
    }
}
