using System;

namespace _07ConcatNames
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstName = Console.ReadLine();
            string secondName = Console.ReadLine();
            string delimeter = Console.ReadLine();

            Console.WriteLine("{0}{1}{2}", firstName, delimeter, secondName);
        }
    }
}
