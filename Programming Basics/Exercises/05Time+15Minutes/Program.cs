using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05Time_15Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int h = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            int minAfter15 = m + 15;

            if (minAfter15 >=60)
            {
                h++;
                m = minAfter15 - 60;
            }

            if (h==0)
            {

                Console.WriteLine("0:{0:D2}",minAfter15);
            }
            else if (h>=1 && h<=23)
            {
                if (minAfter15<60)
                {
                  Console.WriteLine("{0}:{1:D2}",h,minAfter15);

                }
                else
                {
                    Console.WriteLine("{0}:{1:D2}", h, m);
                }

            }
            else if (h==24)
            {
                Console.WriteLine("0:{0:D2}",m);
            }
        }
    }
}
