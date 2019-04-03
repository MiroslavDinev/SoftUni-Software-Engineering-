using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.OddEvenPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            double n = double.Parse(Console.ReadLine());

            double oddSum = 0;
            double oddMin = double.MaxValue;
            double oddMax = double.MinValue;
            double evenSum = 0;
            double evenMin = double.MaxValue;
            double evenMax = double.MinValue;

            for (int i = 1; i <= n; i++)
            {
                double num = double.Parse(Console.ReadLine());

                if (i%2==0)
                {
                    evenSum += num;

                    if (num > evenMax)
                    {
                        evenMax = num;
                    }
                    if (num < evenMin)
                    {
                        evenMin = num;
                    }
                }
                else
                {
                    oddSum += num;

                    if (num > oddMax)
                    {
                        oddMax = num;
                    }
                    if (num < oddMin)
                    {
                        oddMin = num;
                    }
                }
            }
            Console.WriteLine("OddSum={0}",oddSum);

            if (oddMin!=double.MaxValue)
            {
                Console.WriteLine("OddMin={0}",oddMin);
            }
            else
            {
                Console.WriteLine("OddMin=No");
            }
            if (oddMax != double.MinValue)
            {
                Console.WriteLine("OddMax={0}", oddMax);
            }
            else
            {
                Console.WriteLine("OddMax=No");
            }

            Console.WriteLine("EvenSum={0}",evenSum);

            if (evenMin != double.MaxValue)
            {
                Console.WriteLine("EvenMin={0}", evenMin);
            }
            else
            {
                Console.WriteLine("EvenMin=No");
            }
            if (evenMax != double.MinValue)
            {
                Console.WriteLine("EvenMax={0}", evenMax);
            }
            else
            {
                Console.WriteLine("EvenMax=No");
            }
        }
    }
}
