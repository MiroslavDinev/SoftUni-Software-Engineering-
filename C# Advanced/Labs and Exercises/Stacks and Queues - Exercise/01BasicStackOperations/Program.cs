using System;
using System.Linq;
using System.Collections.Generic;

namespace _01BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] props = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int numsToPush = props[0];
            int numsToPop = props[1];
            int numToFind = props[2];

            Stack<int> nums = new Stack<int>();

            for (int i = 0; i < numsToPush; i++)
            {
                nums.Push(input[i]);
            }

            if (numsToPop<=nums.Count)
            {
                for (int i = 0; i < numsToPop; i++)
                {
                    nums.Pop();
                }
            }

            if (nums.Count==0)
            {
                Console.WriteLine(0);
                return;
            }

            bool isPresent = nums.Contains(numToFind);

            if (isPresent)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(nums.Min());
            }
        }
    }
}
