using System;
using System.Collections.Generic;
using Animals.Animals;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            while (true)
            {
                string animalType = Console.ReadLine();

                if (animalType == "Beast!")
                {
                    break;
                }               

                try
                {
                    string[] tokens = Console.ReadLine().Split();

                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string gender = tokens[2];

                    if (animalType == "Dog")
                    {
                        animals.Add(new Dog(name, age, gender));
                    }
                    else if (animalType == "Frog")
                    {
                        animals.Add(new Frog(name, age, gender));
                    }
                    else if (animalType=="Cat")
                    {
                        animals.Add(new Cat(name, age, gender));
                    }
                    else if (animalType == "Kitten")
                    {
                        animals.Add(new Kitten(name, age, gender));
                    }
                    else if (animalType == "Tomcat")
                    {
                        animals.Add(new Tomcat(name, age, gender));
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }

            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal.GetType().Name);
                Console.WriteLine(animal);
            }
        }
    }
}

