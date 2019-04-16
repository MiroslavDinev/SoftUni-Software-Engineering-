using System;
using System.Linq;
using System.Collections.Generic;

namespace _03CookingFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int quality = 0;
            int bestQuality = int.MinValue;

            double avgQuality = 0;
            double bestAvgQuality = double.MinValue;

            int len = 0;
            int bestLen = 0;

            List<int> bestBatch = new List<int>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Bake It!")
                {
                    break;
                }

                quality = 0;
                avgQuality = 0;
                len = 0;

                List<int> currBatch = command.Split("#").Select(int.Parse).ToList();

                quality = currBatch.Sum();
                avgQuality = currBatch.Average();
                len = currBatch.Count();

                if (quality>bestQuality)
                {
                    bestQuality = quality;
                    bestBatch = currBatch;
                    bestAvgQuality = avgQuality;
                    bestLen = len;
                }
                else if (quality == bestQuality)
                {
                    if (avgQuality > bestAvgQuality)
                    {
                        bestAvgQuality = avgQuality;
                        bestQuality = quality;
                        bestBatch = currBatch;
                        bestLen = len;
                    }
                    else if (avgQuality == bestAvgQuality)
                    {
                        if (len<bestLen)
                        {
                            bestAvgQuality = avgQuality;
                            bestQuality = quality;
                            bestBatch = currBatch;
                            bestLen = len;
                        }
                    }
                }
            }

            if (bestQuality==int.MinValue)
            {
                Console.WriteLine($"Best Batch quality: {bestQuality}");
                Console.WriteLine(string.Join(" ", bestBatch));
                return;
            }

            Console.WriteLine($"Best Batch quality: {bestQuality}");
            Console.WriteLine(string.Join(" ",bestBatch));
        }
    }
}
