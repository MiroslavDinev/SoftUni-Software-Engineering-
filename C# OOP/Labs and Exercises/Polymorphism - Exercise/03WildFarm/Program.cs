using System;
using System.Collections.Generic;
using WildFarmEdited.Animals;
using WildFarmEdited.Factories;

namespace WildFarmEdited
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            while (true)
            {
                string command = Console.ReadLine();

                if(command == "End")
                {
                    break;
                }

                string[] animalArgs = command.Split();

                var animal = AnimalFactory.Create(animalArgs);
                animals.Add(animal);

                string[] foodArgs = Console.ReadLine().Split();

                var food=FoodFactory.Create(foodArgs);

                Console.WriteLine(animal.AskFood());

                try
                {
                    animal.Eat(food);
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
