using System;

namespace _08BeerKegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string bestKeg = string.Empty;
            double bestVolume = 0;

            for (int i = 0; i < n; i++)
            {
                string model = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                double currVol = Math.PI * (radius * radius) * height;

                if (currVol > bestVolume)
                {
                    bestKeg = model;
                    bestVolume = currVol;
                }
            }
            Console.WriteLine(bestKeg);
        }
    }
}
