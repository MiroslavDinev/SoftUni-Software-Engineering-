using System;
using System.Linq;
using System.Collections.Generic;

namespace _03MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<int> nums = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                string command = Console.ReadLine();

                if (command.Contains(" "))
                {
                    string[] tokens = command.Split();
                    int numToAdd = int.Parse(tokens[1]);
                    nums.Push(numToAdd);
                }
                else
                {
                    if (command == "2")
                    {
                        if (nums.Count>0)
                        {
                            nums.Pop();
                        }
                    }
                    else if (command == "3")
                    {
                        if (nums.Count>0)
                        {
                            Console.WriteLine(nums.Max());
                        }                       
                    }
                    else
                    {
                        if (nums.Count > 0)
                        {
                            Console.WriteLine(nums.Min());
                        }
                    }
                }
            }

            if (nums.Count>0)
            {
                Console.WriteLine(string.Join(", ", nums));
            }           
        }
    }
}
