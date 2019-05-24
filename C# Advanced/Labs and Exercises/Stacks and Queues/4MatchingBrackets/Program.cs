using System;
using System.Collections.Generic;
using System.Linq;

namespace _4MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<int> symbols = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                char curr = input[i];

                if (curr == '(')
                {
                    symbols.Push(i);
                }
                else if (curr == ')')
                {
                    int start = symbols.Pop();

                    string toPrint = input.Substring(start, i - start + 1);

                    Console.WriteLine(toPrint);
                }
            }
        }
    }
}
