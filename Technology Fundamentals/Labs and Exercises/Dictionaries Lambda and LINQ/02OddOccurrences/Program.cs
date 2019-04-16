using System;
using System.Collections.Generic;
using System.Linq;

namespace _02OddOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();
            Dictionary<string, int> result = new Dictionary<string, int>();

            for (int i = 0; i < words.Length; i++)
            {
                string currWord = words[i].ToLower();

                if (!result.ContainsKey(currWord))
                {
                    result.Add(currWord, 0);
                }
                result[currWord] += 1;
            }

            foreach (var kvp in result.Where(x => x.Value % 2 != 0))
            {
                string word = kvp.Key;
                Console.Write(word + " ");
            }
            Console.WriteLine();
        }
    }
}
