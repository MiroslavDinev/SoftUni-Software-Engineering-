using System;
using System.Linq;
using System.Collections.Generic;

namespace _02OnTheWayToAnnapurna
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> storeItems = new Dictionary<string, List<string>>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "END")
                {
                    break;
                }

                if (!command.Contains(','))
                {
                    string[] tokens = command.Split("->");
                    string action = tokens[0];

                    if (action == "Add")
                    {
                        string storeName = tokens[1];
                        string item = tokens[2];

                        if (!storeItems.ContainsKey(storeName))
                        {
                            storeItems.Add(storeName, new List<string>());
                            storeItems[storeName].Add(item);
                        }
                        else
                        {
                            storeItems[storeName].Add(item);
                        }
                    }
                    else
                    {
                        string storeName = tokens[1];

                        if (storeItems.ContainsKey(storeName))
                        {
                            storeItems.Remove(storeName);
                        }
                    }
                }
                else
                {
                    string[] tokens = command.Split("->");
                    string action = tokens[0];
                    string store = tokens[1];
                    string[] tokens1 = tokens[2].Split(",");

                    if (!storeItems.ContainsKey(store))
                    {
                        storeItems.Add(store, new List<string>());
                        storeItems[store].AddRange(tokens1);
                    }
                    else
                    {
                        storeItems[store].AddRange(tokens1);
                    }
                }
            }

            Console.WriteLine("Stores list:");

            foreach (var kvp in storeItems.OrderByDescending(x=>x.Value.Count()).ThenByDescending(x=>x.Key))
            {
                string name = kvp.Key;
                List<string> items = kvp.Value;

                Console.WriteLine(name);

                foreach (var item in items)
                {
                    Console.WriteLine($"<<{item}>>");
                }
            }
        }
    }
}
