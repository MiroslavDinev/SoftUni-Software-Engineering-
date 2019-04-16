using System;
using System.Collections.Generic;
using System.Linq;

namespace _05RemoveNegativesAndReverse
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).Where(x => x > 0).Reverse().ToList();

            if (nums.Count == 0)
            {
                Console.WriteLine("empty");
                return;
            }

            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
