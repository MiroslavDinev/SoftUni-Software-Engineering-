using System;
using System.Linq;
using System.Collections.Generic;

namespace _07SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vip = new HashSet<string>();
            HashSet<string> regular = new HashSet<string>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "PARTY")
                {
                    break;
                }

                if (command.Length!=8)
                {
                    continue;
                }

                char first = command[0];

                if (char.IsDigit(first))
                {
                    vip.Add(command);
                }
                else
                {
                    regular.Add(command);
                }
            }

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "END")
                {
                    break;
                }

                if (vip.Contains(line))
                {
                    vip.Remove(line);
                }
                else if (regular.Contains(line))
                {
                    regular.Remove(line);
                }
            }

            Console.WriteLine(vip.Count + regular.Count);

            if (vip.Count>0)
            {
                foreach (var item in vip)
                {
                    Console.WriteLine(item);
                }
            }

            if (regular.Count > 0)
            {
                foreach (var item in regular)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
