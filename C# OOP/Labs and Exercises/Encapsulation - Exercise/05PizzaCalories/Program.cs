using System;

namespace _05PizzaCalories
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                string[] pizzaProps = Console.ReadLine().Split();

                string name = pizzaProps[1];

                string[] doughProps = Console.ReadLine().Split();
                string type = doughProps[1];
                string tech = doughProps[2];
                double grams = double.Parse(doughProps[3]);

                Dough dough = new Dough(type, tech, grams);

                Pizza pizza = new Pizza(name, dough);

                while (true)
                {
                    string command = Console.ReadLine();

                    if (command == "END")
                    {
                        break;
                    }

                    string[] input = command.Split();
                   
                    string typeTopping = input[1];
                    double gramsTopping = double.Parse(input[2]);
                
                    Topping topping = new Topping(typeTopping, gramsTopping);
                    pizza.Add(topping);
                    
                }
                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:f2} Calories.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            } 
        }
    }
}
