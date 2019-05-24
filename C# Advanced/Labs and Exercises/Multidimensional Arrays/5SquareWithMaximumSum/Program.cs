using System;
using System.Linq;

namespace _5SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] props = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int rows = props[0];
            int cols = props[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] currRow = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currRow[col];
                }
            }

            int startRow = -1;
            int startCol = -1;
            int bestSum = 0;

            for (int row = 0; row < rows; row++)
            {
                int currSum = 0;

                for (int col = 0; col < cols; col++)
                {
                    if (row>=0 && row<matrix.GetLength(0)-1 && col>=0 && col<matrix.GetLength(1)-1)
                    {
                        currSum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];

                        if (currSum>bestSum)
                        {
                            bestSum = currSum;
                            startRow = row;
                            startCol = col;
                        }
                    }
                }
            }

            for (int row = startRow; row < startRow+2; row++)
            {
                for (int col = startCol; col < startCol+2; col++)
                {
                    Console.Write(matrix[row,col] + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine(bestSum);
        }
    }
}
