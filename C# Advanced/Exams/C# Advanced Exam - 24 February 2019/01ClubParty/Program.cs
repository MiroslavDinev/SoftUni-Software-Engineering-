using System;
using System.Linq;
using System.Collections.Generic;

namespace _01ClubParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxCapacity = int.Parse(Console.ReadLine());

            int copyOfMax = maxCapacity;

            Queue<string> halls = new Queue<string>();
            Queue<int> people = new Queue<int>();

            string[] input = Console.ReadLine().Split();

            for (int i = input.Length - 1; i >= 0; i--)
            {
                string currItem = input[i];

                if (char.IsLetter(currItem[0]))
                {
                    halls.Enqueue(currItem);
                }
                else
                {
                    if (halls.Count == 0)
                    {
                        continue;
                    }
                    else
                    {
                        int currPeople = int.Parse(currItem);

                        if (maxCapacity - currPeople >= 0)
                        {
                            maxCapacity -= currPeople;
                            people.Enqueue(currPeople);
                        }
                        else
                        {
                            maxCapacity = copyOfMax;
                            Console.WriteLine("{0} -> {1}", halls.Dequeue(), string.Join(", ", people));
                            people.Clear();
                            i++;
                        }
                    }
                }
            }
        }
    }
}
