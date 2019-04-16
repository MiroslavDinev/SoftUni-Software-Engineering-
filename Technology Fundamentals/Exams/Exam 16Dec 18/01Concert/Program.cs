using System;
using System.Collections.Generic;
using System.Linq;

namespace _01Concert
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> bandAndMembers = new Dictionary<string, List<string>>();
            Dictionary<string, int> bandTime = new Dictionary<string, int>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "start of concert")
                {
                    break;
                }

                string[] tokens = command.Split("; ");
                string action = tokens[0];

                if (action == "Play")
                {
                    string bandName = tokens[1];
                    int time = int.Parse(tokens[2]);

                    if (!bandTime.ContainsKey(bandName))
                    {
                        bandTime.Add(bandName, time);
                    }
                    else
                    {
                        bandTime[bandName] += time;
                    }

                    if (!bandAndMembers.ContainsKey(bandName))
                    {
                        bandAndMembers.Add(bandName, new List<string>());
                    }
                }
                else
                {
                    string bandName = tokens[1];
                    List<string> members = tokens[2].Split(", ").ToList();

                    if (!bandAndMembers.ContainsKey(bandName))
                    {
                        bandAndMembers.Add(bandName, new List<string>());
                        bandAndMembers[bandName].AddRange(members);
                    }
                    else
                    {
                        foreach (var member in members)
                        {
                            if (!bandAndMembers[bandName].Contains(member))
                            {
                                bandAndMembers[bandName].Add(member);
                            }
                        }
                    }

                    members.Clear();
                }
            }

            Console.WriteLine($"Total time: {bandTime.Values.Sum()}");

            foreach (var kvp in bandTime.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }

            string bandToPrint = Console.ReadLine();
            Console.WriteLine(bandToPrint);

            foreach (var kvp in bandAndMembers)
            {
                string bandName = kvp.Key;
                List<string> members = kvp.Value;

                if (bandName == bandToPrint)
                {
                    foreach (var member in members)
                    {
                        Console.WriteLine($"=> {member}");
                    }
                }
            }
        }
    }
}
