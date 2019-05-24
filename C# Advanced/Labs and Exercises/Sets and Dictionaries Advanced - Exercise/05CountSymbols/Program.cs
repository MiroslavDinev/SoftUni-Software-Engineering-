using System;
using System.Linq;
using System.Collections.Generic;

namespace _05CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> symbolCount = new SortedDictionary<char, int>();

            string text = Console.ReadLine();

            foreach (var symbol in text)
            {
                if (!symbolCount.ContainsKey(symbol))
                {
                    symbolCount.Add(symbol, 1);
                }
                else
                {
                    symbolCount[symbol]++;
                }
            }

            foreach (var kvp in symbolCount)
            {
                char symbol = kvp.Key;
                int count = kvp.Value;

                Console.WriteLine($"{symbol}: {count} time/s");
            }
        }
    }
}
