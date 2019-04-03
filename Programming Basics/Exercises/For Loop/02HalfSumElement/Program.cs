using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02HalfSumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int sum = 0;
            int max = int.MinValue;

            for (int i = 1; i <= n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                sum += num;

                if (num>max)
                {
                    max = num;
                }
            }
            int sumWithoutMax = sum - max;
            if (sumWithoutMax == max)
            {
                Console.WriteLine("Yes, Sum = {0}",max);
            }
            else
            {
                Console.WriteLine("No, Diff = {0}",Math.Abs(sumWithoutMax-max));
            }
        }
    }
}
