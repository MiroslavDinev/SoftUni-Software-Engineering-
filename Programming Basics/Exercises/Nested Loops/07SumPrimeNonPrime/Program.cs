using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07SumPrimeNonPrime
{
    class Program
    {
        static void Main(string[] args)
        {
            //int primeSum = 0;
            //int nonPrimeSum = 0;



            //while (true)
            //{
            //    string command = Console.ReadLine();

            //    if (command == "stop")
            //    {
            //        break;
            //    }

            //    int num = int.Parse(command);

            //    if (num < 0)
            //    {
            //        Console.WriteLine("Number is negative.");
            //    }

            //    bool isPrime = true;

            //    for (int i = 2; i <= Math.Sqrt(num); i++)
            //    {
            //        if (num % i == 0)
            //        {
            //            isPrime = false;
            //            nonPrimeSum += num;
            //            break;
            //        }
            //    }



            //    if (isPrime && num >= 0)
            //    {
            //        primeSum += num;
            //    }

            //}

            //Console.WriteLine($"Sum of all prime numbers is: {primeSum}");
            //Console.WriteLine($"Sum of all non prime numbers is: {nonPrimeSum}");

            // Gornoto e 70/100 , a dolnoto 100/100

            string input = Console.ReadLine();
            int sumPrime = 0;
            int sumNonprime = 0;

            while (input != "stop")
            {

                int num = int.Parse(input);
                int count = 0;

                for (int i = 2; i <= Math.Sqrt(num); i++)
                {

                    if (num % i == 0)
                    {
                        count++;
                        break;
                    }

                }

                if (num < 0)
                {
                    Console.WriteLine("Number is negative.");
                }
                else if (count > 0 || num == 1)
                {
                    sumNonprime += num;
                }
                else
                {
                    sumPrime += num;
                }

                input = Console.ReadLine();


            }

            Console.WriteLine("Sum of all prime numbers is: {0}", sumPrime);
            Console.WriteLine("Sum of all non prime numbers is: {0}", sumNonprime);
        }
    }
}
