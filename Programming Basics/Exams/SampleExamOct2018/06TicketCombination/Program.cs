using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06TicketCombination
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int sum = 0;
            int counter = 0;

            for (char i = 'B'; i <= 'L'; i++)
            {
                for (char k = 'f';  k >= 'a';  k--)
                {
                    for (char x = 'A'; x <= 'C'; x++)
                    {
                        for (int y = 1; y <= 10; y++)
                        {
                            for (int z = 10; z >= 1; z--)
                            {
                                if (i%2==0)
                                {

                                  counter++;

                                    if (counter == number)
                                    {
                                        sum += i + k + x + y + z;
                                        Console.WriteLine($"Ticket combination: {i}{k}{x}{y}{z}");
                                        Console.WriteLine("Prize: {0} lv.", sum);
                                    }
                                }

                                
                            }
                        }
                    }
                }
            }
        }
    }
}
