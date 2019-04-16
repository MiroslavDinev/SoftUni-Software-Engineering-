using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.GaussTrick
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> result = new List<int>();

            for (int i = 0; i < nums.Count / 2; i++)
            {
                int firstNum = nums[i];
                int secondNum = nums[nums.Count - i - 1];

                result.Add(firstNum + secondNum);
            }

            if (nums.Count % 2 != 0)
            {
                result.Add(nums[nums.Count / 2]);
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
