using System;
using System.Linq;

namespace _06EqualSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int leftSum = 0;
            int rightSum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                rightSum += arr[i];
            }

            for (int i = 0; i < arr.Length; i++)
            {
                rightSum -= arr[i];

                if (rightSum == leftSum)
                {
                    Console.WriteLine(i);
                    return;
                }
                leftSum += arr[i];
            }
            Console.WriteLine("no");
        }
    }
}
