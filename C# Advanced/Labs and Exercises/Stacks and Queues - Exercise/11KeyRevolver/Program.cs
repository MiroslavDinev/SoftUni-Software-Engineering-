using System;
using System.Linq;
using System.Collections.Generic;

namespace _11KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int barrelSize = int.Parse(Console.ReadLine());
            int[] bulletsInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] locksInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int money = int.Parse(Console.ReadLine());

            int initialBulletsCount = bulletsInput.Length;

            Stack<int> bulletsValues = new Stack<int>(bulletsInput);
            Queue<int> locksValues = new Queue<int>(locksInput);

            int shots = 0;

            while (bulletsValues.Count>0 && locksValues.Count>0)
            {
                if (bulletsValues.Peek()<= locksValues.Peek())
                {
                    Console.WriteLine("Bang!");
                    bulletsValues.Pop();
                    locksValues.Dequeue();
                    shots++;

                    if (shots == barrelSize && bulletsValues.Count>0)
                    {
                        shots = 0;
                        Console.WriteLine("Reloading!");
                    }
                }
                else
                {
                    Console.WriteLine("Ping!");
                    bulletsValues.Pop();
                    shots++;

                    if (shots == barrelSize && bulletsValues.Count > 0)
                    {
                        shots = 0;
                        Console.WriteLine("Reloading!");
                    }
                }
            }

            if (locksValues.Count>0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locksValues.Count}");
            }
            else
            {
                int moneyLeft = money - (initialBulletsCount - bulletsValues.Count) * bulletPrice;
                Console.WriteLine($"{bulletsValues.Count} bullets left. Earned ${moneyLeft}");
            }
        }
    }
}
