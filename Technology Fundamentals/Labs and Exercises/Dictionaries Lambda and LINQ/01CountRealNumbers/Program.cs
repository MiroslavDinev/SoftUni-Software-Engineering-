using System;
using System.Collections.Generic;
using System.Linq;

namespace _01CountRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> nums = new Dictionary<int, int>();
            List<int> input = Console.ReadLine().Split().Select(int.Parse).ToList();

            for (int i = 0; i < input.Count; i++)
            {
                int currNum = input[i];

                if (!nums.ContainsKey(currNum))
                {
                    nums.Add(currNum, 1);
                }
                else
                {
                    nums[currNum] += 1;
                }
            }
            foreach (var kvp in nums.OrderBy(x => x.Key))
            {
                var num = kvp.Key;
                var occur = kvp.Value;

                Console.WriteLine("{0} -> {1}", num, occur);
            }
        }
    }
}
