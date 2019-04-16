using System;
using System.Collections.Generic;
using System.Linq;

namespace _08AnonymousThreat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> initalData = Console.ReadLine().Split().ToList();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "3:1")
                {
                    break;
                }

                string[] token = input.Split();

                string command = token[0];

                if (command == "merge")
                {
                    int startIndex = int.Parse(token[1]);
                    int endIndex = int.Parse(token[2]);

                    if (startIndex < 0)
                    {
                        startIndex = 0;
                    }
                    if (endIndex > initalData.Count - 1)
                    {
                        endIndex = initalData.Count - 1;
                    }
                    if (startIndex > initalData.Count - 1 || endIndex < 0)
                    {
                        continue;
                    }

                    Merge(initalData, startIndex, endIndex);

                }

                else
                {
                    int startIndex = int.Parse(token[1]);
                    int parts = int.Parse(token[2]);

                    Divide(initalData, startIndex, parts);
                }
            }

            Console.WriteLine(string.Join(" ", initalData));
        }

        private static void Divide(List<string> initalData, int startIndex, int parts)
        {
            string currWord = initalData[startIndex];
            int partLen = currWord.Length / parts;

            List<string> newWords = new List<string>();

            for (int i = 0; i < parts; i++)
            {
                string subWord = currWord.Substring(i * partLen, partLen);

                if (i == parts - 1)
                {
                    subWord = currWord.Substring(i * partLen);
                }

                newWords.Add(subWord);
            }

            initalData.Remove(currWord);
            initalData.InsertRange(startIndex, newWords);
        }

        public static void Merge(List<string> initalData, int startIndex, int endIndex)
        {
            string bigWord = string.Empty;

            for (int i = startIndex; i <= endIndex; i++)
            {
                bigWord += initalData[i];
            }

            initalData.RemoveRange(startIndex, endIndex - startIndex + 1);
            initalData.Insert(startIndex, bigWord);
        }
    }
}
