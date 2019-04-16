using System;

namespace _06ReplaceRepeatingChars
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            
            for (int i = 0; i < input.Length-1; i++)
            {
                char currSymbol = input[i];
                char nextSymbol = input[i+1];

                if (currSymbol==nextSymbol)
                {
                    input = input.Remove(i + 1, 1);
                    i--;
                }
            }

            Console.WriteLine(input);
        }
    }
}
