using System;
using System.Linq;

namespace _08CondenseArrayToNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            //if (numbers.Length == 1)
            //{
            //    Console.WriteLine(numbers[0]);
            //    return;
            //}

            //int[] condensed = new int[numbers.Length - 1];

            //for (int i = 0; i < numbers.Length; i++)
            //{
            //    for (int j = 0; j < condensed.Length - i; j++)
            //    {
            //        condensed[j] = numbers[j] + numbers[j + 1];
            //    }
            //    numbers = condensed;
            //}
            //Console.WriteLine(condensed[0]);

            //int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            //int counter = input.Length;
            //while (counter > 1)
            //{
            //    for (int i = 0; i < input.Length - 1; i++)
            //    {
            //        input[i] = input[i] + input[i + 1];
            //    }
            //    counter--;
            //}
            //Console.WriteLine(input[0]);

            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            if (nums.Length==1)
            {
                Console.WriteLine(nums[0]);
                return;
            }

            int[] condensed = new int[nums.Length - 1];

            int counter = nums.Length;

            while (counter>1)
            {
                for (int i = 0; i < nums.Length - 1; i++)
                {
                    condensed[i] = nums[i] + nums[i + 1];
                }
                nums = condensed;
                counter--;
            }
                Console.WriteLine(nums[0]);
        }
    }
}
