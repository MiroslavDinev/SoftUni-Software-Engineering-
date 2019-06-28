using System;
using System.Linq;
using System.Collections.Generic;

namespace _02ExcelFunctions
{
    public class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            string[][] excel = new string[rows][];

            for (int row = 0; row < rows; row++)
            {
                string[] input = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                excel[row] = input;
            }

            string[] commands = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string action = commands[0];

            if (action == "hide")
            {
                string header = commands[1];
                int headerCol = -1;

                for (int col = 0; col < excel[0].Length; col++)
                {
                    if (excel[0][col] == header)
                    {
                        headerCol = col;
                    }
                }

                Console.WriteLine(string.Join(" | ", excel[0].Where(x => x != header)));

                for (int row = 1; row < excel.Length; row++)
                {
                    Console.WriteLine(string.Join(" | ", excel[row].Where((x, y) => y != headerCol)));
                }
            }

            else if (action == "sort")
            {
                string header = commands[1];
                int headerCol = -1;

                for (int col = 0; col < excel[0].Length; col++)
                {
                    if (excel[0][col] == header)
                    {
                        headerCol = col;
                    }
                }

                Console.WriteLine(string.Join(" | ", excel[0]));

                foreach (var row in excel.OrderBy(x => x[headerCol]))
                {
                    if (!row.Contains(header))
                    {
                        Console.WriteLine(string.Join(" | ", row));
                    }
                }
            }

            else if (action == "filter")
            {
                string header = commands[1];
                string @value = commands[2];
                int headerCol = -1;

                for (int col = 0; col < excel[0].Length; col++)
                {
                    if (excel[0][col] == header)
                    {
                        headerCol = col;
                    }
                }

                Console.WriteLine(string.Join(" | ", excel[0]));

                for (int row = 0; row < rows; row++)
                {
                    if (excel[row][headerCol] == @value)
                    {
                        Console.WriteLine(string.Join(" | ", excel[row]));
                    }
                }
            }
        }
    }
}
