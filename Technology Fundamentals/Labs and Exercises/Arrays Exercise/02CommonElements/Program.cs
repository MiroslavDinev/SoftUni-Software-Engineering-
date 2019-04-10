using System;
using System.Linq;

namespace _02CommonElements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr1 = Console.ReadLine().Split();
            string[] arr2 = Console.ReadLine().Split();

            foreach (var item2 in arr2)
            {
                if (arr1.Contains(item2))
                {
                    Console.Write(item2 + " ");
                }
            }
        }
    }
}
