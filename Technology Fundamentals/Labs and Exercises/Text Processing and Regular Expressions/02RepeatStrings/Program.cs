using System;
using System.Linq;

namespace _02RepeatStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();

            string result = string.Empty;

            foreach (var word in words)
            {
                int currLen = word.Length;

                for (int i = 0; i < currLen; i++)
                {
                    result += word;
                }
            }

            Console.WriteLine(result);
        }
    }
}
