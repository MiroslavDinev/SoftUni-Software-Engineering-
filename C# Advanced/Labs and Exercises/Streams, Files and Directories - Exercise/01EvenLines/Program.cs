using System;
using System.IO;

namespace _01EvenLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader("../../../text.txt"))
            {
                int counter = 0;

                using (var writer = new StreamWriter("../../../output.txt"))
                {
                    while (true)
                    {
                        string line = reader.ReadLine();

                        if (line == null)
                        {
                            break;
                        }

                        if (counter%2==0)
                        {
                            string toAdd = string.Empty;

                            for (int i = 0; i < line.Length; i++)
                            {
                                char curr = line[i];

                                if (curr == '-' || curr == ',' || curr=='.' || curr == '!' || curr=='?')
                                {
                                    toAdd += '@';
                                }
                                else
                                {
                                    toAdd += curr;
                                }
                            }

                            string[] result = toAdd.Split();
                            Array.Reverse(result);
                            writer.WriteLine(string.Join(" ",result));
                        }

                        counter++;
                    }                   
                }
            }
        }
    }
}
