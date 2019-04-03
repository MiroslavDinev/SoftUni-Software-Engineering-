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

            for (char i = begInt; i <= endInt; i++)
            {
                for (char x = begInt; x <= endInt; x++)
                {
                    for (char z = begInt; z <= endInt; z++)
                    {
                        if (i==skip || x==skip || z==skip)
                        {
                            continue;
                        }
                        Console.Write("{0}{1}{2} ",i,x,z);
                        counter++;
                    }
                }
            }
            Console.Write(counter);
            Console.WriteLine();
        }
    }
}
