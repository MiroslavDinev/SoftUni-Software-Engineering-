using System;
using System.Collections.Generic;
using System.Linq;

namespace _3SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            Stack<string> stack = new Stack<string>(input.Reverse());

            int sum = int.Parse(stack.Pop());

            while (stack.Count != 0)
            {
                string currSymbol = stack.Peek();

                if (currSymbol == "+")
                {
                    stack.Pop();
                    sum += int.Parse(stack.Pop());
                }
                else
                {
                    stack.Pop();
                    sum -= int.Parse(stack.Pop());
                }
            }

            Console.WriteLine(sum);
        }
    }
}
