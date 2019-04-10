using System;

namespace _01Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int wagons = int.Parse(Console.ReadLine());

            int[] people = new int[wagons];

            int sum = 0;

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = int.Parse(Console.ReadLine());

                sum += people[i];

                if (i==people.Length-1)
                {

                  Console.WriteLine(string.Join(" ", people));
                }

            }
            Console.WriteLine(sum);
        }
    }
}
