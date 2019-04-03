using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombinationOfLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            char begInt = char.Parse(Console.ReadLine());
            char endInt = char.Parse(Console.ReadLine());
            char skip = char.Parse(Console.ReadLine());

            int counter = 0;

            for (char x = begInt; x <= endInt; x++)
            {
                for (char y = begInt; y <= endInt; y++)
                {
                    for (char z = begInt; z <= endInt; z++)
                    {
                        if (x== skip || y == skip || z==skip)
                        {
                            continue;
                        }
                        else
                        {
                            Console.Write($"{x}{y}{z} ");
                            counter++;
                        }
                    }
                }
            }
            Console.Write(counter);
            Console.WriteLine();
        }
    }
}
