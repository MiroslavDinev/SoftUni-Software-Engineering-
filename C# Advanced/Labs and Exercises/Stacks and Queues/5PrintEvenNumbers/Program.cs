using System;
using System.Linq;
using System.Collections.Generic;

namespace _5PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> nums = new Queue<int>();

            foreach (int item in arr)
            {
                if (item %2==0)
                {
                    nums.Enqueue(item);
                }
            }

            Console.WriteLine(string.Join(", ",nums));
        }
    }
}
