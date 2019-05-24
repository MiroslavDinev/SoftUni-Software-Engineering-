using System;
using System.Collections.Generic;

namespace _06StrategyPattern
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            SortedSet<Person> peopleByName = new SortedSet<Person>(new NameComparator());
            SortedSet<Person> peopleByAge = new SortedSet<Person>(new AgeComparator());

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split();

                string name = data[0];
                int age = int.Parse(data[1]);

                Person person = new Person(name, age);

                peopleByName.Add(person);
                peopleByAge.Add(person);
            }

            foreach (Person person1 in peopleByName)
            {
                Console.WriteLine(person1);
            }

            foreach (Person person2 in peopleByAge)
            {
                Console.WriteLine(person2);
            }
        }
    }
}
