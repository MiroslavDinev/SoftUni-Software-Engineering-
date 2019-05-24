using System;
using System.Linq;
using System.Collections.Generic;

namespace _04FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int food = int.Parse(Console.ReadLine());

            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> orders = new Queue<int>(input);

            int biggest = orders.Max();

            if (food == 0)
            {
                Console.WriteLine(biggest);
                Console.WriteLine("Orders left: {0}", string.Join(" ", orders));
                return;
            }

            while (food >= 0 && orders.Count > 0)
            {
                int currOrder = orders.Peek();

                if (currOrder <= food)
                {
                    food -= currOrder;
                }
                else
                {
                    break;
                }

                orders.Dequeue();
            }

            if (food >= 0 && orders.Count == 0)
            {
                Console.WriteLine(biggest);
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine(biggest);
                Console.WriteLine("Orders left: {0}", string.Join(" ", orders));
            }
        } 
    }
}
