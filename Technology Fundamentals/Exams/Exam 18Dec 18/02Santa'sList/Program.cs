using System;
using System.Linq;
using System.Collections.Generic;

namespace _02Santa_sList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> initialNames = Console.ReadLine().Split("&").ToList();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Finished!")
                {
                    break;
                }

                string[] tokens = command.Split();

                string action = tokens[0];

                if (action == "Bad")
                {
                    string name = tokens[1];

                    if (!initialNames.Contains(name))
                    {
                        initialNames.Insert(0, name);
                    }
                }
                else if (action == "Good")
                {
                    string name = tokens[1];

                    if (initialNames.Contains(name))
                    {
                        initialNames.Remove(name);
                    }
                }
                else if (action == "Rename")
                {
                    string oldName = tokens[1];
                    string newName = tokens[2];

                    if (initialNames.Contains(oldName))
                    {
                        int index = initialNames.IndexOf(oldName);
                        initialNames.RemoveAt(index);
                        initialNames.Insert(index, newName);
                    }
                }
                else if (action == "Rearrange")
                {
                    string name = tokens[1];

                    if (initialNames.Contains(name))
                    {
                        initialNames.Remove(name);
                        initialNames.Add(name);
                    }
                }
            }

            Console.WriteLine(string.Join(", ",initialNames));
        }
    }
}
