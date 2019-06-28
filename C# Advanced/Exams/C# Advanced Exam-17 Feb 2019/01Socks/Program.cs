using System;
using System.Linq;
using System.Collections.Generic;

namespace _01Socks
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] leftInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] rightInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> leftSocks = new Stack<int>(leftInput);
            Queue<int> rightSocks = new Queue<int>(rightInput);

            List<int> result = new List<int>();

            while (leftSocks.Any() && rightSocks.Any())
            {
                int currLeft = leftSocks.Peek();
                int currRight = rightSocks.Peek();

                if(currLeft>currRight)
                {
                    int sum = currRight + currLeft;
                    result.Add(sum);
                    leftSocks.Pop();
                    rightSocks.Dequeue();
                }
                else if (currRight>currLeft)
                {
                    leftSocks.Pop();
                }
                else
                {
                    rightSocks.Dequeue();
                    currLeft += 1;
                    leftSocks.Pop();
                    leftSocks.Push(currLeft);
                }
            }

            Console.WriteLine(result.Max());
            Console.WriteLine(string.Join(" ",result));
        }
    }
}
