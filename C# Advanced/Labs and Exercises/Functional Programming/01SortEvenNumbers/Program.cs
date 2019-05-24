﻿using System;
using System.Linq;
using System.Collections.Generic;

namespace _01SortEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split(", ").Select(int.Parse).Where(x => x % 2 == 0).OrderBy(x => x).ToList();

            Console.WriteLine(string.Join(", ",nums));
        }
    }
}
