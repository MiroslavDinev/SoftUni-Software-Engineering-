using System;

namespace _05PrintPartOfASCIITable
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            char beg = (char)start;
            char fin = (char)end;

            for (char i = beg; i <= fin; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}
