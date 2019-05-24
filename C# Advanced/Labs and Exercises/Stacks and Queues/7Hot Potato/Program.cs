using System;
using System.Collections.Generic;

namespace _7Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] kids = Console.ReadLine().Split();

            int num = int.Parse(Console.ReadLine());

            Queue<string> players = new Queue<string>(kids);

            int counter = 0;

            while (players.Count>1)
            {
                string currPlayer = players.Dequeue();
                counter++;

                if (counter != num)
                {
                    players.Enqueue(currPlayer);
                }
                else
                {
                    Console.WriteLine($"Removed {currPlayer}");
                    counter = 0;
                }
            }

            Console.WriteLine($"Last is {players.Peek()}");
        }
    }
}
