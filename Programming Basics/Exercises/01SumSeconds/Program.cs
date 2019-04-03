using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01SumSeconds
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstSec = int.Parse(Console.ReadLine());
            int secondSec = int.Parse(Console.ReadLine());
            int thirdSec = int.Parse(Console.ReadLine());

            int sum = firstSec + secondSec + thirdSec;
            int min =0;

            if (sum <=59 && sum >=10)
            {
                Console.WriteLine("0:"+sum);
            }
            else if (sum >=60 && sum <=119)
            {
                sum = sum - 60;
                min = 1;

                if (sum <=9)
                {
                    Console.WriteLine("{0}:0{1}",min,sum);
                }
                else if (sum >=10)
                {
                    Console.WriteLine("{0}:{1}", min, sum);
                }
            }
            else if (sum >=120 && sum<=179)
            {
                sum = sum - 120;
                min = 2;

                if (sum <= 9)
                {
                    Console.WriteLine("{0}:0{1}", min, sum);
                }
                else if (sum >= 10)
                {
                    Console.WriteLine("{0}:{1}", min, sum);
                }
            }
            else if (sum <10)
            {
                Console.WriteLine("0:0{0}",sum);
            }
        }
    }
}
