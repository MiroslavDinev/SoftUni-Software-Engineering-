using System;
using System.Linq;
using System.Collections.Generic;

namespace _02MakeASalad
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] veggiesInput = Console.ReadLine().Split();
            int[] caloriesInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<string> veggies = new Queue<string>(veggiesInput);
            Stack<int> calories = new Stack<int>(caloriesInput);
            Stack<int> caloriesOriginal = new Stack<int>(caloriesInput);

            List<int> salads = new List<int>();

            while (veggies.Any() && calories.Any())
            {
                string currVegie = veggies.Dequeue();
                int currCalories = calories.Peek();               
                int veggieCal = 0;

                if(currVegie == "tomato")
                {
                    veggieCal = 80;
                }
                else if (currVegie == "carrot")
                {
                    veggieCal = 136;
                }
                else if (currVegie == "lettuce")
                {
                    veggieCal = 109;
                }
                else if (currVegie == "potato")
                {
                    veggieCal = 215;
                }

                if(veggieCal>=currCalories)
                {
                    salads.Add(caloriesOriginal.Pop());
                    calories.Pop();
                }
                else
                {
                    currCalories -= veggieCal;
                    calories.Pop();
                    calories.Push(currCalories);
                }
            }

            

            if(calories.Any())
            {
                if(calories.Peek()!=caloriesOriginal.Peek())
                {
                    calories.Pop();
                    caloriesOriginal.Reverse();
                    salads.Add(caloriesOriginal.Pop());
                }
                Console.WriteLine(string.Join(" ", salads));
                Console.WriteLine(string.Join(" ",calories));
            }
            else
            {
                Console.WriteLine(string.Join(" ", salads));
                Console.WriteLine(string.Join(" ",veggies));
            }
        }
    }
}
