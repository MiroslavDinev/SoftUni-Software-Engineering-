using System;
using System.Collections.Generic;

namespace _01CountCharsInAString
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            var dict = new Dictionary<char, int>();

            foreach (string word in input)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    char currLetter = word[i];

                    if (!dict.ContainsKey(currLetter))
                    {
                        dict[currLetter] = 0;
                    }

                    dict[currLetter]++;
                }
            }

            foreach (var kvp in dict)
            {
                Console.WriteLine("{0} -> {1}", kvp.Key, kvp.Value);
            }
        }
    }
}
