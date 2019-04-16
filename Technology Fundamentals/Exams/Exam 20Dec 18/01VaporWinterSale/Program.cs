using System;
using System.Collections.Generic;
using System.Linq;

namespace _01VaporWinterSale
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] games = Console.ReadLine().Split(", ");

            Dictionary<string, decimal> gamePrice = new Dictionary<string, decimal>();
            Dictionary<string, string> gameDLC = new Dictionary<string, string>();

            foreach (var game in games)
            {
                if (!game.Contains(':'))
                {
                    string[] tokens = game.Split("-");
                    string gameName = tokens[0];
                    decimal price = decimal.Parse(tokens[1]);

                    if (!gamePrice.ContainsKey(gameName))
                    {
                        gamePrice.Add(gameName, price);
                    }
                }
                else
                {
                    string[] tokens = game.Split(":");
                    string gameName = tokens[0];
                    string dlc = tokens[1];

                    if (gamePrice.ContainsKey(gameName))
                    {
                        gameDLC.Add(gameName, dlc);
                        gamePrice[gameName] *= 1.20m;
                    }
                }
            }

            foreach (var kvp in gamePrice.OrderBy(x=>x.Value))
            {
                string gameName = kvp.Key;
                decimal price = kvp.Value;

                if (gameDLC.ContainsKey(gameName))
                {
                    string dlc = gameDLC[gameName];
                    price *= 0.5m;

                    Console.WriteLine($"{gameName} - {dlc} - {price:f2}");
                }
            }

            foreach (var kvp in gamePrice.OrderByDescending(x=>x.Value))
            {
                string gameName = kvp.Key;
                decimal price = kvp.Value;

                if (!gameDLC.ContainsKey(gameName))
                {
                    price *= 0.8m;

                    Console.WriteLine($"{gameName} - {price:f2}");
                }
            }
        }
    }
}
