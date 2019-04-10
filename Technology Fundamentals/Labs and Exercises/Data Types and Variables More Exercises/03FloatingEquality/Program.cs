using System;

namespace _04FloatingEquality
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());

            double ep = 0.000001;

            double result = Math.Abs(a - b);

            if (result > ep)
            {
                Console.WriteLine("False");
            }
            else if (result < ep)
            {
                Console.WriteLine("True");
            }
            else if (result == ep)
            {
                Console.WriteLine("False");
            }
        }
    }
}
