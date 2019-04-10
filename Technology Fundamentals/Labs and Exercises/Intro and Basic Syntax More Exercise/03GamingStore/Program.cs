using System;

namespace _03GamingStore
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal budget = decimal.Parse(Console.ReadLine());
            decimal copyOfBudget = budget;

            while (budget >= 0)
            {
                string command = Console.ReadLine();

                if (command == "Game Time")
                {
                    break;
                }
                else if (command == "OutFall 4")
                {
                    if (budget - 39.99m >= 0)
                    {
                        budget -= 39.99m;
                        Console.WriteLine("Bought {0}", command);
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                        continue;
                    }
                }
                else if (command == "CS: OG")
                {
                    if (budget - 15.99m >= 0)
                    {
                        budget -= 15.99m;
                        Console.WriteLine("Bought {0}", command);
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                        continue;
                    }
                }
                else if (command == "Zplinter Zell")
                {
                    if (budget - 19.99m >= 0)
                    {
                        budget -= 19.99m;
                        Console.WriteLine("Bought {0}", command);
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                        continue;
                    }
                }
                else if (command == "Honored 2")
                {
                    if (budget - 59.99m >= 0)
                    {
                        budget -= 59.99m;
                        Console.WriteLine("Bought {0}", command);
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                        continue;
                    }
                }
                else if (command == "RoverWatch")
                {
                    if (budget - 29.99m >= 0)
                    {
                        budget -= 29.99m;
                        Console.WriteLine("Bought {0}", command);
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                        continue;
                    }
                }
                else if (command == "RoverWatch Origins Edition")
                {
                    if (budget - 39.99m >= 0)
                    {
                        budget -= 39.99m;
                        Console.WriteLine("Bought {0}", command);
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Not Found");
                    continue;
                }
            }

            if (budget <= 0)
            {
                Console.WriteLine("Out of money!");
                return;
            }

            Console.WriteLine("Total spent: ${0}. Remaining: ${1}", copyOfBudget - budget, budget);
        }
    }
}
