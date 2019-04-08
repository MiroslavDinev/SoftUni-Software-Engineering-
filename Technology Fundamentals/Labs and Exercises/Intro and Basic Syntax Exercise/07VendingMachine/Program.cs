using System;

namespace _07VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal sum = 0;

            while (true)
            {
                string money = Console.ReadLine();

                if (money == "Start")
                {
                    break;
                }
                decimal coins = decimal.Parse(money);

                if (coins == 0.1m || coins == 0.2m || coins == 0.5m || coins == 1.0m || coins == 2.0m)
                {
                    sum += coins;
                }
                else
                {
                    Console.WriteLine("Cannot accept {0}", coins);
                }
            }

            while (true)
            {
                string product = Console.ReadLine().ToLower();

                if (product == "end")
                {
                    break;
                }

                if (product == "nuts")
                {
                    if (sum < 2.0m)
                    {
                        Console.WriteLine("Sorry, not enough money");

                    }
                    else
                    {
                        sum -= 2.0m;
                        Console.WriteLine("Purchased {0}", product);
                    }
                }
                else if (product == "water")
                {
                    if (sum < 0.7m)
                    {
                        Console.WriteLine("Sorry, not enough money");

                    }
                    else
                    {
                        sum -= 0.7m;
                        Console.WriteLine("Purchased {0}", product);
                    }
                }
                else if (product == "crisps")
                {
                    if (sum < 1.5m)
                    {
                        Console.WriteLine("Sorry, not enough money");

                    }
                    else
                    {
                        sum -= 1.5m;
                        Console.WriteLine("Purchased {0}", product);
                    }
                }
                else if (product == "soda")
                {
                    if (sum < 0.8m)
                    {
                        Console.WriteLine("Sorry, not enough money");

                    }
                    else
                    {
                        sum -= 0.8m;
                        Console.WriteLine("Purchased {0}", product);
                    }
                }
                else if (product == "coke")
                {
                    if (sum < 1.0m)
                    {
                        Console.WriteLine("Sorry, not enough money");

                    }
                    else
                    {
                        sum -= 1.0m;
                        Console.WriteLine("Purchased {0}", product);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid product");
                }
            }
            Console.WriteLine("Change: {0:f2}", sum);
        }
    }
}
