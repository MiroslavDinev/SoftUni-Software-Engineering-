using System;
using System.IO;

namespace _01OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader("Resources/01. Odd Lines/Input.txt"))
            {
                int counter = 0;

                using (var writer = new StreamWriter("Output.txt"))
                {
                    while (true)
                    {
                        string line = reader.ReadLine();

                        if (line == null)
                        {
                            break;
                        }

                        if (counter%2!=0)
                        {
                            writer.WriteLine(line);
                        }

                        counter++;
                    }
                }
            }
        }
    }
}
