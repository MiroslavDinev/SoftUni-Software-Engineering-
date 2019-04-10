using System;

namespace _04PrintingTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            TopLine(num);
            CenterLine(num);
            LastLine(num);

        }

        public static void CenterLine (int num)
        {
            for (int i = 1; i <= num; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }

        public static void TopLine (int num)
        {
            for (int i = 1; i < num; i++)
            {
                

                for (int j = 1; j < i+1; j++)
                {
                    Console.Write(j + " ");
                }
                Console.WriteLine();
            }
        }

        public static void LastLine (int num)
        {
            for (int i = num - 1; i >= 1; i--)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(j + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
