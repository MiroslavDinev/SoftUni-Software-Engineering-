using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatShelter
{
    class Program
    {
        static void Main(string[] args)
        {
            double foodInKilos = double.Parse(Console.ReadLine());

            double foodInGr = foodInKilos * 1000;

            while (true)
            {
                string food = Console.ReadLine();

                if (food == "Adopted")
                {
                    break;
                }
                foodInGr -= double.Parse(food);
            }

            if (foodInGr >=0)
            {
                Console.WriteLine("Food is enough! Leftovers: {0} grams.",foodInGr);
            }
            else
            {
                Console.WriteLine("Food is not enough. You need {0} grams more.",Math.Abs(foodInGr));
            }
        }
    }
}
