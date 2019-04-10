using System;

namespace _08TownInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            string town = Console.ReadLine();
            long population = long.Parse(Console.ReadLine());
            double area = double.Parse(Console.ReadLine());

            Console.WriteLine("Town {0} has population of {1} and area {2} square km.", town, population, area);
        }
    }
}
