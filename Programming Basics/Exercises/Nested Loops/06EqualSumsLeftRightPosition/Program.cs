using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06EqualSumsLeftRightPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            int begNum = int.Parse(Console.ReadLine());
            int endNum = int.Parse(Console.ReadLine());

            int leftSum = 0;
            int rightSum = 0;

            for (int i = begNum; i <= endNum; i++)
            {
                int firstLeftDigit = (i / 10000) % 10;
                int secondLeftDigit = (i / 1000) % 10;
                int midDigit = (i / 100) % 10;
                int firstRightDigit = (i / 10) % 10;
                int secondRightDigit = (i / 1) % 10;

                leftSum = firstLeftDigit + secondLeftDigit;
                rightSum = firstRightDigit + secondRightDigit;

                if (leftSum == rightSum)
                {
                    Console.Write(i + " ");
                }
                else
                {
                    if (leftSum > rightSum)
                    {
                        rightSum += midDigit;
                        {
                            if (leftSum == rightSum)
                            {
                                Console.Write(i + " ");
                            }
                        }
                    }
                    else if (leftSum<rightSum)
                    {
                        leftSum += midDigit;

                        if (leftSum == rightSum)
                        {
                            Console.Write(i + " ");
                        }
                    }
                }
            }
        }
    }
}
