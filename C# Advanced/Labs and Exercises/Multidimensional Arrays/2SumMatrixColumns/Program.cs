﻿using System;
using System.Linq;

namespace _2SumMatrixColumns
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] props = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int rows = props[0];
            int cols = props[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] currRow = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currRow[col];
                }
            }

            for (int col = 0; col < cols; col++)
            {
                int sum = 0;

                for (int row = 0; row < rows; row++)
                {
                    sum += matrix[row,col];
                }

                Console.WriteLine(sum);
            }
        }
    }
}