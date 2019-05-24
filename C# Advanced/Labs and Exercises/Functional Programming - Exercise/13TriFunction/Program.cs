using System;
using System.Linq;
using System.Collections.Generic;

namespace _13TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine().Split();

            foreach (var name in names)
            {
                int sum = 0;

                for (int i = 0; i < name.Length; i++)
                {
                    char currSymbol = name[i];

                    sum += (int)currSymbol;
                }

                if (sum>=n)
                {
                    Console.WriteLine(name);
                    return;
                }
            }
        }
    }
}
