using System;
using System.Linq;

namespace _03SpaceStationEstablishment
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int stephenRow = -1;
            int stephenCol = -1;

            int firstHoleRow = -1;
            int firstHoleCol = -1;

            int secondHoleRow = -1;
            int secondHoleCol = -1;

            char[][] jagged = new char[rows][];

            for (int row = 0; row < rows; row++)
            {
                char[] currRow = Console.ReadLine().ToCharArray();

                jagged[row] = new char[currRow.Length];

                for (int col = 0; col < jagged[row].Length; col++)
                {
                    jagged[row][col] = currRow[col];

                    if(jagged[row][col]=='S')
                    {
                        stephenRow = row;
                        stephenCol = col;
                    }
                    else if (jagged[row][col]=='O')
                    {
                        if(firstHoleCol==-1 && firstHoleRow==-1)
                        {
                            firstHoleRow = row;
                            firstHoleCol = col;
                        }
                        else
                        {
                            secondHoleRow = row;
                            secondHoleCol = col;
                        }
                    }
                }
            }

            int starsCollected = 0;

            jagged[stephenRow][stephenCol] = '-';

            while (true)
            {
                string direction = Console.ReadLine();

                if(direction == "up")
                {
                    if(stephenRow-1>=0)
                    {
                        stephenRow -= 1;

                        if(jagged[stephenRow][stephenCol]!='-')
                        {
                            if(jagged[stephenRow][stephenCol] == 'O')
                            {
                                if(stephenRow==firstHoleRow && stephenCol == firstHoleCol)
                                {
                                    stephenRow = secondHoleRow;
                                    stephenCol = secondHoleCol;

                                    jagged[firstHoleRow][firstHoleCol] = '-';
                                    jagged[secondHoleRow][secondHoleCol] = '-';
                                }
                                else if (stephenRow == secondHoleRow && stephenCol == secondHoleCol)
                                {
                                    stephenRow = firstHoleRow;
                                    stephenCol = firstHoleCol;

                                    jagged[secondHoleRow][secondHoleCol] = '-';
                                    jagged[firstHoleRow][firstHoleCol] = '-';
                                }
                            }
                            else
                            {
                                int currStarPower = int.Parse(jagged[stephenRow][stephenCol].ToString());
                                starsCollected += currStarPower;
                                jagged[stephenRow][stephenCol] = '-';

                                if (starsCollected >= 50)
                                {
                                    Console.WriteLine("Good news! Stephen succeeded in collecting enough star power!");
                                    Console.WriteLine($"Star power collected: {starsCollected}");
                                    jagged[stephenRow][stephenCol] = 'S';
                                    Print(jagged);
                                    return;
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Bad news, the spaceship went to the void.");
                        Console.WriteLine($"Star power collected: {starsCollected}");
                        Print(jagged);
                        return;
                    }
                }
                else if (direction=="down")
                {
                    if (stephenRow + 1 < rows)
                    {
                        stephenRow += 1;

                        if (jagged[stephenRow][stephenCol] != '-')
                        {
                            if (jagged[stephenRow][stephenCol] == 'O')
                            {
                                if (stephenRow == firstHoleRow && stephenCol == firstHoleCol)
                                {
                                    stephenRow = secondHoleRow;
                                    stephenCol = secondHoleCol;

                                    jagged[firstHoleRow][firstHoleCol] = '-';
                                    jagged[secondHoleRow][secondHoleCol] = '-';
                                }
                                else if (stephenRow == secondHoleRow && stephenCol == secondHoleCol)
                                {
                                    stephenRow = firstHoleRow;
                                    stephenCol = firstHoleCol;

                                    jagged[secondHoleRow][secondHoleCol] = '-';
                                    jagged[firstHoleRow][firstHoleCol] = '-';
                                }
                            }
                            else
                            {
                                int currStarPower = int.Parse(jagged[stephenRow][stephenCol].ToString());
                                starsCollected += currStarPower;
                                jagged[stephenRow][stephenCol] = '-';

                                if (starsCollected >= 50)
                                {
                                    Console.WriteLine("Good news! Stephen succeeded in collecting enough star power!");
                                    Console.WriteLine($"Star power collected: {starsCollected}");
                                    jagged[stephenRow][stephenCol] = 'S';
                                    Print(jagged);
                                    return;
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Bad news, the spaceship went to the void.");
                        Console.WriteLine($"Star power collected: {starsCollected}");
                        Print(jagged);
                        return;
                    }
                }
                else if (direction=="left")
                {
                    if (stephenCol - 1 >= 0)
                    {
                        stephenCol -= 1;

                        if (jagged[stephenRow][stephenCol] != '-')
                        {
                            if (jagged[stephenRow][stephenCol] == 'O')
                            {
                                if (stephenRow == firstHoleRow && stephenCol == firstHoleCol)
                                {
                                    stephenRow = secondHoleRow;
                                    stephenCol = secondHoleCol;

                                    jagged[firstHoleRow][firstHoleCol] = '-';
                                    jagged[secondHoleRow][secondHoleCol] = '-';
                                }
                                else if (stephenRow == secondHoleRow && stephenCol == secondHoleCol)
                                {
                                    stephenRow = firstHoleRow;
                                    stephenCol = firstHoleCol;

                                    jagged[secondHoleRow][secondHoleCol] = '-';
                                    jagged[firstHoleRow][firstHoleCol] = '-';
                                }
                            }
                            else
                            {
                                int currStarPower = int.Parse(jagged[stephenRow][stephenCol].ToString());
                                starsCollected += currStarPower;
                                jagged[stephenRow][stephenCol] = '-';

                                if (starsCollected >= 50)
                                {
                                    Console.WriteLine("Good news! Stephen succeeded in collecting enough star power!");
                                    Console.WriteLine($"Star power collected: {starsCollected}");
                                    jagged[stephenRow][stephenCol] = 'S';
                                    Print(jagged);
                                    return;
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Bad news, the spaceship went to the void.");
                        Console.WriteLine($"Star power collected: {starsCollected}");
                        Print(jagged);
                        return;
                    }
                }
                else if (direction == "right")
                {
                    if (stephenCol + 1 < jagged[stephenRow].Length)
                    {
                        stephenCol += 1;

                        if (jagged[stephenRow][stephenCol] != '-')
                        {
                            if (jagged[stephenRow][stephenCol] == 'O')
                            {
                                if (stephenRow == firstHoleRow && stephenCol == firstHoleCol)
                                {
                                    stephenRow = secondHoleRow;
                                    stephenCol = secondHoleCol;

                                    jagged[firstHoleRow][firstHoleCol] = '-';
                                    jagged[secondHoleRow][secondHoleCol] = '-';
                                }
                                else if (stephenRow == secondHoleRow && stephenCol == secondHoleCol)
                                {
                                    stephenRow = firstHoleRow;
                                    stephenCol = firstHoleCol;

                                    jagged[secondHoleRow][secondHoleCol] = '-';
                                    jagged[firstHoleRow][firstHoleCol] = '-';
                                }
                            }
                            else
                            {
                                int currStarPower = int.Parse(jagged[stephenRow][stephenCol].ToString());
                                starsCollected += currStarPower;
                                jagged[stephenRow][stephenCol] = '-';

                                if (starsCollected >= 50)
                                {
                                    Console.WriteLine("Good news! Stephen succeeded in collecting enough star power!");
                                    Console.WriteLine($"Star power collected: {starsCollected}");
                                    jagged[stephenRow][stephenCol] = 'S';
                                    Print(jagged);
                                    return;
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Bad news, the spaceship went to the void.");
                        Console.WriteLine($"Star power collected: {starsCollected}");
                        Print(jagged);
                        return;
                    }
                }
            }

        }

        public static void Print(char[][]jagged)
        {
            foreach (var row in jagged)
            {
                Console.WriteLine(string.Join("",row));
            }
        }
    }
}
