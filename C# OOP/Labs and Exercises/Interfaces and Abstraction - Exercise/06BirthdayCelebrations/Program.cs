using System;
using System.Collections.Generic;

namespace _06BirthdayCelebrations
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<IBirthdate> birthdates = new List<IBirthdate>();

            while (true)
            {
                string command = Console.ReadLine();

                if(command == "End")
                {
                    break;
                }

                string[] tokens = command.Split();

                string type = tokens[0];

                if(type == "Citizen")
                {
                    string name = tokens[1];
                    int age = int.Parse(tokens[2]);
                    string id = tokens[3];
                    string birtday = tokens[4];

                    Citizen citizen = new Citizen(name, age, id, birtday);

                    birthdates.Add(citizen);
                }
                else if (type == "Pet")
                {
                    string name = tokens[1];
                    string birthday = tokens[2];

                    Pet pet = new Pet(name, birthday);

                    birthdates.Add(pet);
                }
            }

            string year = Console.ReadLine();

            foreach (var liveForm in birthdates)
            {
                if(liveForm.Birthday.EndsWith(year))
                {
                    Console.WriteLine(liveForm.Birthday);
                }
            }
        }
    }
}
