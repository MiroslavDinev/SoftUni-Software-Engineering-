using System;
using System.Linq;

namespace _1SumMatrixElements
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

            int sum = 0;

            foreach (var item in matrix)
            {
                sum += item;
            }

            Console.WriteLine(rows);
            Console.WriteLine(cols);
            Console.WriteLine(sum);
        }
    }
}
