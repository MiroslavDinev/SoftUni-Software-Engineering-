using System;
using System.Linq;
using System.Collections.Generic;

namespace _07OrderByAge
{
    public class Program
    {
        public class Person
        {
            public string Name { get; set; }
            public string ID { get; set; }
            public int Age { get; set; }
        }
        public static void Main()
        {
            List<Person> people = new List<Person>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                string[] tokens = command.Split();

                string name = tokens[0];
                string id = tokens[1];
                int age = int.Parse(tokens[2]);

                people.Add(new Person
                {
                    Name = name,
                    ID = id,
                    Age = age
                });
            }

            foreach (var currPerson in people.OrderBy(x => x.Age))
            {
                Console.WriteLine("{0} with ID: {1} is {2} years old.", currPerson.Name, currPerson.ID, currPerson.Age);
            }
        }
    }
}
