using System;
using System.Collections.Generic;

namespace _01SortNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());

            List<double> list = new List<double>();
            list.Add(a);
            list.Add(b);
            list.Add(c);
            list.Sort();
            list.Reverse();
            Console.WriteLine(string.Join(Environment.NewLine, list));
        }
    }
}
