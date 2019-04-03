using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11SpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= 9; i++)
            {
                for (int x = 1; x <= 9; x++)
                {
                    for (int y = 1; y <= 9; y++)
                    {
                        for (int z = 1; z <= 9; z++)
                        {
                            if (n%i==0 && n%x==0 && n%y==0 && n%z==0)
                            {
                                Console.Write($"{i}{x}{y}{z} ");
                            }
                        }
                    }
                }
            }
        }
    }
}
