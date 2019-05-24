using System;
using System.Linq;

namespace _2SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] props = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int rows = props[0];
            int cols = props[1];

            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                char[] currRow = Console.ReadLine().Replace(" ","").ToCharArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currRow[col];
                }
            }

            int counter = 0;

            for (int row = 0; row < rows-1; row++)
            {
                for (int col = 0; col < cols-1; col++)
                {
                    if (matrix[row,col] == matrix[row,col+1] && matrix[row, col] == matrix[row+1, col] && matrix[row, col] == matrix[row+1, col + 1])
                    {
                        counter++;
                    }
                }
            }

            Console.WriteLine(counter);
        }
    }
}
