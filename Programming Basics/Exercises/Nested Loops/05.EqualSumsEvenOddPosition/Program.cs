using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.EqualSumsEvenOddPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            //int begNum = int.Parse(Console.ReadLine());
            //int endNum = int.Parse(Console.ReadLine());

            //int oddSum = 0;
            //int evenSum = 0;

            //for (int i = begNum; i <= endNum; i++)
            //{
            //    int lastEvenDigit = i % 10;
            //    int remove1 = i / 10;
            //    int lastOddDigit = remove1 % 10;
            //    int remove2 = remove1 / 10;
            //    int midEvenDigit = remove2 % 10;
            //    int remove3 = remove2 / 10;
            //    int midOddDigit = remove3 % 10;
            //    int remove4 = remove3 / 10;
            //    int firstEvenDigit = remove4 % 10;
            //    int remove5 = remove4 / 10;
            //    int firstOddDigit = remove5 % 10;

            //    oddSum = firstOddDigit + midOddDigit + lastOddDigit;
            //    evenSum = firstEvenDigit + midEvenDigit + lastEvenDigit;

            //    if (oddSum == evenSum)
            //    {
            //        Console.Write(i + " ");
            //    }
            //}

            int begNum = int.Parse(Console.ReadLine());
            int endNum = int.Parse(Console.ReadLine());

            int oddSum = 0;
            int evenSum = 0;

            for (int i = begNum; i <= endNum; i++)
            {
                int firstOddDigit = (i / 100000) % 10;
                int firstEvenDigit = (i / 10000) % 10;
                int midOddDigit = (i / 1000) % 10;
                int midEvenDigit = (i / 100) % 10;
                int lastOddDigit = (i / 10) % 10;
                int lastEvenDigit = (i / 1) % 10;

                oddSum = firstOddDigit + midOddDigit + lastOddDigit;
                evenSum = firstEvenDigit + midEvenDigit + lastEvenDigit;

                if (oddSum == evenSum)
                {
                    Console.Write(i + " ");
                }
            } // both work 100/100
        }   
    }
}
