using System;
using System.Linq;

namespace _04Froggy
{
    public class Program
    {
        static void Main(string[] args)
        {
            Lake lake = new Lake();

            int[] input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            foreach (var item in input)
            {
                lake.Add(item);
            }

            Console.WriteLine(string.Join(", ",lake));
        }
    }
}
