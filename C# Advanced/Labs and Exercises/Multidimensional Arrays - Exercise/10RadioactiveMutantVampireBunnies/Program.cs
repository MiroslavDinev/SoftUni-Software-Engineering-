using System;
using System.Linq;
using System.Collections.Generic;

namespace _10RadioactiveMutantVampireBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            char[][] bunnyLair = new char[rows][];

            int playerRow = 0;
            int playerCol = 0;

            for (int row = 0; row < rows; row++)
            {
                bunnyLair[row] = Console.ReadLine().ToCharArray();

                if (bunnyLair[row].Contains('P'))
                {
                    playerRow = row;
                    playerCol = Array.IndexOf(bunnyLair[row], 'P');
                    bunnyLair[playerRow][playerCol] = '.';
                }
            }
            string directions = Console.ReadLine();

            foreach (char move in directions)
            {
                int oldPlayerRow = playerRow;
                int oldPlayerCol = playerCol;

                switch (move)
                {
                    case 'U': playerRow--; break;
                    case 'D': playerRow++; break;
                    case 'L': playerCol--; break;
                    case 'R': playerCol++; break;
                }

                bunnyLair = SpreadBunnies(bunnyLair, rows - 1, cols - 1);

                if (playerRow < 0 || playerRow >= rows || playerCol < 0 || playerCol >= cols)
                {
                    PrintResult(bunnyLair, oldPlayerRow, oldPlayerCol, "won");
                    return;
                }

                if (bunnyLair[playerRow][playerCol] == 'B')
                {
                    PrintResult(bunnyLair, playerRow, playerCol, "dead");
                    return;
                }
            }
        }

        public static char[][] SpreadBunnies(char[][] matrix, int rows, int cols)
        {
            var newLair = new char[matrix.Length][];

            for (int i = 0; i < matrix.Length; i++)
            {
                newLair[i] = (char[])matrix[i].Clone();
            }

            for (int row = 0; row <= rows; row++)
            {
                for (int col = 0; col <= cols; col++)
                {
                    if (matrix[row][col] == 'B')
                    {
                        if (row > 0) newLair[row - 1][col] = 'B';
                        if (row < rows) newLair[row + 1][col] = 'B';
                        if (col > 0) newLair[row][col - 1] = 'B';
                        if (col < cols) newLair[row][col + 1] = 'B';
                    }
                }
            }

            return newLair;
        }

        public static void PrintResult(char[][] bunnyLair, int row, int col, string outcome)
        {
            foreach (var bunnyRow in bunnyLair)
            {
                Console.WriteLine(string.Join("", bunnyRow));
            }
            Console.WriteLine("{0}: {1} {2}", outcome, row, col);
        }
    }
}
