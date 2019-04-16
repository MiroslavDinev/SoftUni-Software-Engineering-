using System;
using System.Linq;
using System.Collections.Generic;

namespace _05ShoppingSpree
{
    public class Person
    {
        public Person(string name, double money)
        {
            Name = name;
            Money = money;
            BagOfProducts = new List<string>();
        }

        public string Name { get; set; }
        public double Money { get; set; }
        public List<string> BagOfProducts { get; set; }
    }
    public class Product
    {
        public string Name { get; set; }
        public double Cost { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] personProps = Console.ReadLine().Split(new [] { '=', ';' },StringSplitOptions.RemoveEmptyEntries).ToArray();
            string[] productProps = Console.ReadLine().Split(new [] { '=', ';' },StringSplitOptions.RemoveEmptyEntries).ToArray();

            List<Person> persons = new List<Person>();
            List<Product> products = new List<Product>();

            for (int i = 0; i < personProps.Length; i+=2)
            {
                string name = personProps[i];
                double money =double.Parse(personProps[i + 1]);

                Person person = new Person(name, money);

                persons.Add(person);
            }

            for (int i = 0; i < productProps.Length; i+=2)
            {
                string product = productProps[i];
                double price =double.Parse(productProps[i + 1]);

                products.Add(new Product
                {
                    Name = product,
                    Cost = price
                });
            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "END")
                {
                    break;
                }

                string[] tokens = command.Split();
                string personName = tokens[0];
                string productName = tokens[1];

                int indexOfPerson = persons.FindIndex(x => x.Name == personName);
                int indexOfProduct = products.FindIndex(p => p.Name == productName);

                if (persons[indexOfPerson].Money>=products[indexOfProduct].Cost)
                {
                    persons[indexOfPerson].BagOfProducts.Add(productName);
                    persons[indexOfPerson].Money -= products[indexOfProduct].Cost;
                    Console.WriteLine($"{personName} bought {productName}");
                }
                else
                {
                    Console.WriteLine($"{personName} can't afford {productName}");
                }
            }

            foreach (var currPerson in persons)
            {
                if (currPerson.BagOfProducts.Count>0)
                {
                    Console.WriteLine($"{currPerson.Name} - {string.Join(", ",currPerson.BagOfProducts)}");
                }
                else
                {
                    Console.WriteLine($"{currPerson.Name} - Nothing bought");
                }
            }
        }
    }
}
