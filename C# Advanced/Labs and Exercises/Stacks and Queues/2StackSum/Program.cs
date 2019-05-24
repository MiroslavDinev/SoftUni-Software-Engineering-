using System;
using System.Linq;
using System.Collections.Generic;

namespace _2StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> numbers = new Stack<int>(nums);

            while (true)
            {
                string command = Console.ReadLine().ToLower();

                if (command == "end")
                {
                    break;
                }

                string[] tokens = command.Split();

                string action = tokens[0];

                if (action == "add")
                {
                    int firstNum = int.Parse(tokens[1]);
                    int secondNum = int.Parse(tokens[2]);

                    numbers.Push(firstNum);
                    numbers.Push(secondNum);
                }
                else
                {
                    int count = int.Parse(tokens[1]);

                    if (count > numbers.Count)
                    {
                        continue;
                    }
                    else
                    {
                        for (int i = 0; i < count; i++)
                        {
                            numbers.Pop();
                        }
                    }
                }
            }

            Console.WriteLine($"Sum: {numbers.Sum()}");
        }
    }
}
