using System;
using System.Linq;
using System.Collections.Generic;

namespace _01Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine().Split().Select(int.Parse).ToList();
            int maxWagonCapacity = int.Parse(Console.ReadLine());

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                string[] token = input.Split();

                if (token[0]=="Add")
                {
                    int number = int.Parse(token[1]);
                    wagons.Add(number);
                    continue;
                }

                int passangers = int.Parse(token[0]);

                for (int i = 0; i < wagons.Count; i++)
                {
                    if (wagons[i]+passangers<=maxWagonCapacity)
                    {
                        wagons[i] += passangers;
                        break;
                    }
                }
            }

            Console.WriteLine(string.Join(" ",wagons));
        }
    }
}
