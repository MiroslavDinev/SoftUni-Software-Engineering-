using System;

namespace _05RefactoringPrimeChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 2; i <= n; i++)
            {
                bool prime = true;
                for (int z = 2; z < i; z++)
                {
                    if (i % z == 0)
                    {
                        prime = false;
                        break;
                    }
                }

                Console.WriteLine($"{i} -> {prime.ToString().ToLower()}");
            }

        }
    }
}
