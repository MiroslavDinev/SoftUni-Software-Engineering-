using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05TrekkingMania
{
    class Program
    {
        static void Main(string[] args)
        {
            int groups = int.Parse(Console.ReadLine());

            int musala = 0;
            int monblan = 0;
            int kilimanjaro = 0;
            int k2 = 0;
            int everest = 0;

            int totalPersons = 0;

            for (int i = 1; i <= groups; i++)
            {
                int personsInGroup = int.Parse(Console.ReadLine());

                totalPersons += personsInGroup;

                if (personsInGroup <=5)
                {
                    musala += personsInGroup;
                }
                else if (personsInGroup >=6 && personsInGroup <=12)
                {
                    monblan += personsInGroup;
                }
                else if (personsInGroup >=13 && personsInGroup <=25)
                {
                    kilimanjaro += personsInGroup;
                }
                else if (personsInGroup >=26 && personsInGroup <= 40)
                {
                    k2 += personsInGroup;
                }
                else if (personsInGroup > 40)
                {
                    everest += personsInGroup;
                }
            }

            double percentMusala = musala * 100.0 / totalPersons;
            double percentMonblan = monblan * 100.0 / totalPersons;
            double percentKilimandjaro = kilimanjaro * 100.0 / totalPersons;
            double percentK2 = k2 * 100.0 / totalPersons;
            double percentEverest = everest * 100.0 / totalPersons;

            Console.WriteLine("{0:f2}%",percentMusala);
            Console.WriteLine("{0:f2}%", percentMonblan);
            Console.WriteLine("{0:f2}%", percentKilimandjaro);
            Console.WriteLine("{0:f2}%", percentK2);
            Console.WriteLine("{0:f2}%", percentEverest);

        }
    }
}
