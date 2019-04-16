using System;
using System.Collections.Generic;
using System.Linq;

namespace _07ListManipulationAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();

            int counter = 0;

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
                    counter++;
                }
                else if (action == "Remove")
                {
                    int num = int.Parse(tokens[1]);
                    nums.Remove(num);
                    counter++;
                }
                else if (action == "RemoveAt")
                {
                    int index = int.Parse(tokens[1]);
                    nums.RemoveAt(index);
                    counter++;
                }
                else if (action == "Insert")
                {
                    int num = int.Parse(tokens[1]);
                    int index = int.Parse(tokens[2]);
                    nums.Insert(index, num);
                    counter++;
                }
                else if (action == "Contains")
                {
                    int num = int.Parse(tokens[1]);
                    if (nums.Contains(num))
                    {
                        Console.WriteLine("Yes");
                    }
                    else
                    {
                        Console.WriteLine("No such number");
                    }
                }
                else if (action == "PrintEven")
                {
                    List<int> even = nums.Where(x => x % 2 == 0).ToList();
                    Console.WriteLine(string.Join(" ", even));
                }
                else if (action == "PrintOdd")
                {
                    List<int> odd = nums.Where(x => x % 2 != 0).ToList();
                    Console.WriteLine(string.Join(" ", odd));
                }
                else if (action == "GetSum")
                {
                    Console.WriteLine(nums.Sum());
                }
                else if (action == "Filter")
                {
                    string condition = tokens[1];
                    int number = int.Parse(tokens[2]);

                    if (condition == "<")
                    {
                        List<int> less = nums.Where(x => x < number).ToList();
                        Console.WriteLine(string.Join(" ", less));
                    }
                    else if (condition == ">")
                    {
                        List<int> more = nums.Where(x => x > number).ToList();
                        Console.WriteLine(string.Join(" ", more));
                    }
                    else if (condition == ">=")
                    {
                        List<int> moreAndEqual = nums.Where(x => x >= number).ToList();
                        Console.WriteLine(string.Join(" ", moreAndEqual));
                    }
                    else if (condition == "<=")
                    {
                        List<int> lessAndEqual = nums.Where(x => x <= number).ToList();
                        Console.WriteLine(string.Join(" ", lessAndEqual));
                    }
                }
            }
            if (counter > 0)
            {

                Console.WriteLine(string.Join(" ", nums));
            }
        }
    }
}
