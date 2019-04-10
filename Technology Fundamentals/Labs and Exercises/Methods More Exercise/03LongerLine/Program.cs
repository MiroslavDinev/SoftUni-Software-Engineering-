using System;

namespace _03LongerLine
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double x3 = double.Parse(Console.ReadLine());
            double y3 = double.Parse(Console.ReadLine());
            double x4 = double.Parse(Console.ReadLine());
            double y4 = double.Parse(Console.ReadLine());

            double firstLength = FirstPointDistance(x1, y1, x2, y2);
            double secondLength = SecondPointDistance(x3, y3, x4, y4);

            if (firstLength>=secondLength)
            {
                if (Math.Abs(x1)<=Math.Abs(x2)&& Math.Abs(y1)<=Math.Abs(y2))
                {
                    Console.WriteLine($"({x1}, {y1})({x2}, {y2})");
                }
                else
                {
                    Console.WriteLine($"({x2}, {y2})({x1}, {y1})");
                }
            }
            else
            {
                if (Math.Abs(x3) <= Math.Abs(x4) && Math.Abs(y3) <= Math.Abs(y4))
                {
                    Console.WriteLine($"({x3}, {y3})({x4}, {y4})");
                }
                else
                {
                    Console.WriteLine($"({x4}, {y4})({x3}, {y3})");
                }
            }

        }

        public static double FirstPointDistance (double x1, double y1, double x2, double y2)
        {
            double resultFirstX = Math.Sqrt(x1 * x1 + y1 * y1);
            double resultFirstY = Math.Sqrt(x2 * x2 + y2 * y2);
            double totalDistanceFirstPoint = resultFirstX + resultFirstY;
            return totalDistanceFirstPoint;
        }

        public static double SecondPointDistance(double x3, double y3, double x4, double y4)
        {
            double resultFirstX = Math.Sqrt(x3 * x3 + y3 * y3);
            double resultFirstY = Math.Sqrt(x4 * x4 + y4 * y4);
            double totalDistanceFirstPoint = resultFirstX + resultFirstY;
            return totalDistanceFirstPoint;
        }

        // https://pastebin.com/9vc9CQzX 100, gornoto 80  https://pastebin.com/W9aWJahP
    }
}
