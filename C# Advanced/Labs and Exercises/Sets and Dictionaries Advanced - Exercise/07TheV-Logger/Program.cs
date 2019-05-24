using System;
using System.Linq;
using System.Collections.Generic;

namespace _07TheV_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            //Dictionary<string, List<string>> userFollowers = new Dictionary<string, List<string>>();
            //Dictionary<string, List<string>> userFollowing = new Dictionary<string, List<string>>();

            //while (true)
            //{
            //    string command = Console.ReadLine();

            //    if (command == "Statistics")
            //    {
            //        break;
            //    }

            //    else if (command.Contains("joined"))
            //    {
            //        string[] tokens = command.Split();
            //        string username = tokens[0];

            //        if (!userFollowers.ContainsKey(username))
            //        {
            //            userFollowers.Add(username, new List<string>());
            //            userFollowing.Add(username,new List<string>());
            //        }
            //    }
            //    else if (command.Contains("followed"))
            //    {
            //        string[] tokens = command.Split();
            //        string follower = tokens[0];
            //        string personToFollow = tokens[2];

            //        if (userFollowers.ContainsKey(follower) && userFollowers.ContainsKey(personToFollow) && follower!= personToFollow)
            //        {
            //            if (!userFollowers[personToFollow].Contains(follower))
            //            {
            //                userFollowers[personToFollow].Add(follower);
            //            }

            //            if (!userFollowing[follower].Contains(personToFollow))
            //            {
            //                userFollowing[follower].Add(personToFollow);
            //            }

            //        }
            //    }
            //}

            //Console.WriteLine($"The V-Logger has a total of {userFollowing.Keys.Count} vloggers in its logs.");

            //if (userFollowing.Keys.Count==0)
            //{
            //    return;
            //}

            //var mostFamous = userFollowers.OrderByDescending(x => x.Value.Count)
            //    .ThenBy(x => userFollowing[x.Key]).FirstOrDefault();

            //string mostFamousName = mostFamous.Key;

            //Console.WriteLine($"1. {mostFamousName} : {mostFamous.Value.Count()} followers, {userFollowing[mostFamous.Key].Count} following");

            //if (mostFamous.Value.Count>0)
            //{
            //    foreach (var item in mostFamous.Value.OrderBy(x => x))
            //    {
            //        Console.WriteLine($"*  {item}");
            //    }
            //}

            //int counter = 2;

            //foreach (var kvp in userFollowers.OrderByDescending(x=>x.Value.Count).ThenBy(x=>userFollowing[x.Key].Count))
            //{
            //    string name = kvp.Key;

            //    if (name!=mostFamousName)
            //    {
            //        Console.WriteLine($"{counter}. {name} : {kvp.Value.Count} followers, {userFollowing[name].Count} following");
            //        counter++;
            //    }
            //}

            // 60/100

            Dictionary<string, Dictionary<string, HashSet<string>>> database = new Dictionary<string, Dictionary<string, HashSet<string>>>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Statistics")
                {
                    break;
                }

                else if (command.Contains("joined"))
                {
                    string[] tokens = command.Split();
                    string username = tokens[0];

                    if (!database.ContainsKey(username))
                    {
                        database.Add(username, new Dictionary<string, HashSet<string>>());
                        database[username].Add("followers", new HashSet<string>());
                        database[username].Add("following", new HashSet<string>());
                    }
                }
                else if (command.Contains("followed"))
                {
                    string[] tokens = command.Split();
                    string follower = tokens[0];
                    string personToFollow = tokens[2];

                    if (database.ContainsKey(follower) && database.ContainsKey(personToFollow) && follower!=personToFollow)
                    {
                        database[follower]["following"].Add(personToFollow);
                        database[personToFollow]["followers"].Add(follower);
                    }
                }
            }

            int counter = 1;

            Console.WriteLine($"The V-Logger has a total of {database.Count} vloggers in its logs.");

            foreach (var kvp in database.OrderByDescending(x=>x.Value["followers"].Count).ThenBy(x=>x.Value["following"].Count))
            {
                Console.WriteLine($"{counter}. {kvp.Key} : {kvp.Value["followers"].Count} followers, {kvp.Value["following"].Count} following");

                if (counter==1)
                {
                    foreach (var follower in kvp.Value["followers"].OrderBy(f=>f))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
                counter++;
            }
        }
    }
}
