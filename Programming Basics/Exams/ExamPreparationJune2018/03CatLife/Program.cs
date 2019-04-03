using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatLife
{
    class Program
    {
        static void Main(string[] args)
        {
            string breed = Console.ReadLine();
            string gender = Console.ReadLine();

            double catMonths = 0;

            if (breed == "British Shorthair")
            {
                if (gender == "m")
                {
                    catMonths = (13 * 12) / 6;
                }
                else if (gender == "f")
                {
                    catMonths = (14 * 12) / 6;
                }
            }
            else if (breed == "Siamese")
            {
                if (gender == "m")
                {
                    catMonths = (15 * 12) / 6;
                }
                else if (gender == "f")
                {
                    catMonths = (16 * 12) / 6;
                }
            }
            else if (breed == "Persian")
            {
                if (gender == "m")
                {
                    catMonths = (14 * 12) / 6;
                }
                else if (gender == "f")
                {
                    catMonths = (15 * 12) / 6;
                }
            }
            else if (breed == "Ragdoll")
            {
                if (gender == "m")
                {
                    catMonths = (16 * 12) / 6;
                }
                else if (gender == "f")
                {
                    catMonths = (17 * 12) / 6;
                }
            }
            else if (breed == "American Shorthair")
            {
                if (gender == "m")
                {
                    catMonths = (12 * 12) / 6;
                }
                else if (gender == "f")
                {
                    catMonths = (13 * 12) / 6;
                }
            }
            else if (breed == "Siberian")
            {
                if (gender == "m")
                {
                    catMonths = (11 * 12) / 6;
                }
                else if (gender == "f")
                {
                    catMonths = (12 * 12) / 6;
                }
            }
            else
            {
                Console.WriteLine("{0} is invalid cat!",breed);
            }

            if (catMonths !=0)
            {
                Console.WriteLine("{0} cat months",Math.Floor(catMonths));
            }
        }
    }
}
