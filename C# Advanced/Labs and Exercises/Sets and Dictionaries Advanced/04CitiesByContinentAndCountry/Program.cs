using System;
using System.Linq;
using System.Collections.Generic;

namespace _04CitiesByContinentAndCountry
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> contCountryCities = new Dictionary<string, Dictionary<string, List<string>>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();

                string continent = tokens[0];
                string country = tokens[1];
                string city = tokens[2];

                if (!contCountryCities.ContainsKey(continent))
                {
                    contCountryCities.Add(continent, new Dictionary<string, List<string>>());
                    contCountryCities[continent].Add(country, new List<string>());
                    contCountryCities[continent][country].Add(city);
                }
                else if (contCountryCities.ContainsKey(continent)==true && contCountryCities[continent].ContainsKey(country)==false)
                {
                    contCountryCities[continent].Add(country, new List<string>());
                    contCountryCities[continent][country].Add(city);
                }
                else if (contCountryCities.ContainsKey(continent) == true && contCountryCities[continent].ContainsKey(country) == true)
                {
                    contCountryCities[continent][country].Add(city);
                }
            }

            foreach (var kvp in contCountryCities)
            {
                string continent = kvp.Key;

                Console.WriteLine(continent + ":");

                foreach (var inner in kvp.Value)
                {
                    string country = inner.Key;
                    List<string> cities = inner.Value;

                    Console.Write($"{country} -> {string.Join(", ",cities)}");
                    Console.WriteLine();
                }
            }
        }
    }
}
