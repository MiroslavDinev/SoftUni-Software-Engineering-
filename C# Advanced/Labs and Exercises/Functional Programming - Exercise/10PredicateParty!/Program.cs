using System;
using System.Linq;
using System.Collections.Generic;

namespace _10PredicateParty_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> initialNames = Console.ReadLine().Split().ToList();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Party!")
                {
                    break;
                }

                string[] tokens = command.Split();

                string action = tokens[0];

                if (action == "Remove")
                {
                    string filter = tokens[1];

                    if (filter == "StartsWith")
                    {
                        string criteria = tokens[2];

                        initialNames.RemoveAll(x => x.StartsWith(criteria));
                    }
                    else if (filter == "EndsWith")
                    {
                        string criteria = tokens[2];

                        initialNames.RemoveAll(x => x.EndsWith(criteria));
                    }
                    else
                    {
                        int len = int.Parse(tokens[2]);

                        initialNames.RemoveAll(x => x.Length == len);
                    }
                }
                else
                {
                    string filter = tokens[1];

                    if (filter == "StartsWith")
                    {
                        string criteria = tokens[2];

                        string[] names = initialNames.FindAll(x => x.StartsWith(criteria)).ToArray();

                        foreach (var name in names)
                        {
                            int index = initialNames.IndexOf(name);
                            initialNames.Insert(index + 1, name);
                        }                     
                    }
                    else if (filter == "EndsWith")
                    {
                        string criteria = tokens[2];

                        string[] names = initialNames.FindAll(x => x.EndsWith(criteria)).ToArray();

                        foreach (var name in names)
                        {
                            int index = initialNames.IndexOf(name);
                            initialNames.Insert(index + 1, name);
                        }
                    }
                    else
                    {
                        int len = int.Parse(tokens[2]);

                        string[] names = initialNames.FindAll(x => x.Length == len).ToArray();

                        foreach (var name in names)
                        {
                            int index = initialNames.IndexOf(name);
                            initialNames.Insert(index + 1, name);
                        }
                    }
                }
            }

            if (initialNames.Count>0)
            {
                Console.WriteLine($"{string.Join(", ",initialNames)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
    }
}
