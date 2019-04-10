using System;
using System.Linq;

namespace _04ArrayRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int rotations = int.Parse(Console.ReadLine());

            for (int i = 0; i < rotations; i++)     // moje i da vurtim na rotations % arr.Length, zashtoto ako imame masiv ot 3 elementa napr. 10 rotacii vsushnost sa 1 promqna 3x3=9-nqma promqna sled 3 prenarejdaniq i samo ostatuka (1) promenq
            {
                int lastNum = arr[0];

                for (int j = 0; j < arr.Length-1; j++)
                {
                    arr[j] = arr[j + 1];
                }

                arr[arr.Length - 1] = lastNum;
            }

            Console.WriteLine(string.Join(" ",arr));
        }
    }
}
