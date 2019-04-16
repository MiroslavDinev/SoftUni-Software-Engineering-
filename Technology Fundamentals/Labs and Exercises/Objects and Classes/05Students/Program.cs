using System;
using System.Linq;
using System.Collections.Generic;

namespace _05Students
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Hometown { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }

                string[] tokens = command.Split();
                string firstName = tokens[0];
                string lastName = tokens[1];
                int age = int.Parse(tokens[2]);
                string town = tokens[3];

                Student student = students.FirstOrDefault(n => n.FirstName == firstName && n.LastName == lastName);

                if (student==null)
                {
                    students.Add(new Student
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Age = age,
                        Hometown = town

                    });
                }
                else
                {
                    student.FirstName = firstName;
                    student.LastName = lastName;
                    student.Age = age;
                    student.Hometown = town;
                }
                
                
            }

            string cityName = Console.ReadLine();

            var filteredStudents = students.Where(s => s.Hometown == cityName).ToList();

            foreach (var currStudent in filteredStudents)
            {
                Console.WriteLine($"{currStudent.FirstName} {currStudent.LastName} is {currStudent.Age} years old.");
            }
        }
    }
}
