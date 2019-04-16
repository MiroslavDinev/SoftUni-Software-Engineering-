using System;
using System.Linq;
using System.Collections.Generic;

namespace _03HouseParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int commands = int.Parse(Console.ReadLine());

            List<string> guests = new List<string>();

            for (int i = 0; i < commands; i++)
            {
                string input = Console.ReadLine();

                string[] token = input.Split();

                string name = token[0];
                string condition = token[2];

                if (condition!="not")
                {
                    if (guests.Contains(name)==false)
                    {
                        guests.Add(name);
                    }
                    else
                    {
                        Console.WriteLine($"{name} is already in the list!");
                        continue;
                    }
                }
                else if (condition=="not")
                {
                    if (guests.Contains(name) == false)
                    {
                        Console.WriteLine($"{name} is not in the list!");
                        continue;
                    }
                    else
                    {
                        guests.Remove(name);
                    }
                }
            }

            for (int i = 0; i < guests.Count; i++)
            {
                Console.WriteLine(guests[i]);
            }
        }
    }
}
