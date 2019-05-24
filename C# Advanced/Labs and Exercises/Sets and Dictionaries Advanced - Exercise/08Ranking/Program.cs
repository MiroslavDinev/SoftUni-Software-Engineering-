using System;
using System.Linq;
using System.Collections.Generic;

namespace _08Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contestPass = new Dictionary<string, string>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end of contests")
                {
                    break;
                }

                string[] tokens = command.Split(":");
                string name = tokens[0];
                string pass = tokens[1];

                contestPass.Add(name, pass);
            }

            Dictionary<string, Dictionary<string, int>> userContestPoints = new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "end of submissions")
                {
                    break;
                }

                string[] tokens = line.Split("=>");
                string contestName = tokens[0];
                string contestPassword = tokens[1];
                string personName = tokens[2];
                int personPoints = int.Parse(tokens[3]);

                if (contestPass.ContainsKey(contestName) && contestPass[contestName]==contestPassword)
                {
                    if (!userContestPoints.ContainsKey(personName))
                    {
                        userContestPoints.Add(personName, new Dictionary<string, int>());
                        userContestPoints[personName].Add(contestName, personPoints);
                    }
                    else if (userContestPoints.ContainsKey(personName)==true && userContestPoints[personName].ContainsKey(contestName)==false)
                    {
                        userContestPoints[personName].Add(contestName, personPoints);
                    }
                    else if (userContestPoints.ContainsKey(personName) == true && userContestPoints[personName].ContainsKey(contestName) == true)
                    {
                        if (personPoints> userContestPoints[personName][contestName])
                        {
                            userContestPoints[personName][contestName] = personPoints;
                        }
                    }
                }
            }

            string bestName = string.Empty;
            int bestPoints = 0;

            foreach (var kvp in userContestPoints)
            {
                string name = kvp.Key;

                int totalPoints = 0;

                foreach (var inner in kvp.Value)
                {
                    int points = inner.Value;
                    totalPoints += points;
                }

                if (totalPoints>bestPoints)
                {
                    bestPoints = totalPoints;
                    bestName = name;
                }
            }

            Console.WriteLine($"Best candidate is {bestName} with total {bestPoints} points.");
            Console.WriteLine("Ranking:");

            foreach (var kvp in userContestPoints.OrderBy(x=>x.Key))
            {
                string name = kvp.Key;

                Console.WriteLine(name);

                foreach (var inner in kvp.Value.OrderByDescending(p=>p.Value))
                {
                    string contest = inner.Key;
                    int points = inner.Value;

                    Console.WriteLine($"#  {contest} -> {points}");
                }
            }
        }
    }
}
