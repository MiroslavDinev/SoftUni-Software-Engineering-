using System;
using System.Linq;
using System.Collections.Generic;

namespace _03PresentDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> houses = Console.ReadLine().Split("@").Select(int.Parse).ToList();

            int position = 0;

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Merry Xmas!")
                {
                    break;
                }

                string[] tokens = command.Split();

                int jumpLen = int.Parse(tokens[1]);
                position += jumpLen;

                if (position>houses.Count-1)
                {
                    position = position % houses.Count;

                    if (houses[position]==0)
                    {
                        Console.WriteLine($"House {position} will have a Merry Christmas.");
                        continue;
                    }
                    houses[position] -= 2;
                }
                else
                {
                    if (houses[position] == 0)
                    {
                        Console.WriteLine($"House {position} will have a Merry Christmas.");
                        continue;
                    }
                    houses[position] -= 2;
                }
            }

            Console.WriteLine($"Santa's last position was {position}.");

            if (houses.Sum()==0)
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                int housesCount = 0;

                for (int i = 0; i < houses.Count; i++)
                {
                    int currHouse = houses[i];

                    if (currHouse>0)
                    {
                        housesCount++;
                    }
                }

                Console.WriteLine($"Santa has failed {housesCount} houses.");
            }
        }
    }
}
