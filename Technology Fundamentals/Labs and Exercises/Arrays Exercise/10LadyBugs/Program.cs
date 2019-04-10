using System;
using System.Linq;

namespace _10LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            int[] initalPositions = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] field = new int[fieldSize];

            for (int i = 0; i < initalPositions.Length; i++)
            {
                int occupiedIndex = initalPositions[i];

                if (occupiedIndex >=0 && occupiedIndex<fieldSize)
                {
                    field[occupiedIndex] = 1;
                }
            }

            

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }

                string[] movement = command.Split();

                int ladyBugIndex =int.Parse(movement[0]);

                bool isFirst = true;

                while (ladyBugIndex >=0 && ladyBugIndex < fieldSize && field [ladyBugIndex]!=0)
                {
                    if (isFirst)
                    {
                        field[ladyBugIndex] = 0;
                        isFirst = false;
                    }

                    string direction = movement[1];
                    int distance = int.Parse(movement[2]);

                    if (direction == "left")
                    {
                        ladyBugIndex -= distance;

                        if (ladyBugIndex >=0 && ladyBugIndex < fieldSize)
                        {
                            if (field [ladyBugIndex]==0)
                            {
                                field[ladyBugIndex] = 1;
                                break;
                            }
                        }
                    }
                    else
                    {
                        ladyBugIndex += distance;

                        if (ladyBugIndex >= 0 && ladyBugIndex < fieldSize)
                        {
                            if (field[ladyBugIndex] == 0)
                            {
                                field[ladyBugIndex] = 1;
                                break;
                            }
                        }
                    }
                }
            }
            Console.WriteLine(string.Join(" ",field));
        }
    }
}
