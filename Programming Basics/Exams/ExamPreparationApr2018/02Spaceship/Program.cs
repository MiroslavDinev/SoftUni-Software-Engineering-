using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spaceship
{
    class Program
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double heigth = double.Parse(Console.ReadLine());
            double length = double.Parse(Console.ReadLine());
            double spacemanHeight = double.Parse(Console.ReadLine());

            double area = width * heigth * length;
            double roomArea = 2 * 2 * (spacemanHeight + 0.40);
            double astronauts = Math.Floor(area / roomArea);

            if (astronauts>=3 && astronauts<=10)
            {
                Console.WriteLine("The spacecraft holds {0} astronauts.",astronauts);
            }
            else if (astronauts<3)
            {
                Console.WriteLine("The spacecraft is too small.");
            }
            else if (astronauts>10)
            {
                Console.WriteLine("The spacecraft is too big.");
            }
        }
    }
}
