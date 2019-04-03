using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04Coding
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            string strNum = num.ToString();

            for (int i = 0; i < strNum.Length; i++)
            {
                int lastDigit = num % 10;
                int lastNum = num / 10;
                num = lastNum;

                if (lastDigit ==0)
                {
                    Console.WriteLine("ZERO");
                }
                else
                {
                    for (int z = 1; z <= lastDigit; z++)
                    {
                        int ascii = 33 + lastDigit;
                        char symbol = (char)ascii;
                        Console.Write(symbol);
                    }
                    Console.WriteLine();
                }
                
            }
        }
    }
}
