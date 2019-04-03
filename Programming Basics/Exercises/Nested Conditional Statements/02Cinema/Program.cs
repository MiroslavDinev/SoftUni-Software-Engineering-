using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeProjection = Console.ReadLine().ToLower();
            int rows = int.Parse(Console.ReadLine());
            int columns = int.Parse(Console.ReadLine());
            int full = rows * columns;

            switch (typeProjection)
            {
                case "premiere": Console.WriteLine("{0:f2} leva",full*12.00); break;
                case "normal": Console.WriteLine("{0:f2} leva", full * 7.50); break;
                case "discount": Console.WriteLine("{0:f2} leva", full * 5.00); break;
            }
        }
    }
}
