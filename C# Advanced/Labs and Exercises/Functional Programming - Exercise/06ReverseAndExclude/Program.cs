using System;
using System.Linq;
using System.Collections.Generic;

namespace _06ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int divider = int.Parse(Console.ReadLine());

            nums = nums.Where(x => x % divider != 0).Reverse().ToArray();

            Console.WriteLine(string.Join(" ",nums));
        }
    }
}
