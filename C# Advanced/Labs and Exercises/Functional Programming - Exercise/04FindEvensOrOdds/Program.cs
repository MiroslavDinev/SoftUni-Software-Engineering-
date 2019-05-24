using System;
using System.Linq;
using System.Collections.Generic;

namespace _04FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int min = range[0];
            int max = range[1];

            List<int> nums = new List<int>();

            for (int i = min; i <=max; i++)
            {
                nums.Add(i);
            }

            string command = Console.ReadLine();

            Predicate<int> sort = x => command == "odd" ? x % 2 != 0 : x % 2 == 0;

            var sorted = nums.Where(x=>sort(x));

            foreach (var item in sorted)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
