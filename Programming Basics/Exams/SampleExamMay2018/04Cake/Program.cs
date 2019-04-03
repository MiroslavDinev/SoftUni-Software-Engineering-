using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());

            int area = width * length;

            while (area >=0)
            {
                string pieces = Console.ReadLine();

                if (pieces == "STOP")
                {
                    break;
                }
                area -= int.Parse(pieces);
            }
            if (area >=0)
            {
                Console.WriteLine("{0} pieces are left.",area);
            }
            else
            {
                Console.WriteLine("No more cake left! You need {0} pieces more.",Math.Abs(area));
            }
        }
    }
}
