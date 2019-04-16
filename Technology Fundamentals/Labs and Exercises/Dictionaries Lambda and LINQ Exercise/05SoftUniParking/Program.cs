using System;
using System.Collections.Generic;

namespace _05SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, string> regAndNum = new Dictionary<string, string>();

            for (int i = 0; i < n; i++)
            {
                string command = Console.ReadLine();
                string[] tokens = command.Split();

                string action = tokens[0];

                if (action == "register")
                {
                    string username = tokens[1];
                    string plateNum = tokens[2];

                    if (!regAndNum.ContainsKey(username))
                    {
                        regAndNum[username] = plateNum;
                        Console.WriteLine("{0} registered {1} successfully", username, plateNum);
                        continue;
                    }
                    else
                    {
                        string currNum = regAndNum[username];
                        Console.WriteLine("ERROR: already registered with plate number {0}", plateNum);
                        continue;
                    }
                }
                else if (action == "unregister")
                {
                    string username = tokens[1];

                    if (!regAndNum.ContainsKey(username))
                    {
                        Console.WriteLine("ERROR: user {0} not found", username);
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("{0} unregistered successfully", username);
                        regAndNum.Remove(username);
                        continue;
                    }
                }
            }
            foreach (var kvp in regAndNum)
            {
                Console.WriteLine("{0} => {1}", kvp.Key, kvp.Value);
            }
        }
    }
}
