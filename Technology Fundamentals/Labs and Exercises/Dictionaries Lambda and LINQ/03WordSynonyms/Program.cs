using System;
using System.Collections.Generic;

namespace _03WordSynonyms
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<string>> wordsSyn = new Dictionary<string, List<string>>();

            for (int i = 0; i < n; i++)
            {
                string word = Console.ReadLine();
                string syn = Console.ReadLine();

                if (!wordsSyn.ContainsKey(word))
                {
                    wordsSyn.Add(word, new List<string>());
                    wordsSyn[word].Add(syn);
                }
                else
                {
                    wordsSyn[word].Add(syn);
                }
            }
            foreach (var kvp in wordsSyn)
            {
                Console.WriteLine("{0} - {1}", kvp.Key, string.Join(", ", kvp.Value));
            }
        }
    }
}
