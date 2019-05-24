using System;
using System.Linq;

namespace _6BombTheBasement
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] props = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int rows = props[0];
            int cols = props[1];

            int[,] matrix = new int[rows, cols];

            int[] bombProps = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int bombRow = bombProps[0];
            int bombCol = bombProps[1];
            int radius = bombProps[2];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (row == bombRow && col == bombCol)
                    {
                        matrix[row, col] = 1;
                    }

                    double distance = Math.Sqrt(Math.Pow(row - bombRow, 2) + Math.Pow(col - bombCol, 2));

                    if (distance<=radius)
                    {
                        matrix[row, col] = 1;
                    }
                }
            }

            for (int col = 0; col < cols; col++)
            {
                int row = matrix.GetLength(0) - 1;

                while (row>0)
                {
                    if (matrix[row,col] == 1)
                    {
                        int nextNumIndex = FindRowIndex(matrix, col, row);
                        matrix[row, col] = matrix[nextNumIndex, col];
                        matrix[nextNumIndex, col] = 1;
                    }
                    row--;
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }
        }

        public static int FindRowIndex(int[,] matrix, int col, int row)
        {
            for (int i = row-1; i >= 0; i--)
            {
                if (matrix[i,col] !=1)
                {
                    return i;
                }
            }

            return 0;
        }
    }
}
