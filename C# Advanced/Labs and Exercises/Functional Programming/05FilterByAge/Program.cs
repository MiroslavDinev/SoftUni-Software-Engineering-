using System;
using System.Linq;
using System.Collections.Generic;

namespace _05FilterByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, int> namesAge = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(", ");

                string name = tokens[0];
                int age = int.Parse(tokens[1]);

                if (!namesAge.ContainsKey(name))
                {
                    namesAge.Add(name, age);
                }
            }

            string condition = Console.ReadLine();

            int ageCondition = int.Parse(Console.ReadLine());

            Dictionary<string, int> answer = new Dictionary<string, int>();

            var sorted = SortNamesAndAge(namesAge,condition,ageCondition,answer);

            string format = Console.ReadLine();

            Print(sorted, format);
        }

        public static Dictionary<string, int> SortNamesAndAge (Dictionary<string, int> namesAge,string condition, int age, Dictionary<string, int> answer)
        {
            if (condition == "older")
            {
                foreach (var kvp in namesAge)
                {
                    string name = kvp.Key;
                    int personAge = kvp.Value;

                    if (personAge>=age)
                    {
                        answer.Add(name, personAge);
                    }
                }
            }
            else
            {
                foreach (var kvp in namesAge)
                {
                    string name = kvp.Key;
                    int personAge = kvp.Value;

                    if (personAge < age)
                    {
                        answer.Add(name, personAge);
                    }
                }
            }

            return answer;
        }

        public static void Print (Dictionary<string, int> sorted, string format)
        {
            if (format=="name age")
            {
                foreach (var kvp in sorted)
                {
                    Console.WriteLine($"{kvp.Key} - {kvp.Value}");
                }
            }
            else if (format == "name")
            {
                foreach (var kvp in sorted)
                {
                    Console.WriteLine($"{kvp.Key}");
                }
            }
            else if (format == "age")
            {
                foreach (var kvp in sorted)
                {
                    Console.WriteLine($"{kvp.Value}");
                }
            }
        }
    }
}
