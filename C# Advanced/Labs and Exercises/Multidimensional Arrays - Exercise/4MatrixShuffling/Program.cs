using System;
using System.Linq;

namespace _4MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] props = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int rows = props[0];
            int cols = props[1];

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] currRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currRow[col];
                }
            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "END")
                {
                    break;
                }

                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length!=5 || tokens[0]!="swap")
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                int row1 = int.Parse(tokens[1]);
                int col1 = int.Parse(tokens[2]);
                int row2 = int.Parse(tokens[3]);
                int col2 = int.Parse(tokens[4]);

                if (row1>=0 && row1<rows && col1>=0 && col1<cols && row2 >= 0 && row2 < rows && col2 >= 0 && col2 < cols)
                {
                    string firstEntry = matrix[row1, col1];
                    string secondEntry = matrix[row2, col2];

                    matrix[row1, col1] = secondEntry;
                    matrix[row2, col2] = firstEntry;
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        Console.Write(matrix[row,col] + " ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
