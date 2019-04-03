using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus
{
    class Program
    {
        static void Main(string[] args)
        {
            int passangers = int.Parse(Console.ReadLine());
            int stops = int.Parse(Console.ReadLine());

            int controls = 2;
            int currPass = 0;

            for (int currStop = 1; currStop <= stops; currStop++)
            {
                int disembark = int.Parse(Console.ReadLine());
                int embark = int.Parse(Console.ReadLine());

                if (currStop == 1)
                {
                    currPass = passangers + controls + embark - disembark;
                }
                else if (currStop %2==0)
                {
                    currPass = currPass - controls - disembark + embark;
                }
                else if (currStop %2 !=0 && currStop !=1)
                {
                    currPass = currPass + controls + embark - disembark;
                }
            }
            Console.WriteLine("The final number of passengers is: {0}.",currPass);
        }
    }
}
