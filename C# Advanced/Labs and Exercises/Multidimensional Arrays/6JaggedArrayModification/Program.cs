using System;
using System.Linq;

namespace _6JaggedArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] jagged = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                int[] currRow = Console.ReadLine().Split().Select(int.Parse).ToArray();

                jagged[row] = currRow;
            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "END")
                {
                    break;
                }

                string[] tokens = command.Split();
                string action = tokens[0];

                if (action == "Add")
                {
                    int row = int.Parse(tokens[1]);
                    int col = int.Parse(tokens[2]);
                    int num = int.Parse(tokens[3]);

                    if (row>=0 && row<jagged.Length && col>=0 && col<jagged[row].Length)
                    {
                        jagged[row][col] += num;
                    }
                    else
                    {
                        Console.WriteLine("Invalid coordinates");
                        continue;
                    }
                }
                else
                {
                    int row = int.Parse(tokens[1]);
                    int col = int.Parse(tokens[2]);
                    int num = int.Parse(tokens[3]);

                    if (row >= 0 && row < jagged.Length && col >= 0 && col < jagged[row].Length)
                    {
                        jagged[row][col] -= num;
                    }
                    else
                    {
                        Console.WriteLine("Invalid coordinates");
                        continue;
                    }
                }
            }

            foreach (var row in jagged)
            {
                Console.WriteLine(string.Join(" ",row));
            }
        }
    }
}
