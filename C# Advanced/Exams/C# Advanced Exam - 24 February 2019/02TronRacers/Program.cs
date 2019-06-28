using System;
using System.Linq;
using System.Collections.Generic;

namespace _02TronRacers
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            int firstPlayerRow = -1;
            int firstPlayerCol = -1;
            int secondPlayerRow = -1;
            int secondPlayerCol = -1;

            for (int row = 0; row < n; row++)
            {
                char[] currRow = Console.ReadLine().ToCharArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currRow[col];

                    if (matrix[row, col] == 'f')
                    {
                        firstPlayerRow = row;
                        firstPlayerCol = col;
                    }
                    else if (matrix[row, col] == 's')
                    {
                        secondPlayerRow = row;
                        secondPlayerCol = col;
                    }
                }
            }

            while (true)
            {
                string[] commands = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string playerOneMove = commands[0];
                string playerTwoMove = commands[1];

                if (playerOneMove == "up")
                {
                    if (firstPlayerRow - 1 >= 0)
                    {
                        firstPlayerRow -= 1;

                        if (matrix[firstPlayerRow, firstPlayerCol] == 's')
                        {
                            matrix[firstPlayerRow, firstPlayerCol] = 'x';
                            break;
                        }
                        else
                        {
                            matrix[firstPlayerRow, firstPlayerCol] = 'f';
                        }
                    }
                    else
                    {
                        firstPlayerRow = n - 1;

                        if (matrix[firstPlayerRow, firstPlayerCol] == 's')
                        {
                            matrix[firstPlayerRow, firstPlayerCol] = 'x';
                            break;
                        }
                        else
                        {
                            matrix[firstPlayerRow, firstPlayerCol] = 'f';
                        }
                    }
                }
                else if (playerOneMove == "down")
                {
                    if (firstPlayerRow + 1 < n)
                    {
                        firstPlayerRow += 1;

                        if (matrix[firstPlayerRow, firstPlayerCol] == 's')
                        {
                            matrix[firstPlayerRow, firstPlayerCol] = 'x';
                            break;
                        }
                        else
                        {
                            matrix[firstPlayerRow, firstPlayerCol] = 'f';
                        }
                    }
                    else
                    {
                        firstPlayerRow = 0;

                        if (matrix[firstPlayerRow, firstPlayerCol] == 's')
                        {
                            matrix[firstPlayerRow, firstPlayerCol] = 'x';
                            break;
                        }
                        else
                        {
                            matrix[firstPlayerRow, firstPlayerCol] = 'f';
                        }
                    }
                }
                else if (playerOneMove == "left")
                {
                    if (firstPlayerCol - 1 >= 0)
                    {
                        firstPlayerCol -= 1;

                        if (matrix[firstPlayerRow, firstPlayerCol] == 's')
                        {
                            matrix[firstPlayerRow, firstPlayerCol] = 'x';
                            break;
                        }
                        else
                        {
                            matrix[firstPlayerRow, firstPlayerCol] = 'f';
                        }
                    }
                    else
                    {
                        firstPlayerCol = n - 1;

                        if (matrix[firstPlayerRow, firstPlayerCol] == 's')
                        {
                            matrix[firstPlayerRow, firstPlayerCol] = 'x';
                            break;
                        }
                        else
                        {
                            matrix[firstPlayerRow, firstPlayerCol] = 'f';
                        }
                    }
                }
                else if (playerOneMove == "right")
                {
                    if (firstPlayerCol + 1 < n)
                    {
                        firstPlayerCol += 1;

                        if (matrix[firstPlayerRow, firstPlayerCol] == 's')
                        {
                            matrix[firstPlayerRow, firstPlayerCol] = 'x';
                            break;
                        }
                        else
                        {
                            matrix[firstPlayerRow, firstPlayerCol] = 'f';
                        }
                    }
                    else
                    {
                        firstPlayerCol = 0;

                        if (matrix[firstPlayerRow, firstPlayerCol] == 's')
                        {
                            matrix[firstPlayerRow, firstPlayerCol] = 'x';
                            break;
                        }
                        else
                        {
                            matrix[firstPlayerRow, firstPlayerCol] = 'f';
                        }
                    }
                }
                if (playerTwoMove == "up")
                {
                    if (secondPlayerRow - 1 >= 0)
                    {
                        secondPlayerRow -= 1;

                        if (matrix[secondPlayerRow, secondPlayerCol] == 'f')
                        {
                            matrix[secondPlayerRow, secondPlayerCol] = 'x';
                            break;
                        }
                        else
                        {
                            matrix[secondPlayerRow, secondPlayerCol] = 's';
                        }
                    }
                    else
                    {
                        secondPlayerRow = n - 1;

                        if (matrix[secondPlayerRow, secondPlayerCol] == 'f')
                        {
                            matrix[secondPlayerRow, secondPlayerCol] = 'x';
                            break;
                        }
                        else
                        {
                            matrix[secondPlayerRow, secondPlayerCol] = 's';
                        }
                    }
                }
                else if (playerTwoMove == "down")
                {
                    if (secondPlayerRow + 1 < n)
                    {
                        secondPlayerRow += 1;

                        if (matrix[secondPlayerRow, secondPlayerCol] == 'f')
                        {
                            matrix[secondPlayerRow, secondPlayerCol] = 'x';
                            break;
                        }
                        else
                        {
                            matrix[secondPlayerRow, secondPlayerCol] = 's';
                        }
                    }
                    else
                    {
                        secondPlayerRow = 0;

                        if (matrix[secondPlayerRow, secondPlayerCol] == 'f')
                        {
                            matrix[secondPlayerRow, secondPlayerCol] = 'x';
                            break;
                        }
                        else
                        {
                            matrix[secondPlayerRow, secondPlayerCol] = 's';
                        }
                    }
                }
                else if (playerTwoMove == "right")
                {
                    if (secondPlayerCol + 1 < n)
                    {
                        secondPlayerCol += 1;

                        if (matrix[secondPlayerRow, secondPlayerCol] == 'f')
                        {
                            matrix[secondPlayerRow, secondPlayerCol] = 'x';
                            break;
                        }
                        else
                        {
                            matrix[secondPlayerRow, secondPlayerCol] = 's';
                        }
                    }
                    else
                    {
                        secondPlayerCol = 0;

                        if (matrix[secondPlayerRow, secondPlayerCol] == 'f')
                        {
                            matrix[secondPlayerRow, secondPlayerCol] = 'x';
                            break;
                        }
                        else
                        {
                            matrix[secondPlayerRow, secondPlayerCol] = 's';
                        }
                    }
                }
                else if (playerTwoMove == "left")
                {
                    if (secondPlayerCol - 1 >= 0)
                    {
                        secondPlayerCol -= 1;

                        if (matrix[secondPlayerRow, secondPlayerCol] == 'f')
                        {
                            matrix[secondPlayerRow, secondPlayerCol] = 'x';
                            break;
                        }
                        else
                        {
                            matrix[secondPlayerRow, secondPlayerCol] = 's';
                        }
                    }
                    else
                    {
                        secondPlayerCol = n - 1;

                        if (matrix[secondPlayerRow, secondPlayerCol] == 'f')
                        {
                            matrix[secondPlayerRow, secondPlayerCol] = 'x';
                            break;
                        }
                        else
                        {
                            matrix[secondPlayerRow, secondPlayerCol] = 's';
                        }
                    }
                }
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
