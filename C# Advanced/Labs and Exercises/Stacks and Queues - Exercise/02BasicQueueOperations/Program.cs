using System;
using System.Linq;
using System.Collections.Generic;

namespace _02BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] props = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int numsToEnqueue = props[0];
            int numsToDequeue = props[1];
            int numToFind = props[2];

            Queue<int> nums = new Queue<int>();

            for (int i = 0; i < numsToEnqueue; i++)
            {
                nums.Enqueue(input[i]);
            }

            if (numsToDequeue<=nums.Count)
            {
                for (int i = 0; i < numsToDequeue; i++)
                {
                    nums.Dequeue();
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
