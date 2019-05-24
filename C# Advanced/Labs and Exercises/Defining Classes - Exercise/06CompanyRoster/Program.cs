namespace _06CompanyRoster
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Employee> employees = new List<Employee>();
            List<string> departments = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split();

                string name = data[0];
                double salary = double.Parse(data[1]);
                string position = data[2];
                string department = data[3];

                Employee employee = new Employee(name, salary, position, department);

                if (data.Length==6)
                {
                    string email = data[4];
                    int age =int.Parse(data[5]);

                    employee.Email = email;
                    employee.Age = age;
                }
                else if (data.Length==5)
                {
                    bool isAge = int.TryParse(data[4], out int age);

                    if (isAge)
                    {
                        employee.Age = age;
                    }
                    else
                    {
                        string email = data[4];

                        employee.Email = email;
                    }
                }

                employees.Add(employee);
                departments.Add(department);
            }

            departments=departments.Distinct().ToList();

            string bestDepartment = string.Empty;
            double maxAvgSalary = 0;

            foreach (string department in departments)
            {
                double currAvgSalary = employees.Where(e => e.Department == department).Select(e => e.Salary).Average();

                if (currAvgSalary>maxAvgSalary)
                {
                    maxAvgSalary = currAvgSalary;
                    bestDepartment = department;
                }
            }

            Console.WriteLine($"Highest Average Salary: {bestDepartment}");

            foreach (Employee employee in employees.Where(e=>e.Department==bestDepartment).OrderByDescending(e=>e.Salary))
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:f2} {employee.Email} {employee.Age}");
            }
        }
    }
}
