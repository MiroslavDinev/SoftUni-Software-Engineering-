using System;
using System.IO;

namespace _02LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader("../../../text.txt"))
            {
                int counter = 1;

                using (var writer = new StreamWriter("../../../output.txt"))
                {
                    while (true)
                    {
                        string line = reader.ReadLine();

                        if (line == null)
                        {
                            break;
                        }

                        int letterCount = 0;
                        int punctuationCount = 0;

                        foreach (var symbol in line)
                        {
                            if (char.IsLetter(symbol))
                            {
                                letterCount++;
                            }
                            else if (char.IsPunctuation(symbol))
                            {
                                punctuationCount++;
                            }
                        }
                        writer.WriteLine($"Line {counter}: {line} ({letterCount})({punctuationCount})");

                        counter++;
                    }
                }
            }
        }
    }
}
