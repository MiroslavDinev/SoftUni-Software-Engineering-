using System;

namespace _06CalculateRectangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            double height = double.Parse(Console.ReadLine());
            double length = double.Parse(Console.ReadLine());
            double area = RectangleArea(height, length);
            Console.WriteLine(area);

        }

        private static double RectangleArea (double heigth, double length)
        {
            return heigth * length;
        }
    }
}
