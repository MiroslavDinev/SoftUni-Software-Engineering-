using System;
using System.Linq;

namespace _9Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[,] matrix = new string[n, n];

            string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int row = 0; row < n; row++)
            {
                string[] currRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currRow[col];
                }
            }

            int allCoals = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row,col]=="c")
                    {
                        allCoals++;
                    }
                }
            }

            int minerRow = -1;
            int minerCol = -1;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] == "s")
                    {
                        minerRow = row;
                        minerCol = col;
                    }
                }
            }

            matrix[minerRow, minerCol] = "*";

            foreach (var command in commands)
            {
                if (command== "up")
                {
                    if (minerRow-1>=0 && minerRow-1<n)
                    {
                        minerRow = minerRow - 1;

                        if (matrix[minerRow,minerCol]=="e")
                        {
                            Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                            return;
                        }
                        else if (matrix[minerRow, minerCol] == "c")
                        {
                            allCoals--;
                            matrix[minerRow, minerCol] = "*";

                            if (allCoals==0)
                            {
                                Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
                                return;
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                else if (command == "down")
                {
                    if (minerRow + 1 >= 0 && minerRow + 1 < n)
                    {
                        minerRow = minerRow + 1;

                        if (matrix[minerRow, minerCol] == "e")
                        {
                            Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                            return;
                        }
                        else if (matrix[minerRow, minerCol] == "c")
                        {
                            allCoals--;
                            matrix[minerRow, minerCol] = "*";

                            if (allCoals == 0)
                            {
                                Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
                                return;
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                else if (command == "left")
                {
                    if (minerCol-1>=0 && minerCol-1<n)
                    {
                        minerCol = minerCol - 1;

                        if (matrix[minerRow, minerCol] == "e")
                        {
                            Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                            return;
                        }
                        else if (matrix[minerRow, minerCol] == "c")
                        {
                            allCoals--;
                            matrix[minerRow, minerCol] = "*";

                            if (allCoals == 0)
                            {
                                Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
                                return;
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                else if (command == "right")
                {
                    if (minerCol + 1 >= 0 && minerCol + 1 < n)
                    {
                        minerCol = minerCol + 1;

                        if (matrix[minerRow, minerCol] == "e")
                        {
                            Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                            return;
                        }
                        else if (matrix[minerRow, minerCol] == "c")
                        {
                            allCoals--;
                            matrix[minerRow, minerCol] = "*";

                            if (allCoals == 0)
                            {
                                Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
                                return;
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }

            Console.WriteLine($"{allCoals} coals left. ({minerRow}, {minerCol})");
        }
    }
}
