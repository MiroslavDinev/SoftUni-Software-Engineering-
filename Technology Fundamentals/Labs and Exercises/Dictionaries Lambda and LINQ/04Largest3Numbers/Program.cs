using System;
using System.Collections.Generic;
using System.Linq;

namespace _04Largest3Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();

            if (nums.Count < 3)
            {
                nums.Sort();
                nums.Reverse();
                Console.WriteLine(string.Join(" ", nums));
                return;
            }

            nums.Sort();
            nums.Reverse();
            Console.WriteLine(nums[0] + " " + nums[1] + " " + nums[2]);
        }
    }
}
