using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13ShoppingMania
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());

            double spentMoney = 0;
            int clothesCounter = 0;

            while (budget >0)
            {
                string command = Console.ReadLine();

                if (command == "enough")
                {
                    break;
                }
                

                if (command == "enter")
                {
                    command = Console.ReadLine();

                    while (command != "leave")
                    {
                        double money = double.Parse(command);

                        if (money>budget)
                        {
                            Console.WriteLine("Not enough money.");
                        }
                        else
                        {
                            clothesCounter++;
                            spentMoney += money;
                            budget -= money;
                        }
                        if (budget<=0)
                        {
                            break;
                        }
                        command = Console.ReadLine();
                    }

                }
            }
            Console.WriteLine($"For {clothesCounter} clothes I spent {spentMoney} lv and have {budget} lv left.");
        }
    }
}
