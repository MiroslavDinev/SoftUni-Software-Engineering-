using System;
using System.Linq;

namespace _7KnightGame
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

            int removeCounter = 0;

            int maxHit = 0;
            int knightRow = -1;
            int knightCol = -1;

            while (true)
            {
                int currHit = 0;

                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        if (matrix[row,col]=='K')
                        {
                            if (row-2>=0 && row-2<n && col+1>=0 && col+1<n)
                            {
                                if (matrix[row-2,col+1]=='K')
                                {
                                    currHit++;
                                }
                            }
                            if (row - 2 >= 0 && row - 2 < n && col - 1 >= 0 && col - 1 < n)
                            {
                                if (matrix[row - 2, col - 1] == 'K')
                                {
                                    currHit++;
                                }
                            }
                            if (row + 2 >= 0 && row + 2 < n && col + 1 >= 0 && col + 1 < n)
                            {
                                if (matrix[row + 2, col + 1] == 'K')
                                {
                                    currHit++;
                                }
                            }
                            if (row + 2 >= 0 && row + 2 < n && col - 1 >= 0 && col - 1 < n)
                            {
                                if (matrix[row + 2, col - 1] == 'K')
                                {
                                    currHit++;
                                }
                            }
                            if (col+2>=0 && col+2<n && row-1>=0 && row-1<n)
                            {
                                if(matrix[row-1,col+2]=='K')
                                {
                                    currHit++;
                                }
                            }
                            if (col + 2 >= 0 && col + 2 < n && row + 1 >= 0 && row + 1 < n)
                            {
                                if (matrix[row + 1, col + 2] == 'K')
                                {
                                    currHit++;
                                }
                            }
                            if (col - 2 >= 0 && col - 2 < n && row - 1 >= 0 && row - 1 < n)
                            {
                                if (matrix[row - 1, col - 2] == 'K')
                                {
                                    currHit++;
                                }
                            }
                            if (col - 2 >= 0 && col - 2 < n && row + 1 >= 0 && row + 1 < n)
                            {
                                if (matrix[row + 1, col - 2] == 'K')
                                {
                                    currHit++;
                                }
                            }
                        }
                        if (currHit > maxHit)
                        {
                            maxHit = currHit;
                            knightRow = row;
                            knightCol = col;
                        }
                        currHit = 0;
                    }
                }
                if (maxHit!=0)
                {
                    removeCounter++;
                    matrix[knightRow, knightCol] = 'O';
                    maxHit = 0;
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(removeCounter);
        }
    }
}
