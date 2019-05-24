using System;
using System.Linq;

namespace _8Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for (int row = 0; row < n; row++)
            {
                int[] currRow = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currRow[col];
                }
            }

            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < input.Length; i++)
            {
                string currData = input[i];
                string[] tokens = currData.Split(',');
                int bombRow = int.Parse(tokens[0]);
                int bombCol = int.Parse(tokens[1]);

                int bombValue = matrix[bombRow, bombCol];

                if (bombValue>0)
                {
                    if (bombCol - 1 >= 0 && bombCol - 1 < n)
                    {
                        if (matrix[bombRow, bombCol - 1] > 0)
                        {
                            matrix[bombRow, bombCol - 1] -= bombValue;
                        }
                    }
                    if (bombCol + 1 >= 0 && bombCol + 1 < n)
                    {
                        if (matrix[bombRow, bombCol + 1] > 0)
                        {
                            matrix[bombRow, bombCol + 1] -= bombValue;
                        }
                    }
                    if (bombRow - 1 >= 0 && bombRow - 1 < n)
                    {
                        if (matrix[bombRow - 1, bombCol] > 0)
                        {
                            matrix[bombRow - 1, bombCol] -= bombValue;
                        }
                    }
                    if (bombRow + 1 >= 0 && bombRow + 1 < n)
                    {
                        if (matrix[bombRow + 1, bombCol] > 0)
                        {
                            matrix[bombRow + 1, bombCol] -= bombValue;
                        }
                    }
                    if (bombRow - 1 >= 0 && bombRow - 1 < n && bombCol - 1 >= 0 && bombCol - 1 < n)
                    {
                        if (matrix[bombRow - 1, bombCol - 1] > 0)
                        {
                            matrix[bombRow - 1, bombCol - 1] -= bombValue;
                        }
                    }
                    if (bombRow - 1 >= 0 && bombRow - 1 < n && bombCol + 1 >= 0 && bombCol + 1 < n)
                    {
                        if (matrix[bombRow - 1, bombCol + 1] > 0)
                        {
                            matrix[bombRow - 1, bombCol + 1] -= bombValue;
                        }
                    }
                    if (bombRow + 1 >= 0 && bombRow + 1 < n && bombCol - 1 >= 0 && bombCol - 1 < n)
                    {
                        if (matrix[bombRow + 1, bombCol - 1] > 0)
                        {
                            matrix[bombRow + 1, bombCol - 1] -= bombValue;
                        }
                    }
                    if (bombRow + 1 >= 0 && bombRow + 1 < n && bombCol + 1 >= 0 && bombCol + 1 < n)
                    {
                        if (matrix[bombRow + 1, bombCol + 1] > 0)
                        {
                            matrix[bombRow + 1, bombCol + 1] -= bombValue;
                        }
                    }
                    matrix[bombRow, bombCol] = 0;
                }
                else
                {
                    continue;
                }
            }

            int aliveCells = 0;
            int sum = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row,col]>0)
                    {
                        aliveCells++;
                        sum += matrix[row, col];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sum}");

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row,col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
