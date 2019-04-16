using System;
using System.Linq;
using System.Collections.Generic;

namespace _01Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> wordDef = new Dictionary<string, List<string>>();

            string[] firstTokens = Console.ReadLine().Split(" | ");

            foreach (string item in firstTokens)
            {
                string[] tokens = item.Split(": ");
                string word = tokens[0];
                string def = tokens[1];

                if (!wordDef.ContainsKey(word))
                {
                    wordDef.Add(word, new List<string>());
                    wordDef[word].Add(def);
                }
                else
                {
                    wordDef[word].Add(def);
                }
            }

            string[] wordTokens = Console.ReadLine().Split(" | ");

            foreach (string word in wordTokens)
            {
                if (wordDef.ContainsKey(word))
                {
                    Console.WriteLine(word);

                    foreach (var kvp in wordDef)
                    {
                        string currWord = kvp.Key;
                        List<string> defs = kvp.Value;

                        if (currWord == word)
                        {
                            foreach (var def in defs.OrderByDescending(x => x.Length))
                            {
                                Console.WriteLine($" -{def}");
                            }
                        }                       
                    }
                }
            }

            string last = Console.ReadLine();

            if (last == "End")
            {
                return;
            }
            else
            {
                foreach (var kvp in wordDef.OrderBy(x=>x.Key))
                {
                    Console.Write(kvp.Key + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
