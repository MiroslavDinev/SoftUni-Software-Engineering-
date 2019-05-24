using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace _03WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> wordCount = new Dictionary<string, int>();

            using (var reader = new StreamReader("03. Word Count/text.txt"))
            {
                using (var wordReader = new StreamReader("03. Word Count/words.txt"))
                {
                    string word = wordReader.ReadLine();

                    string[] words = word.Split();

                    foreach (var currWord in words)
                    {
                        wordCount.Add(currWord, 0);
                    }

                    while (true)
                    {
                        var line = reader.ReadLine();

                        if (line == null)
                        {
                            break;
                        }

                        line = line.ToLower();

                        foreach (var item in words)
                        {
                            if (line.Contains(item))
                            {
                                wordCount[item]++;
                            }
                        }
                    }
                }                               
            }

            using (var writer = new StreamWriter("Output.txt"))
            {
                foreach (var kvp in wordCount.OrderByDescending(x=>x.Value))
                {
                    string word = kvp.Key;
                    int count = kvp.Value;

                    writer.WriteLine($"{word}-{count}");
                }
            }
        }
    }
}
