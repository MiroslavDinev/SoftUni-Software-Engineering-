using System;
using System.Linq;
using System.Collections.Generic;

namespace _02OldestFamilyMember
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Person> persons = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string name = tokens[0];
                int age = int.Parse(tokens[1]);

                persons.Add(new Person
                {
                    Name = name,
                    Age = age
                });
            }

            int maxAge = persons.Select(x => x.Age).Max();
            int counter = 0;

            foreach (var currPerson in persons.Where(x=>x.Age == maxAge))
            {
                Console.WriteLine($"{currPerson.Name} {currPerson.Age}");
                counter++;
                if (counter>0)
                {
                    break;
                }
            }
        }
    }
}
