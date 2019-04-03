using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int begInt = int.Parse(Console.ReadLine());
            int endInt = int.Parse(Console.ReadLine());

            for (int a = begInt; a <= endInt; a++)
            {
                for (int b = begInt; b <= endInt; b++)
                {
                    for (int c = begInt; c <= endInt; c++)
                    {
                        for (int z = begInt; z <= endInt; z++)
                        {
                            if ((a%2==0 && z%2 !=0) || (a%2 !=0 && z %2==0))
                            {
                                if (a>z && ((b+c) %2==0))
                                {
                                    Console.Write($"{a}{b}{c}{z} ");
                                }
                            }

                        }
                    }
                }
            }
        }
    }
}
