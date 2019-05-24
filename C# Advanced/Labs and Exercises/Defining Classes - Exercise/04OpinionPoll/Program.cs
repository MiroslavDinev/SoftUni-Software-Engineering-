namespace DefiningClasses
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Person> persons = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split();
                string name = info[0];
                int age = int.Parse(info[1]);

                Person person = new Person(name, age);

                if (person.Age>30)
                {
                    persons.Add(person);
                }
            }

            foreach (Person person in persons.OrderBy(x=>x.Name))
            {
                Console.WriteLine(person);
            }
        }
    }
}
