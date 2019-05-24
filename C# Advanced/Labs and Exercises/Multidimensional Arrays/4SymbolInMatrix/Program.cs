using System;
using System.Linq;

namespace _4SymbolInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                char[] currRow = Console.ReadLine().ToCharArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currRow[col];
                }
            }

            char symbol = char.Parse(Console.ReadLine());

            int rowToPrint = -1;
            int colToPrint = -1;

            bool isBroken = false;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row,col]==symbol)
                    {
                        rowToPrint = row;
                        colToPrint = col;
                        isBroken = true;
                        break;
                    }
                }

                if (isBroken)
                {
                    break;
                }
            }

            if (isBroken)
            {
                Console.WriteLine($"({rowToPrint}, {colToPrint})");
            }
            else
            {
                Console.WriteLine($"{symbol} does not occur in the matrix");
            }
        }
    }
}
