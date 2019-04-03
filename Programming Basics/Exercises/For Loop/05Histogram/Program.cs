using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int p1 = 0;
            int p2 = 0;
            int p3 = 0;
            int p4 = 0;
            int p5 = 0;

            for (int i = 1; i <= n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (num<200)
                {
                    p1++;
                }
                else if (num >=200 && num <=399)
                {
                    p2++;
                }
                else if (num > 399 && num <=599)
                {
                    p3++;
                }
                else if (num >599 && num <=799)
                {
                    p4++;
                }
                else if (num >799)
                {
                    p5++;
                }
            }
            double percent1 = p1 * 100.0 / n;
            double percent2 = p2 * 100.0 / n;
            double percent3 = p3 * 100.0 / n;
            double percent4 = p4 * 100.0 / n;
            double percent5 = p5 * 100.0 / n;

            Console.WriteLine("{0:f2}%",percent1);
            Console.WriteLine("{0:f2}%", percent2);
            Console.WriteLine("{0:f2}%", percent3);
            Console.WriteLine("{0:f2}%", percent4);
            Console.WriteLine("{0:f2}%", percent5);
        }
    }
}
