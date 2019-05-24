using System;
using System.Linq;
using System.Collections.Generic;

namespace _03CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            for (int i = 0; i < input.Length; i++)
            {
                string currWord = input[i];

                for (int j = 0; j < currWord.Length; j++)
                {
                    char currSymbol = currWord[j];

                    if (char.IsUpper(currSymbol) && j == 0)
                    {
                        Console.WriteLine(currWord);
                        break;
                    }
                }
            }
        }
    }
}
