using System;
using System.Linq;
using System.Collections.Generic;

namespace _01TrojanInvasion
{
    class Program
    {
        static void Main(string[] args)
        {
            int numWaves = int.Parse(Console.ReadLine());

            int[] platesInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

            List<int> plates = new List<int>(platesInput);
            Stack<int> warriors = new Stack<int>();

            for (int currWave = 1; currWave <= numWaves; currWave++)
            {
                if (plates.Count == 0)
                {
                    break;
                }

                int[] warriorsInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

                foreach (var warrior in warriorsInput)
                {
                    warriors.Push(warrior);
                }

                if (currWave % 3 == 0)
                {
                    int toAdd = int.Parse(Console.ReadLine());
                    plates.Add(toAdd);
                }

                while (warriors.Any() && plates.Any())
                {
                    int currWarrior = warriors.Peek();
                    int currPlate = plates[0];

                    if (currWarrior == currPlate)
                    {
                        warriors.Pop();
                        plates.Remove(currPlate);
                    }
                    else if (currWarrior < currPlate)
                    {
                        currPlate -= currWarrior;
                        warriors.Pop();
                        plates.RemoveAt(0);
                        plates.Insert(0, currPlate);
                    }
                    else if (currWarrior > currPlate)
                    {
                        currWarrior -= currPlate;
                        plates.RemoveAt(0);
                        warriors.Pop();
                        warriors.Push(currWarrior);
                    }
                }
            }

            if (plates.Any())
            {
                Console.WriteLine("The Spartans successfully repulsed the Trojan attack.");
                Console.WriteLine("Plates left: {0}", string.Join(", ", plates));
            }
            else
            {
                Console.WriteLine("The Trojans successfully destroyed the Spartan defense.");
                Console.WriteLine("Warriors left: {0}", string.Join(", ", warriors));
            }
        }
    }
}
