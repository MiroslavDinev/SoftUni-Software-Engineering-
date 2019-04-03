using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10PasswordGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());

            for (int i = 1; i < n; i++)
            {
                for (int k = 1; k < n; k++)
                {
                    for (char x = 'a'; x < 'a' + l; x++)
                    {
                        for (char y = 'a'; y < 'a' +l; y++)
                        {
                            for (int z = 1; z <= n; z++)
                            {
                                if (z>i && z>k)
                                {
                                    Console.Write($"{i}{k}{x}{y}{z} ");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
