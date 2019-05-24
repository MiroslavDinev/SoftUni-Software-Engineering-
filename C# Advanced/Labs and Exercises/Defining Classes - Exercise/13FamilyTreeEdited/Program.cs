using System;
using System.Linq;
using System.Collections.Generic;

namespace _13FamilyTreeEdited
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<Connection> connections = new List<Connection>();

            List<Person> allPersonsData = new List<Person>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                if (command.Contains("-"))
                {
                    string[] data = command.Split(" - ");
                    string parentData = data[0];
                    string childData = data[1];

                    Person parent = new Person(parentData);
                    Person child = new Person(childData);
                    Connection connection = new Connection(parent, child);
                    connections.Add(connection);
                }
                else
                {
                    string[] data = command.Split();

                    string wholeName = $"{data[0]} {data[1]}";
                    string birthday = data[2];

                    Person person = new Person(wholeName, birthday);
                    allPersonsData.Add(person);
                }
            }

            Person mainPerson = allPersonsData
                .Where(x => x.Name == input || x.Birthday == input)
                .FirstOrDefault();

            var filteredConnections = connections
                .Where(x => x.Parent.Birthday == mainPerson.Birthday ||
                x.Children.Birthday == mainPerson.Birthday || 
                x.Parent.Name == mainPerson.Name || 
                x.Children.Name == mainPerson.Name)
                .ToList();

            foreach (var connection in filteredConnections)
            {
                bool isChildByName = connection.Children.Name == mainPerson.Name;
                bool isChildByDate = connection.Children.Birthday == mainPerson.Birthday;

                bool isParentByName = connection.Parent.Name == mainPerson.Name;
                bool isParentByDate = connection.Parent.Birthday == mainPerson.Birthday;

                if (isChildByName || isChildByDate)
                {
                    Person parent = allPersonsData
                        .Where(x => x.Name == connection.Parent.Name || x.Birthday == connection.Parent.Birthday)
                        .FirstOrDefault();

                    mainPerson.Parents.Add(parent);
                }
                else if (isParentByDate || isParentByName)
                {
                    Person children = allPersonsData
                        .FirstOrDefault(x => x.Name == connection.Children.Name || x.Birthday == connection.Children.Birthday);

                    mainPerson.Children.Add(children);
                }
            }

            Console.WriteLine(mainPerson);
            Console.WriteLine("Parents:");
            if (mainPerson.Parents.Any())
            {
                foreach (var parent in mainPerson.Parents)
                {
                    Console.WriteLine(parent);
                }
            }
            Console.WriteLine("Children:");
            if (mainPerson.Children.Any())
            {
                foreach (var child in mainPerson.Children)
                {
                    Console.WriteLine(child);
                }
            }
        }
    }
}
