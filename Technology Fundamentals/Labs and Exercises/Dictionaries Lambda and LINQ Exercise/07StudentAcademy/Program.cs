using System;
using System.Linq;
using System.Collections.Generic;

namespace _07StudentAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> studentsAndGrades = new Dictionary<string, List<double>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double currGrade = double.Parse(Console.ReadLine());

                if (!studentsAndGrades.ContainsKey(name))
                {
                    studentsAndGrades.Add(name, new List<double>());
                }
                studentsAndGrades[name].Add(currGrade);

            }

            var filteredDict = studentsAndGrades.Where(x => x.Value.Average() >= 4.50).ToDictionary(y => y.Key, y => y.Value);

            foreach (var kvp in filteredDict.OrderByDescending(x=>x.Value.Average()))
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value.Average():f2}");
            }
        }
    }
}
