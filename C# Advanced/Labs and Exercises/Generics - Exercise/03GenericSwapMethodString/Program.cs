using System;
using System.Linq;
using System.Collections.Generic;

namespace _03GenericSwapMethodString
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            GenericBoxList<string> box = new GenericBoxList<string>();

            for (int i = 0; i < n; i++)
            {
                string toAdd = Console.ReadLine();
                box.Add(toAdd);
            }

            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int firstIndex = indexes[0];
            int secondIndex = indexes[1];

            Swap<string>(box.Data, firstIndex, secondIndex);

            Console.WriteLine(box);

            void Swap<T>(List<T> listWithData, int index1, int index2)
            {
                T temp = listWithData[index1];
                listWithData[index1] = listWithData[index2];
                listWithData[index2] = temp;
            }
        }
    }
}
