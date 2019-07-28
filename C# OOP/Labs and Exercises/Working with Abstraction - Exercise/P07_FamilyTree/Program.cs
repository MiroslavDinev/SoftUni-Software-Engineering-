using System;
using System.Collections.Generic;
using System.Linq;

namespace P07_FamilyTree
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Person> familyTree = new List<Person>();

            string personInput = Console.ReadLine();

            Person mainPerson = new Person();

            if (IsBirthday(personInput))
            {
                mainPerson.Birthday = personInput;
            }
            else
            {
                mainPerson.Name = personInput;
            }

            familyTree.Add(mainPerson);

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] tokens = command.Split(" - ");

                if (tokens.Length > 1)
                {
                    string firstPersonInput = tokens[0];
                    string secondPersonInput = tokens[1];

                    Person currentPerson = null;

                    if (IsBirthday(firstPersonInput))
                    {
                        currentPerson = familyTree.FirstOrDefault(p => p.Birthday == firstPersonInput);

                        if (currentPerson == null)
                        {
                            currentPerson = new Person();
                            currentPerson.Birthday = firstPersonInput;
                            familyTree.Add(currentPerson);
                        }

                        SetChild(familyTree, currentPerson, secondPersonInput);
                    }
                    else
                    {
                        currentPerson = familyTree.FirstOrDefault(p => p.Name == firstPersonInput);

                        if (currentPerson == null)
                        {
                            currentPerson = new Person();
                            currentPerson.Name = firstPersonInput;
                            familyTree.Add(currentPerson);
                        }

                        SetChild(familyTree, currentPerson, secondPersonInput);
                    }
                }
                else
                {
                    tokens = tokens[0].Split();
                    string name = $"{tokens[0]} {tokens[1]}";
                    string birthday = tokens[2];

                    Person person = familyTree.FirstOrDefault(p => p.Name == name || p.Birthday == birthday);

                    if (person == null)
                    {
                        person = new Person();
                        familyTree.Add(person);
                    }
                    person.Name = name;
                    person.Birthday = birthday;

                    int index = familyTree.IndexOf(person) + 1;
                    int count = familyTree.Count - index;

                    Person[] copy = new Person[count];
                    familyTree.CopyTo(index, copy, 0, count);

                    Person copyPerson = copy.FirstOrDefault(p => p.Name == name || p.Birthday == birthday);

                    if (copyPerson != null)
                    {
                        familyTree.Remove(copyPerson);
                        person.Parents.AddRange(copyPerson.Parents);
                        person.Parents = person.Parents.Distinct().ToList();

                        person.Children.AddRange(copyPerson.Children);
                        person.Children = person.Children.Distinct().ToList();
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(mainPerson);
            Console.WriteLine("Parents:");

            foreach (var parent in mainPerson.Parents)
            {
                Console.WriteLine(parent);
            }
            Console.WriteLine("Children:");

            foreach (var child in mainPerson.Children)
            {
                Console.WriteLine(child);
            }
        }

        public static void SetChild(List<Person> familyTree, Person parentPerson, string childInput)
        {
            Person childPerson = new Person();

            if (IsBirthday(childInput))
            {
                if (!familyTree.Any(p => p.Birthday == childInput))
                {
                    childPerson.Birthday = childInput;
                }
                else
                {
                    childPerson = familyTree.First(p => p.Birthday == childInput);
                }
            }
            else
            {
                if (!familyTree.Any(p => p.Name == childInput))
                {
                    childPerson.Name = childInput;
                }
                else
                {
                    childPerson = familyTree.First(p => p.Name == childInput);
                }
            }

            parentPerson.Children.Add(childPerson);
            childPerson.Parents.Add(parentPerson);
            familyTree.Add(childPerson);
        }

        public static bool IsBirthday(string input)
        {
            return Char.IsDigit(input[0]);
        }
    }
}
