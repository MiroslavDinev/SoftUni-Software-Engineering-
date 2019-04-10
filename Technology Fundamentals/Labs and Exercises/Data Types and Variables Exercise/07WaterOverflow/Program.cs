using System;

namespace _07WaterOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = 255;
            int n = int.Parse(Console.ReadLine());
            int poured = 0;

            for (int i = 0; i < n; i++)
            {
                int currQuantity = int.Parse(Console.ReadLine());

                if (currQuantity + poured > capacity)
                {
                    Console.WriteLine("Insufficient capacity!");
                    continue;
                }
                else
                {
                    poured += currQuantity;
                }
            }
            Console.WriteLine(poured);
        }
    }
}
