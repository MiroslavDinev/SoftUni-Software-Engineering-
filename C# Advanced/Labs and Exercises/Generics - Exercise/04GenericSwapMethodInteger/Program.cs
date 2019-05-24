using System;
using System.Collections.Generic;
using System.Linq;

namespace _04GenericSwapMethodInteger
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Box<int> box = new Box<int>();

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                box.Add(num);
            }

            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int index1 = indexes[0];
            int index2 = indexes[1];

            Swap<int>(box.Data, index1, index2);

            Console.WriteLine(box);
        }

        public static void Swap<T> (List<T> box, int index1, int index2)
        {
            T temp = box[index1];
            box[index1] = box[index2];
            box[index2] = temp;
        }
    }
}
