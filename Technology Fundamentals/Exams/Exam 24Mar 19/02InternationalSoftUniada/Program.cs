using System;
using System.Collections.Generic;
using System.Linq;

namespace _04InternationalSoftUniada
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> countryPoints = new Dictionary<string, int>();
            Dictionary<string, Dictionary<string, int>> countryPlayerPoints = new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "END")
                {
                    break;
                }

                string[] tokens = command.Split(" -> ");
                string country = tokens[0];
                string player = tokens[1];
                int points = int.Parse(tokens[2]);

                if (!countryPoints.ContainsKey(country))
                {
                    countryPoints.Add(country, points);
                }
                else
                {
                    countryPoints[country] += points;
                }
                if (!countryPlayerPoints.ContainsKey(country))
                {
                    countryPlayerPoints.Add(country, new Dictionary<string, int>());
                    countryPlayerPoints[country].Add(player, points);
                }
                else if (countryPlayerPoints.ContainsKey(country) == true && countryPlayerPoints[country].ContainsKey(player) == false)
                {
                    countryPlayerPoints[country].Add(player, points);
                }
                else if (countryPlayerPoints.ContainsKey(country) == true && countryPlayerPoints[country].ContainsKey(player) == true)
                {
                    countryPlayerPoints[country][player] += points;
                }
            }

            foreach (var kvp in countryPoints.OrderByDescending(x => x.Value))
            {
                string country = kvp.Key;
                int points = kvp.Value;

                Console.WriteLine("{0}: {1}", country, points);

                foreach (var kvp1 in countryPlayerPoints)
                {
                    string countryName = kvp1.Key;

                    if (countryName == country)
                    {
                        foreach (var inner in kvp1.Value)
                        {
                            string name = inner.Key;
                            int playerPoints = inner.Value;

                            Console.WriteLine("-- {0} -> {1}", name, playerPoints);
                        }
                    }
                }
            }
        }
    }
}
