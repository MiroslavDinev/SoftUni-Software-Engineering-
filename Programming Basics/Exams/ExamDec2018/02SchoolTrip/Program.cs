using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02SchoolTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double wholeFood = double.Parse(Console.ReadLine());
            double foodPerDayFirstDog = double.Parse(Console.ReadLine());
            double foodPerDaySecondDog = double.Parse(Console.ReadLine());
            double foodPerDayThirdDog = double.Parse(Console.ReadLine());

            double foodForFirst = days * foodPerDayFirstDog;
            double foodForSecond = days * foodPerDaySecondDog;
            double foodForThird = days * foodPerDayThirdDog;

            double totalFoodNeeded = foodForFirst + foodForSecond + foodForThird;

            if (wholeFood >= totalFoodNeeded)
            {
                Console.WriteLine("{0} kilos of food left.",Math.Floor(wholeFood-totalFoodNeeded));
            }
            else
            {
                Console.WriteLine("{0} more kilos of food are needed.",Math.Ceiling(totalFoodNeeded - wholeFood));
            }
        }
    }
}
