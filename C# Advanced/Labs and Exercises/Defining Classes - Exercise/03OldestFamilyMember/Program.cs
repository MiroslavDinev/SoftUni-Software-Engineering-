namespace _03OldestFamilyMember
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using DefiningClasses;

    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Family family = new Family();

            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split();
                string name = info[0];
                int age = int.Parse(info[1]);

                Person person = new Person(name, age);

                family.AddMember(person);
            }

            Person oldestMember = family.GetOldestMember();

            Console.WriteLine(oldestMember);
        }
    }
}
