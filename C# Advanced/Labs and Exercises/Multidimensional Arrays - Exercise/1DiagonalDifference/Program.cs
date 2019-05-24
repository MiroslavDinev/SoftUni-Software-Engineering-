using System;
using System.Linq;

namespace _1DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for (int row = 0; row < n; row++)
            {
                int[] currRow = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row,col] = currRow[col];
                }
            }

            int firstSum = 0;
            int secondSum = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (row == col)
                    {
                        firstSum += matrix[row, col];
                    }
                }
            }

            for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
            {
                for (int col = 0; col < n; col++)
                {
                    if (row+col==matrix.GetLength(0)-1)
                    {
                        secondSum += matrix[row, col];
                    }
                }
            }

            int result = Math.Abs(firstSum - secondSum);
            Console.WriteLine(result);
        }
    }
}
