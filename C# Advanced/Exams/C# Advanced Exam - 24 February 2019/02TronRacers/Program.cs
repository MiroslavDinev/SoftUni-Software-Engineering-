using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

public class Program
{
    public static void Main()
    {
        int rows = int.Parse(Console.ReadLine());

        char[][] jagged = new char[rows][];

        int firstRow = -1;
        int firstCol = -1;
        int secondRow = -1;
        int secondCol = -1;

        for (int row = 0; row < rows; row++)
        {
            char[] currRow = Console.ReadLine().ToCharArray();

            jagged[row] = new char[currRow.Length];

            for (int col = 0; col < jagged[row].Length; col++)
            {
                jagged[row][col] = currRow[col];

                if (jagged[row][col] == 'f')
                {
                    firstRow = row;
                    firstCol = col;
                }
                else if (jagged[row][col] == 's')
                {
                    secondRow = row;
                    secondCol = col;
                }
            }
        }

        while (true)
        {
            string[] tokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string firstMove = tokens[0];
            string secondMove = tokens[1];

            if (firstMove == "up")
            {
                if (firstRow - 1 >= 0)
                {
                    firstRow -= 1;
                }
                else
                {
                    firstRow = rows - 1;
                }

                if (KillPlayerOne(jagged, firstRow, firstCol))
                {
                    PrintField(jagged);
                    return;
                }
                else
                {
                    jagged[firstRow][firstCol] = 'f';
                }
            }
            else if (firstMove == "down")
            {
                if (firstRow + 1 < rows)
                {
                    firstRow += 1;
                }
                else
                {
                    firstRow = 0;
                }

                if (KillPlayerOne(jagged, firstRow, firstCol))
                {
                    PrintField(jagged);
                    return;
                }
                else
                {
                    jagged[firstRow][firstCol] = 'f';
                }
            }
            else if (firstMove == "left")
            {
                if (firstCol - 1 >= 0)
                {
                    firstCol -= 1;
                }
                else
                {
                    firstCol = jagged[firstRow].Length - 1;
                }

                if (KillPlayerOne(jagged, firstRow, firstCol))
                {
                    PrintField(jagged);
                    return;
                }
                else
                {
                    jagged[firstRow][firstCol] = 'f';
                }
            }
            else if (firstMove == "right")
            {
                if (firstCol + 1 < jagged[firstRow].Length)
                {
                    firstCol += 1;
                }
                else
                {
                    firstCol = 0;
                }

                if (KillPlayerOne(jagged, firstRow, firstCol))
                {
                    PrintField(jagged);
                    return;
                }
                else
                {
                    jagged[firstRow][firstCol] = 'f';
                }
            }

            if (secondMove == "up")
            {
                if (secondRow - 1 >= 0)
                {
                    secondRow -= 1;
                }
                else
                {
                    secondRow = rows - 1;
                }

                if (KillPlayerTwo(jagged, secondRow, secondCol))
                {
                    PrintField(jagged);
                    return;
                }
                else
                {
                    jagged[secondRow][secondCol] = 's';
                }
            }
            else if (secondMove == "down")
            {
                if (secondRow + 1 < rows)
                {
                    secondRow += 1;
                }
                else
                {
                    secondRow = 0;
                }

                if (KillPlayerTwo(jagged, secondRow, secondCol))
                {
                    PrintField(jagged);
                    return;
                }
                else
                {
                    jagged[secondRow][secondCol] = 's';
                }
            }
            else if (secondMove == "left")
            {
                if (secondCol - 1 >= 0)
                {
                    secondCol -= 1;
                }
                else
                {
                    secondCol = jagged[secondRow].Length - 1;
                }

                if (KillPlayerTwo(jagged, secondRow, secondCol))
                {
                    PrintField(jagged);
                    return;
                }
                else
                {
                    jagged[secondRow][secondCol] = 's';
                }
            }
            else if (secondMove == "right")
            {
                if (secondCol + 1 < jagged[secondRow].Length)
                {
                    secondCol += 1;
                }
                else
                {
                    secondCol = 0;
                }

                if (KillPlayerTwo(jagged, secondRow, secondCol))
                {
                    PrintField(jagged);
                    return;
                }
                else
                {
                    jagged[secondRow][secondCol] = 's';
                }
            }
        }
    }

    public static void PrintField(char[][] jagged)
    {
        foreach (var row in jagged)
        {
            Console.WriteLine(string.Join("", row));
        }
    }

    public static bool KillPlayerOne(char[][] jagged, int firstRow, int firstCol)
    {
        if (jagged[firstRow][firstCol] == 's')
        {
            jagged[firstRow][firstCol] = 'x';
            return true;
        }
        return false;
    }

    public static bool KillPlayerTwo(char[][] jagged, int secondRow, int secondCol)
    {
        if (jagged[secondRow][secondCol] == 'f')
        {
            jagged[secondRow][secondCol] = 'x';
            return true;
        }
        return false;
    }
}
