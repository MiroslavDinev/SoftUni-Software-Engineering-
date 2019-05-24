using System;
using System.Linq;

namespace _03CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Func<int[], int> result = MinNumber;

            Console.WriteLine(result(nums));
        }

        public static int MinNumber (int[] nums)
        {
            int smallest = int.MaxValue;

            foreach (var num in nums)
            {
                if (num<smallest)
                {
                    smallest = num;
                }
            }

            return smallest;
        }
    }
}
