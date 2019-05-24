using System;
using System.Linq;
using System.Collections.Generic;

namespace _06Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> colorClothCount = new Dictionary<string, Dictionary<string, int>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ");

                string color = input[0];

                string[] tokens = input[1].Split(",");

                if (!colorClothCount.ContainsKey(color))
                {
                    colorClothCount.Add(color, new Dictionary<string, int>());
                }

                foreach (var token in tokens)
                {
                    if (!colorClothCount[color].ContainsKey(token))
                    {
                        colorClothCount[color].Add(token, 1);
                    }
                    else
                    {
                        colorClothCount[color][token]++;
                    }
                }
            }

            string[] colorItem = Console.ReadLine().Split();

            string colorCloth = colorItem[0];
            string item = colorItem[1];

            foreach (var kvp in colorClothCount)
            {
                string color = kvp.Key;

                Console.WriteLine($"{color} clothes:");

                foreach (var inner in kvp.Value)
                {
                    string cloth = inner.Key;
                    int count = inner.Value;

                    if (color == colorCloth && cloth == item)
                    {
                        Console.WriteLine($"* {cloth} - {count} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {cloth} - {count}");
                    }
                }
            }
        }
    }
}
