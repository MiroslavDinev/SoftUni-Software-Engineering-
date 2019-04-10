using System;

namespace _05DecryptingMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            string word = string.Empty;

            for (int i = 0; i < n; i++)
            {
                char symbol = char.Parse(Console.ReadLine());
                int calcSymbol = symbol + key;
                char symbolToAdd = (char)calcSymbol;
                word += symbolToAdd;
            }
            Console.WriteLine(word);
        }
    }
}
