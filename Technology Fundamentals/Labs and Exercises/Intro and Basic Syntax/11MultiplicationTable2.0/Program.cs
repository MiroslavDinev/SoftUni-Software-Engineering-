using System;

namespace _11MultiplicationTable2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int multiplyer = int.Parse(Console.ReadLine());

            if (multiplyer > 10)
            {
                Console.WriteLine("{0} X {1} = {2}", n, multiplyer, n * multiplyer);
                return;
            }
            else
            {
                for (int i = multiplyer; i <= 10; i++)
                {
                    Console.WriteLine("{0} X {1} = {2}", n, i, n * i);
                }
            }
        }
    }
}
