using System;
using System.Collections.Generic;

namespace _05BorderControl
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<IId> ids = new List<IId>();

            while (true)
            {
                string command = Console.ReadLine();

                if(command == "End")
                {
                    break;
                }

                string[] tokens = command.Split();

                if(tokens.Length==3)
                {
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string id = tokens[2];

                    Citizen citizen = new Citizen(name, age, id);
                    ids.Add(citizen);
                }
                else
                {
                    string model = tokens[0];
                    string id = tokens[1];

                    Robot robot = new Robot(model, id);
                    ids.Add(robot);
                }
            }

            string lastDigits = Console.ReadLine();

            foreach (var entry in ids)
            {
                if(entry.ID.EndsWith(lastDigits))
                {
                    Console.WriteLine(entry.ID);
                }
            }
        }
    }
}
