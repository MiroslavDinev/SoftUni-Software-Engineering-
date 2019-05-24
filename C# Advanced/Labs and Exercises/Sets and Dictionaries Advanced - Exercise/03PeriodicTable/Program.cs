using System;
using System.Linq;
using System.Collections.Generic;

namespace _03PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedSet<string> elements = new SortedSet<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in input)
                {
                    elements.Add(item);
                }
            }

            Console.WriteLine(string.Join(" ",elements));
        }
    }
}
