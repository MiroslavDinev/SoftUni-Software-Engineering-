using System;
using System.Linq;
using System.Collections.Generic;

namespace _5SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] props = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string snakeInput = Console.ReadLine();

            char[] snake = snakeInput.ToCharArray();
            Queue<char> snakeQueue = new Queue<char>(snake);

            int rows = props[0];
            int cols = props[1];

            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    char currSymbol = snakeQueue.Dequeue();
                    matrix[row, col] = currSymbol;
                    snakeQueue.Enqueue(currSymbol);
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }
        }
    }
}
