using System;
using System.Linq;
using System.Collections.Generic;

namespace _02ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (true)
            {
                string input = Console.ReadLine();

                if (input=="end")
                {
                    break;
                }

                string[] token = input.Split();

                string command = token[0];

                if (command=="Delete")
                {
                    int element = int.Parse(token[1]);

                    while (numbers.Contains(element))
                    {
                        numbers.Remove(element);
                    }
                }
                else
                {
                    int element = int.Parse(token[1]);
                    int position = int.Parse(token[2]);

                    numbers.Insert(position, element);
                }
            }

            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
