using System;
using System.Linq;
using System.Collections.Generic;

namespace _02AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> nameGrades = new Dictionary<string, List<double>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();

                string name = tokens[0];
                double grade = double.Parse(tokens[1]);

                if (!nameGrades.ContainsKey(name))
                {
                    nameGrades.Add(name, new List<double>());
                    nameGrades[name].Add(grade);
                }
                else
                {
                    nameGrades[name].Add(grade);
                }
            }

            foreach (var kvp in nameGrades)
            {
                string name = kvp.Key;
                List<double> grades = kvp.Value;

                Console.Write(name +" -> ");

                foreach (var grade in grades)
                {
                    Console.Write($"{grade:f2} ");
                }
                Console.Write($"(avg: {grades.Average():f2})");
                Console.WriteLine();
            }
        }
    }
}
