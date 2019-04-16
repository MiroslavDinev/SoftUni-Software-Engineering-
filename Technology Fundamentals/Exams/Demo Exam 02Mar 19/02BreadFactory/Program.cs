using System;
using System.Linq;
using System.Collections.Generic;

namespace _02BreadFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int energy = 100;
            int coins = 100;

            while (energy>=0)
            {
                string[] tokens = Console.ReadLine().Split("|");

                foreach (string @event in tokens)
                {
                    string[] currEvent = @event.Split("-");

                    string action = currEvent[0];
                    
                    if (action == "rest")
                    {
                        int energyToGain = int.Parse(currEvent[1]);

                        if (energy==100)
                        {
                            Console.WriteLine("You gained 0 energy.");
                            Console.WriteLine("Current energy: 100.");
                            continue;
                        }
                        else if (energy + energyToGain ==100)
                        {
                            energy += energyToGain;
                            Console.WriteLine($"You gained {energyToGain} energy.");
                            Console.WriteLine("Current energy: 100.");
                            continue;
                        }
                        else if (energy + energyToGain>100)
                        {
                            int gainedEnergy = 100-energy;
                            Console.WriteLine($"You gained {gainedEnergy} energy.");
                            Console.WriteLine("Current energy: 100.");
                            energy = 100;
                            continue;
                        }
                        else if (energy + energyToGain<100)
                        {
                            energy += energyToGain;
                            Console.WriteLine($"You gained {energyToGain} energy.");
                            Console.WriteLine($"Current energy: {energy}.");
                            continue;
                        }
                    }
                    else if (action == "order")
                    {
                        int coinsToEarn = int.Parse(currEvent[1]);

                        if (energy - 30>=0)
                        {
                            energy -= 30;
                            coins += coinsToEarn;
                            Console.WriteLine($"You earned {coinsToEarn} coins.");
                        }
                        else
                        {
                            energy += 50;
                            Console.WriteLine("You had to rest!");
                            continue;
                        }
                    }
                    else
                    {
                        string ingredient = action;
                        int coinsToSpent = int.Parse(currEvent[1]);

                        if (coins-coinsToSpent>0)
                        {
                            coins -= coinsToSpent;
                            Console.WriteLine($"You bought {ingredient}.");
                        }
                        else
                        {
                            Console.WriteLine($"Closed! Cannot afford {ingredient}.");
                            return;
                        }
                    }
                }
                break;
            }
            Console.WriteLine("Day completed!");
            Console.WriteLine($"Coins: {coins}");
            Console.WriteLine($"Energy: {energy}");
        }
    }
}
