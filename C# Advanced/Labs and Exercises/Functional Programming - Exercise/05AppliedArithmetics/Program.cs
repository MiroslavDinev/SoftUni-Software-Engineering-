using System;
using System.Linq;
using System.Collections.Generic;

namespace _05AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }
                else if (command == "add")
                {
                    nums = nums.Select(x => x + 1).ToList();
                }
                else if (command == "subtract")
                {
                    nums = nums.Select(x => x - 1).ToList();
                }
                else if (command == "multiply")
                {
                    nums = nums.Select(x => x *2).ToList();
                }
                else if (command == "print")
                {
                    Console.WriteLine(string.Join(" ",nums));
                }
            }
        }
    }
}
