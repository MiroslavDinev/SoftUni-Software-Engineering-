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
            List<string> words = new List<string>();

            using (var wordReader = new StreamReader("../../../words.txt"))
            {
                while (true)
                {
                    string line = wordReader.ReadLine();

                    if (line == null)
                    {
                        break;
                    }

                    words.Add(line.ToLower());
                }
            }

            Dictionary<string, int> wordCount = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (!wordCount.ContainsKey(word))
                {
                    wordCount.Add(word, 0);
                }
            }

            using (var reader = new StreamReader("../../../text.txt"))
            {
                while (true)
                {
                    string line = reader.ReadLine();

                    if (line == null)
                    {
                        break;
                    }

                    line = line.ToLower();

                    string symbols = " ";

                    foreach (char symbol in line)
                    {
                        if (char.IsPunctuation(symbol) && symbol!='\'')
                        {
                            symbols += symbol;
                        }
                    }

                    string[] splittedLine = line.Split(symbols.ToCharArray(),StringSplitOptions.RemoveEmptyEntries);

                    foreach (var word in splittedLine)
                    {
                        if (wordCount.ContainsKey(word))
                        {
                            wordCount[word]++;
                        }
                    }
                }
            }

            using (var writer = new StreamWriter("../../../actualResult.txt"))
            {
                foreach (var kvp in wordCount.OrderByDescending(x=>x.Value))
                {
                    writer.WriteLine($"{kvp.Key} - {kvp.Value}");
                }
            }
        }
    }
}
    

