using System;
using System.Linq;
using System.Collections.Generic;

namespace _01CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<double, int> numsOccur = new Dictionary<double, int>();

            double[] nums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

            foreach (var num in nums)
            {
                if (!numsOccur.ContainsKey(num))
                {
                    numsOccur.Add(num, 1);
                }
                else
                {
                    numsOccur[num]++;
                }
            }

            foreach (var kvp in numsOccur)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value} times");
            }
        }
    }
}
