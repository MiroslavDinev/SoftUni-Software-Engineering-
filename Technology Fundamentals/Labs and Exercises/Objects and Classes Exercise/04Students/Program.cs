using System;
using System.Collections.Generic;
using System.Linq;

namespace _04Students
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}: {Grade:f2}".ToString();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Student> students = new List<Student>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string firstName = input[0];
                string lastName = input[1];
                double grade = double.Parse(input[2]);

                students.Add(new Student
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Grade = grade
                });
            }

            var filtered = students.OrderByDescending(x => x.Grade);
            Console.WriteLine(string.Join(Environment.NewLine,filtered));
        }
    }
}
