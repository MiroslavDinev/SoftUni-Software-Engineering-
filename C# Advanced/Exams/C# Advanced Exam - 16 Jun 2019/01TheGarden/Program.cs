using System;
public class Program
{
    public static void Main()
    {
        int rows = int.Parse(Console.ReadLine());

        char[][] jagged = new char[rows][];

        for (int row = 0; row < rows; row++)
        {
            string input = Console.ReadLine().Replace(" ", "");
            char[] currRow = input.ToCharArray();

            jagged[row] = new char[currRow.Length];

            for (int col = 0; col < jagged[row].Length; col++)
            {
                jagged[row][col] = currRow[col];
            }
        }

        int carrots = 0;
        int potatos = 0;
        int lettuces = 0;
        int harmed = 0;

        while (true)
        {
            string command = Console.ReadLine();

            if (command == "End of Harvest")
            {
                break;
            }

            string[] tokens = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            if (tokens.Length == 3)
            {
                int harvestRow = int.Parse(tokens[1]);
                int harvestCol = int.Parse(tokens[2]);

                if (harvestRow >= 0 && harvestRow < rows && harvestCol >= 0 && harvestCol < jagged[harvestRow].Length)
                {
                    if (jagged[harvestRow][harvestCol] == 'C')
                    {
                        jagged[harvestRow][harvestCol] = ' ';
                        carrots++;
                    }
                    else if (jagged[harvestRow][harvestCol] == 'P')
                    {
                        jagged[harvestRow][harvestCol] = ' ';
                        potatos++;
                    }
                    else if (jagged[harvestRow][harvestCol] == 'L')
                    {
                        jagged[harvestRow][harvestCol] = ' ';
                        lettuces++;
                    }
                }
            }
            else
            {
                int moleRow = int.Parse(tokens[1]);
                int moleCol = int.Parse(tokens[2]);
                string direction = tokens[3];

                if (moleRow >= 0 && moleRow < rows && moleCol >= 0 && moleCol < jagged[moleRow].Length)
                {
                    if (direction == "up")
                    {
                        while (moleRow >= 0)
                        {
                            if (jagged[moleRow][moleCol] == 'P' || jagged[moleRow][moleCol] == 'C' || jagged[moleRow][moleCol] == 'L')
                            {
                                jagged[moleRow][moleCol] = ' ';
                                harmed++;

                            }
                            moleRow -= 2;
                        }
                    }
                    else if (direction == "down")
                    {
                        while (moleRow < rows)
                        {
                            if (jagged[moleRow][moleCol] == 'P' || jagged[moleRow][moleCol] == 'C' || jagged[moleRow][moleCol] == 'L')
                            {
                                jagged[moleRow][moleCol] = ' ';
                                harmed++;

                            }
                            moleRow += 2;
                        }
                    }
                    else if (direction == "left")
                    {
                        while (moleCol >= 0)
                        {
                            if (jagged[moleRow][moleCol] == 'P' || jagged[moleRow][moleCol] == 'C' || jagged[moleRow][moleCol] == 'L')
                            {
                                jagged[moleRow][moleCol] = ' ';
                                harmed++;

                            }
                            moleCol -= 2;
                        }
                    }
                    else if (direction == "right")
                    {
                        while (moleCol < jagged[moleRow].Length)
                        {
                            if (jagged[moleRow][moleCol] == 'P' || jagged[moleRow][moleCol] == 'C' || jagged[moleRow][moleCol] == 'L')
                            {
                                jagged[moleRow][moleCol] = ' ';
                                harmed++;

                            }
                            moleCol += 2;
                        }
                    }
                }
            }
        }

        foreach (var row in jagged)
        {
            Console.WriteLine(string.Join(" ", row));
        }

        Console.WriteLine("Carrots: {0}", carrots);
        Console.WriteLine("Potatoes: {0}", potatos);
        Console.WriteLine("Lettuce: {0}", lettuces);
        Console.WriteLine("Harmed vegetables: {0}", harmed);
    }
}
