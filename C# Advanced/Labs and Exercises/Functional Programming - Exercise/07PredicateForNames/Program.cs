using System;
using System.Linq;
using System.Collections.Generic;

namespace _07PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine().Split();

            Predicate<string> toPrint = x => x.Length <= n;

            Action<string> print = x => Console.WriteLine(x);

            print(string.Join(Environment.NewLine,names.Where(x=>toPrint(x))));
        }
    }
}
