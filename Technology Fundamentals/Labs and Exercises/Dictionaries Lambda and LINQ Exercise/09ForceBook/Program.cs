using System;
using System.Linq;
using System.Collections.Generic;

namespace _09ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> nameSide = new Dictionary<string, string>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Lumpawaroo")
                {
                    break;
                }

                if (command.Contains('|'))
                {
                    string[] tokens = command.Split(" | ");

                    string forceSide = tokens[0];
                    string forceUser = tokens[1];

                    if (!nameSide.ContainsKey(forceUser))
                    {
                        nameSide[forceUser] = forceSide;
                    }
                }
                else
                {
                    string[] tokens = command.Split(" -> ");

                    string forceUser = tokens[0];
                    string forceSide = tokens[1];

                    if (nameSide.ContainsKey(forceUser))
                    {
                        nameSide[forceUser] = forceSide;
                    }
                    else
                    {
                        nameSide[forceUser] = forceSide;
                    }

                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                }
            }

            var filteredNameSide = nameSide.GroupBy(x => x.Value).OrderByDescending(x => x.Count()).ThenBy(x => x.Key);

            foreach (var kvp in filteredNameSide)
            {
                string side = kvp.Key;

                var nameSideValue = kvp;

                Console.WriteLine($"Side: {side}, Members: {nameSideValue.Count()}");

                foreach (var kvpValue in nameSideValue.OrderBy(x => x.Key))
                {
                    string name = kvpValue.Key;

                    Console.WriteLine($"! {name}");
                }
            }

        }
    }
}
