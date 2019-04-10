using System;
using System.Linq;

namespace _05TopIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < arr.Length-1; i++)
            {
                int num = arr[i];

                for (int j = i+1; j < arr.Length; j++)
                {
                    int numToCompare = arr[j];

                    if (num <= numToCompare)
                    {
                        break;
                    }
                    else if (j==arr.Length-1)
                    {
                        Console.Write(num + " ");
                    }
                }
            }
            Console.Write(arr[arr.Length - 1]);
        }
    }
}
