using System;
using System.Collections.Generic;
using System.Linq;

namespace _06ListManipulationBasics
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

                string[] tokens = command.Split();

                string action = tokens[0];

                if (action == "Add")
                {
                    int num = int.Parse(tokens[1]);
                    nums.Add(num);
                }
                else if (action == "Remove")
                {
                    int num = int.Parse(tokens[1]);
                    nums.Remove(num);
                }
                else if (action == "RemoveAt")
                {
                    int index = int.Parse(tokens[1]);
                    nums.RemoveAt(index);
                }
                else if (action == "Insert")
                {
                    int num = int.Parse(tokens[1]);
                    int index = int.Parse(tokens[2]);
                    nums.Insert(index, num);
                }

            }

            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
