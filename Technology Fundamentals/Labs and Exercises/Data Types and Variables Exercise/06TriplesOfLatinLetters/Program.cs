using System;

namespace _06TriplesOfLatinLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                char first = (char)('a' + i);
                for (int j = 0; j < n; j++)
                {
                    char second = (char)('a' + j);
                    for (int z = 0; z < n; z++)
                    {
                        char third = (char)('a' + z);
                        Console.WriteLine("{0}{1}{2}", first, second, third);
                    }
                }
            }
        }
    }
}
