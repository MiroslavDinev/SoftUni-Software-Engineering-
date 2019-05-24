using System;
using System.Collections.Generic;

namespace _06GenericCountMethodDouble
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Box<double> box = new Box<double>();

            for (int i = 0; i < n; i++)
            {
                double num = double.Parse(Console.ReadLine());
                box.Add(num);
            }

            double element = double.Parse(Console.ReadLine());

            int result = CountElements(box.Data, element);

            Console.WriteLine(result);
        }

        public static int CountElements<T>(List<T> data, double element) where T : IComparable
        {
            int counter = 0;

            foreach (var item in data)
            {
                if (item.CompareTo(element)>0)
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
