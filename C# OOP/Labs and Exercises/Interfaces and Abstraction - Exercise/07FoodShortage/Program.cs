using System;
using System.Collections.Generic;
using System.Linq;

namespace _07FoodShortage
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<IBuyer> buyers = new List<IBuyer>();

            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string[] tokens = Console.ReadLine().Split();

                if(tokens.Length==3)
                {
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string group = tokens[2];

                    Rebel rebel = new Rebel(name, age, group);

                    buyers.Add(rebel);
                }
                else
                {
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string id = tokens[2];
                    string birthday = tokens[3];

                    Citizen citizen = new Citizen(name, age, id, birthday);

                    buyers.Add(citizen);
                }
            }

            while (true)
            {
                string command = Console.ReadLine();

                if(command == "End")
                {
                    break;
                }

                foreach (var person in buyers)
                {
                    if(person.Name==command)
                    {
                         person.BuyFood();
                    }
                }
            }

            Console.WriteLine(buyers.Sum(x=>x.Food));
        }
    }
}
