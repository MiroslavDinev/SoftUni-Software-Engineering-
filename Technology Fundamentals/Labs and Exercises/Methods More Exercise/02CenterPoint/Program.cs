using System;

namespace _02CenterPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            if (x1==y2 && x2==y1)
            {
                Console.WriteLine($"({x1}, {y1})");
                return;
            }

            double resultx = ClosestX(x1, x2);
            double resulty = ClosestY(y1, y2);
            Console.WriteLine($"({resultx}, {resulty})");

        }

        public static double ClosestX(double x1,double x2)
        {
            double resultx = 0;
            if (Math.Abs(x1)<=Math.Abs(x2))
            {
                 resultx = x1;
            }
            else
            {
                 resultx = x2;
            }
            return resultx;
        }

        public static double ClosestY (double y1, double y2)
        {
            double resulty = 0;
            if (Math.Abs(y1) <= Math.Abs(y2))
            {
                resulty = y1;
            }
            else
            {
                resulty = y2;
            }
            return resulty;         // https://pastebin.com/04RrgnPw tova dava 100,moeto 80
        }
    }
}
