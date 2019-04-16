using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _09StarEnigma
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> attacked = new List<string>();
            List<string> destroyed = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string encrypted = Console.ReadLine();
                int key = 0;

                for (int j = 0; j < encrypted.Length; j++)
                {
                    char currSymbol = encrypted[j];

                    if (currSymbol == 'S' || currSymbol =='s' || currSymbol == 'T' || currSymbol == 't' || currSymbol == 'A' || currSymbol == 'a' || currSymbol == 'R' || currSymbol == 'r')
                    {
                        key++;
                    }
                }

                string decrypted = string.Empty;

                for (int k = 0; k < encrypted.Length; k++)
                {
                    char currSymbol = encrypted[k];

                    int revised = (int)currSymbol - key;

                    decrypted +=(char) revised;
                }

                string regex = @"[^@,\-!:>]*@(?<planet>[A-Za-z]+)[^@,\-!:>]*:(?<population>\d+)[^@,\-!:>]*!(?<attack>[A-Z])![^@,\-!:>]*->(?<soldiers>\d+)";

                if (Regex.IsMatch(decrypted,regex))
                {
                    Match match = Regex.Match(decrypted, regex);

                    string planet = match.Groups["planet"].Value;
                    int population = int.Parse(match.Groups["population"].Value);
                    string attackType = match.Groups["attack"].Value;
                    int soldiers = int.Parse(match.Groups["soldiers"].Value);

                    if (attackType == "A")
                    {
                        attacked.Add(planet);
                    }
                    else if (attackType == "D")
                    {
                        destroyed.Add(planet);
                    }
                }
            }

            Console.WriteLine($"Attacked planets: {attacked.Count}");

            if (attacked.Count>0)
            {
                var filtered=attacked.OrderBy(x => x);

                foreach (var item in filtered)
                {
                    Console.WriteLine("-> " + item);
                }
            }

            Console.WriteLine($"Destroyed planets: {destroyed.Count}");

            if (destroyed.Count>0)
            {
                var filtered=destroyed.OrderBy(x => x);

                foreach (var item in filtered)
                {
                    Console.WriteLine("-> " + item);
                }
            }
        }
    }
}
