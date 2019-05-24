using System;
using System.Linq;
using System.Collections.Generic;

namespace _08CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] evenNums = nums.Where(x => x % 2 == 0).ToArray();
            int[] oddNums = nums.Where(x => x % 2 != 0).ToArray();

            Array.Sort(oddNums);
            Array.Sort(evenNums);

            Console.Write(string.Join(" ",evenNums));
            Console.Write(" ");
            Console.Write(string.Join(" ",oddNums));
            Console.WriteLine();
        }
    }
}
