using System;
using System.Collections.Generic;

namespace _05GenericCountMethodString
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Box<string> box = new Box<string>();

            for (int i = 0; i < n; i++)
            {
                string text = Console.ReadLine();
                box.Add(text);
            }

            string element = Console.ReadLine();

            int result = CountElements(box.Data, element);
            Console.WriteLine(result);
        }

        public static int CountElements<T> (List<T> data,string element) where T : IComparable
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
