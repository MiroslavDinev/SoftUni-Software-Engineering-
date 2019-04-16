using System;
using System.Linq;
using System.Collections.Generic;

namespace _10SoftUniExamResults
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> studentsAndPoints = new Dictionary<string, int>();
            Dictionary<string, int> langAndCount = new Dictionary<string, int>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "exam finished")
                {
                    break;
                }

                string[] tokens = line.Split('-');

                if (tokens.Length > 2)
                {
                    string username = tokens[0];
                    string language = tokens[1];
                    int points = int.Parse(tokens[2]);

                    if (!langAndCount.ContainsKey(language))
                    {
                        langAndCount[language] = 1;
                    }
                    else
                    {
                        langAndCount[language]++;
                    }



                    if (!studentsAndPoints.ContainsKey(username))
                    {
                        studentsAndPoints[username] = points;
                    }
                    else
                    {
                        if (points > studentsAndPoints[username])
                        {
                            studentsAndPoints[username] = points;
                        }
                    }
                }
                else
                {
                    string username = tokens[0];
                    string banned = tokens[1];

                    if (studentsAndPoints.ContainsKey(username))
                    {
                        studentsAndPoints.Remove(username);
                    }
                }
            }

            Console.Write("Results:");
            Console.WriteLine();

            foreach (var kvp in studentsAndPoints.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine("{0} | {1}", kvp.Key, kvp.Value);
            }

            Console.WriteLine("Submissions:");

            foreach (var kvp in langAndCount.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine("{0} - {1}", kvp.Key, kvp.Value);
            }
        }
    }
}
