using System;

namespace _07NxNMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            Matrix(number);
        }

        public static void Matrix(int num)
        {
            for (int i = 0; i < num; i++)
            {
                for (int j = 0; j < num; j++)
                {
                    Console.Write(num + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
