using System;
using System.Collections.Generic;

namespace _05ComparingObjects
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            while (true)
            {
                string command = Console.ReadLine();

                if(command == "END")
                {
                    break;
                }

                string[] tokens = command.Split();

                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                string town = tokens[2];

                Person person = new Person(name, age, town);
                people.Add(person);
            }

            int personIndex = int.Parse(Console.ReadLine()) - 1;

            Person personToCompare = people[personIndex];

            int equal = 0;
            int nonEqual = 0;

            foreach (Person person in people)
            {
                if(person.CompareTo(personToCompare)==0)
                {
                    equal++;
                }
                else
                {
                    nonEqual++;
                }
            }

            if(equal==1)
            {
                Console.WriteLine("No matches");
            }
            else if (equal>1)
            {
                Console.WriteLine($"{equal} {nonEqual} {people.Count}");
            }
        }
    }
}
