using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03NumberTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int num = 0;

            for (int col = 0; col < n; col++)
            {
                for (int row = 0; row < n; row++)
                {
                    num = 1 + row + col;

                    if (num >n)
                    {
                        num = 2 * n - num;
                    }

                    Console.Write(num + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
