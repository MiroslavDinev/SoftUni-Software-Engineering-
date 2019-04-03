using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volleyball
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeYear = Console.ReadLine().ToLower();
            int praznici = int.Parse(Console.ReadLine());
            int homeWeekends = int.Parse(Console.ReadLine());

            int weekendsInSofia = 48 - homeWeekends;
            double playWeekendsInSofia = weekendsInSofia * 0.75;
            double playDuringPraznici = (2 * praznici) / 3;
            double allPlay = playWeekendsInSofia + playDuringPraznici + homeWeekends;

            if (typeYear == "leap")
            {
                double wholePlay = allPlay + (allPlay * 0.15);
                Console.WriteLine(Math.Floor(wholePlay));
            }
            else if (typeYear == "normal")
            {
                Console.WriteLine(Math.Floor(allPlay));
            }

        }
    }
}
