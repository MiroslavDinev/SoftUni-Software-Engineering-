using System;
using System.Linq;
using System.Collections.Generic;

namespace _12Google
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, Person> persons = new Dictionary<string, Person>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                string[] tokens = command.Split();
                string personName = tokens[0];

                if (!persons.ContainsKey(personName))
                {
                    persons.Add(personName, new Person(personName));
                }

                string filter = tokens[1];

                if (filter == "company")
                {
                    string companyName = tokens[2];
                    string department = tokens[3];
                    double salary = double.Parse(tokens[4]);

                    Company company = new Company(companyName, department, salary);

                    persons[personName].Company = company;
                }
                else if (filter == "car")
                {
                    string carName = tokens[2];
                    int speed = int.Parse(tokens[3]);

                    Car car = new Car(carName, speed);

                    persons[personName].Car = car;
                }
                else if (filter == "pokemon")
                {
                    string name = tokens[2];
                    string type = tokens[3];

                    Pokemon pokemon = new Pokemon(name, type);

                    persons[personName].Pokemons.Add(pokemon);
                }
                else if (filter == "parents")
                {
                    string name = tokens[2];
                    string birthday = tokens[3];

                    Parent parent = new Parent(name, birthday);

                    persons[personName].Parents.Add(parent);
                }
                else if (filter == "children")
                {
                    string name = tokens[2];
                    string birthday = tokens[3];

                    Children children = new Children(name, birthday);

                    persons[personName].Childrens.Add(children);
                }
            }

            string input = Console.ReadLine();

            foreach (var kvp in persons)
            {
                Person person = kvp.Value;

                if (person.Name==input)
                {
                    Console.WriteLine(person.Name);
                    Console.WriteLine("Company:");
                    if (person.Company!=null)
                    {
                        Console.WriteLine($"{person.Company.Name} {person.Company.Department} {person.Company.Salary:f2}");
                    }
                    Console.WriteLine("Car:");
                    if(person.Car!=null)
                    {
                        Console.WriteLine($"{person.Car.Model} {person.Car.Speed}");
                    }
                    Console.WriteLine("Pokemon:");
                    if (person.Pokemons.Any())
                    {
                        foreach (Pokemon pokemon in person.Pokemons)
                        {
                            Console.WriteLine($"{pokemon.Name} {pokemon.Type}");
                        }
                    }
                    Console.WriteLine("Parents:");
                    if (person.Parents.Any())
                    {
                        foreach (Parent parent in person.Parents)
                        {
                            Console.WriteLine($"{parent.Name} {parent.Birthday}");
                        }
                    }
                    Console.WriteLine("Children:");
                    if(person.Childrens.Any())
                    {
                        foreach (Children children in person.Childrens)
                        {
                            Console.WriteLine($"{children.Name} {children.Birthday}");
                        }
                    }
                }
            }
        }
    }
}
