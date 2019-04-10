using System;
using System.Numerics;

namespace _11Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            BigInteger bestValue = 0;
            int bestSnow = 0;
            int bestTime = 0;
            int bestQuality = 0;

            for (int i = 0; i < n; i++)
            {
                int currSnow = int.Parse(Console.ReadLine());
                int currTime = int.Parse(Console.ReadLine());
                int currQuality = int.Parse(Console.ReadLine());

                BigInteger currValue = BigInteger.Pow((currSnow / currTime), currQuality);

                if (currValue > bestValue)
                {
                    bestValue = currValue;
                    bestSnow = currSnow;
                    bestTime = currTime;
                    bestQuality = currQuality;
                }
            }
            Console.WriteLine("{0} : {1} = {2} ({3})", bestSnow, bestTime, bestValue, bestQuality);
        }
    }
}
