using System;
using System.Linq;
using System.Collections.Generic;

namespace _01CompanyRoster
{
    public class Employee
    {
        public string Name { get; set; }
        public double Salary { get; set; }
        public string Department { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Employee> workers = new List<Employee>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string name = tokens[0];
                double salary = double.Parse(tokens[1]);
                string department = tokens[2];

                workers.Add(new Employee
                {
                    Name = name,
                    Salary = salary,
                    Department = department
                });
            }

            var filtered = workers.GroupBy(x => x.Department).Select(x => new
            {
                Department = x.Key,
                AverageSalary = x.Average(emp => emp.Salary),
                Employee = x.OrderByDescending(emp => emp.Salary)
            }).OrderByDescending(dep=>dep.AverageSalary).FirstOrDefault();

            Console.WriteLine($"Highest Average Salary: {filtered.Department}");

            foreach (var currworker in filtered.Employee)
            {
                Console.WriteLine($"{currworker.Name} {currworker.Salary:f2}");
            }
        }  // https://pastebin.com/8KRj9BDk malko po-razbirame reshenie
    }
}
