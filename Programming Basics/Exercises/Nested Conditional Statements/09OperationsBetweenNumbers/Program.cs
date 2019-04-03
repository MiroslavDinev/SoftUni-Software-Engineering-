using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationsBetweenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double N1 = int.Parse(Console.ReadLine());
            double N2 = int.Parse(Console.ReadLine());
            string operators = Console.ReadLine();

            if (operators == "+")
            {
                double results = N1 + N2;
                if (results % 2 == 0)
                {
                    Console.WriteLine("{O} + {2} = {3} - even", N1,N2, results);
                }
                else
                {
                    Console.WriteLine("{O} + {2} = {3} - odd", N1, N2, results);
                }
            }
            if (operators == "-")
            {
                double results = N1 - N2;
                if (results %2 == 0)
                {
                    Console.WriteLine("{O} - {2} = {3} - even", N1, N2, results);
                }
                else
                {
                    Console.WriteLine("{O} - {2} = {3} - odd", N1, N2, results);
                }
            } 
            if (operators == "*")
            {
                double results = N1 * N2;
                if (results % 2 == 0)
                {
                    Console.WriteLine("{O} * {2} = {3} - even", N1, N2, results);
                }
                else
                {
                    Console.WriteLine("{O} * {2} = {3} - odd", N1, N2, results);
                }
            }
            if (operators == "/")
            {
                double results = N1 / N2;
                Console.WriteLine("{0} / {2} = {3:f2}", N1, N2,results);
            }
            if (operators == "%")
            {
                double results = N1 % N2;
                Console.WriteLine("{0} % {2} = {3}",N1, N2, results);
            }
            if (N2 == 0)
            {
                Console.WriteLine("Cannot divide {0} by zero", N1);     // https://pastebin.com/9tGDxZ4S 
            }
        }
    }
}
