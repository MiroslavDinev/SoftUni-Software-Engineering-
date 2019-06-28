using System;
using System.Linq;
using System.Collections.Generic;

namespace _02Sneaking
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            char[][] jagged = new char[rows][];

            int samRow = -1;
            int samCol = -1;
            int nikoRow = -1;
            int nikoCol = -1;

            for (int row = 0; row < rows; row++)
            {
                string currRow = Console.ReadLine();
                jagged[row] = new char[currRow.Length];

                for (int col = 0; col < jagged[row].Length; col++)
                {
                    jagged[row][col] = currRow[col];

                    if (jagged[row][col] == 'S')
                    {
                        samRow = row;
                        samCol = col;
                    }
                    else if (jagged[row][col] == 'N')
                    {
                        nikoRow = row;
                        nikoCol = col;
                    }
                }
            }

            jagged[samRow][samCol] = '.';

            char[] commands = Console.ReadLine().ToCharArray();

            foreach (var command in commands)
            {
                EnemiesMoves(jagged);

                if (KillSam(jagged, samRow, samCol))
                {
                    jagged[samRow][samCol] = 'X';
                    Console.WriteLine("Sam died at {0}, {1}", samRow, samCol);
                    PrintMatrix(jagged);
                    return;
                }

                switch (command)
                {
                    case 'U': samRow--; break;
                    case 'D': samRow++; break;
                    case 'L': samCol--; break;
                    case 'R': samCol++; break;
                }

                if (samRow == nikoRow)
                {
                    jagged[nikoRow][nikoCol] = 'X';
                    jagged[samRow][samCol] = 'S';
                    Console.WriteLine("Nikoladze killed!");
                    PrintMatrix(jagged);
                    return;
                }
                else if (jagged[samRow][samCol] == 'b' || jagged[samRow][samCol] == 'd')
                {
                    jagged[samRow][samCol] = '.';
                }
            }
        }
        public static void PrintMatrix(char[][] jagged)
        {
            foreach (var row in jagged)
            {
                Console.WriteLine(row);
            }
        }

        public static bool KillSam(char[][] jagged, int samRow, int samCol)
        {
            if (jagged[samRow].Contains('b'))
            {
                int colIndex = Array.IndexOf(jagged[samRow], 'b');

                if (samCol > colIndex)
                {
                    return true;
                }
            }
            else if (jagged[samRow].Contains('d'))
            {
                int colIndex = Array.IndexOf(jagged[samRow], 'd');

                if (samCol < colIndex)
                {
                    return true;
                }
            }
            return false;
        }

        public static void EnemiesMoves(char[][] jagged)
        {
            for (int row = 0; row < jagged.Length; row++)
            {
                for (int col = 0; col < jagged[row].Length; col++)
                {
                    if (jagged[row][col] == 'b')
                    {
                        jagged[row][col] = '.';

                        if (col == jagged[row].Length - 1)
                        {
                            jagged[row][col] = 'd';
                        }
                        else
                        {
                            jagged[row][col + 1] = 'b';
                            break;
                        }
                    }
                    else if (jagged[row][col] == 'd')
                    {
                        jagged[row][col] = '.';

                        if (col == 0)
                        {
                            jagged[row][col] = 'b';
                        }
                        else
                        {
                            jagged[row][col - 1] = 'd';
                        }
                    }
                }
            }
        }
    }
}
