using System;
using System.Linq;
using System.Collections.Generic;

namespace _02DungeonestDark
{
    class Program
    {
        static void Main(string[] args)
        {
            int health = 100;
            int coins = 0;

            List<string> rooms = Console.ReadLine().Split("|").ToList();

            for (int i = 0; i < rooms.Count; i++)
            {
                string currRoom = rooms[i];

                string[] tokens = currRoom.Split();

                string item = tokens[0];

                if (item == "potion")
                {
                    int healthToAdd = int.Parse(tokens[1]);

                    if (health == 100)
                    {
                        Console.WriteLine("You healed for 0 hp.");
                        Console.WriteLine("Current health: 100 hp.");
                        continue;
                    }
                    else if (health + healthToAdd==100)
                    {
                        Console.WriteLine($"You healed for {healthToAdd} hp.");
                        Console.WriteLine("Current health: 100 hp.");
                        health = 100;
                        continue;
                    }
                    else if (health + healthToAdd>100)
                    {
                        int healed = 100 - health;
                        Console.WriteLine($"You healed for {healed} hp.");
                        Console.WriteLine("Current health: 100 hp.");
                        health = 100;
                        continue;
                    }
                    else if (health + healthToAdd < 100)
                    {
                        health += healthToAdd;
                        Console.WriteLine($"You healed for {healthToAdd} hp.");
                        Console.WriteLine($"Current health: {health} hp.");
                        continue;
                    }
                }
                else if (item == "chest")
                {
                    int coinsToAdd = int.Parse(tokens[1]);
                    coins += coinsToAdd;
                    Console.WriteLine($"You found {coinsToAdd} coins.");
                }
                else
                {
                    int attack = int.Parse(tokens[1]);

                    if (health-attack>0)
                    {
                        health -= attack;
                        Console.WriteLine($"You slayed {item}.");
                    }
                    else
                    {
                        Console.WriteLine($"You died! Killed by {item}.");
                        Console.WriteLine($"Best room: {i+1}");
                        return;
                    }
                }
            }

            Console.WriteLine("You've made it!");
            Console.WriteLine($"Coins: {coins}");
            Console.WriteLine($"Health: {health}");
        }
    }
}
