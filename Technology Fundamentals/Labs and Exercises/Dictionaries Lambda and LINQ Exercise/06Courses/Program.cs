using System;
using System.Linq;
using System.Collections.Generic;

namespace _06Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courseAndStudentName = new Dictionary<string, List<string>>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }

                string[] tokens = command.Split(" : ");

                string course = tokens[0];
                string student = tokens[1];

                if (!courseAndStudentName.ContainsKey(course))
                {
                    courseAndStudentName.Add(course,new List<string>());
                    courseAndStudentName[course].Add(student);
                }
                else
                {
                    courseAndStudentName[course].Add(student);
                }
            }

            foreach (var kvp in courseAndStudentName.OrderByDescending(x=>x.Value.Count))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value.Count}");

                foreach (var name in kvp.Value.OrderBy(x=>x))
                {
                    Console.WriteLine($"-- {name}");
                }
            }
        }
    }
}
