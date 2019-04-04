using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04Everest
{
    class Program
    {
        static void Main(string[] args)
        {
            int startMeters = 5364;
            int days = 1;
            int topMeters = 8848;

            while (startMeters < topMeters)
            {
                string spentNight = Console.ReadLine();

                if (spentNight == "END")
                {
                    break;
                }

                else if (spentNight == "Yes")
                {
                    days++;

                    if (days == 6)
                    {
                        break;
                    }
                }

                int metersClimbed = int.Parse(Console.ReadLine());

                startMeters += metersClimbed;
            }

            if (startMeters >= topMeters)
            {
                Console.WriteLine("Goal reached for {0} days!",days);
            }
            else
            {
                Console.WriteLine("Failed!");
                Console.WriteLine(startMeters);
            }
        }
    }
}
