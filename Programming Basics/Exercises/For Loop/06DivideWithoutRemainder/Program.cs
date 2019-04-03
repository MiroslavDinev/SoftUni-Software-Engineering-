using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06DivideWithoutRemainder
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int p1 = 0;
            int p2 = 0;
            int p3 = 0;

            for (int i = 1; i <= n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (num%2==0)
                {
                    p1++;
                }
                if (num%3==0)
                {
                    p2++;
                }
                if (num%4==0)
                {
                    p3++;
                }
            }

            double percent1 = p1 * 100.0 / n;
            double percent2 = p2 * 100.0 / n;
            double percent3 = p3 * 100.0 / n;

            Console.WriteLine("{0:f2}%",percent1);
            Console.WriteLine("{0:f2}%", percent2);
            Console.WriteLine("{0:f2}%", percent3);
        }
    }
}
