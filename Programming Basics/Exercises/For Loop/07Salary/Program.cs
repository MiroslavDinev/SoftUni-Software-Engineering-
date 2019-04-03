using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07Salary
{
    class Program
    {
        static void Main(string[] args)
        {
            int tabs = int.Parse(Console.ReadLine());
            int salary = int.Parse(Console.ReadLine());

            for (int i = 1; i <= tabs; i++)
            {
                string siteName = Console.ReadLine();

                if (siteName == "Facebook")
                {
                    salary -= 150;

                    if (salary <=0)
                    {
                        Console.WriteLine("You have lost your salary.");
                        return;
                    }
                }
                else if (siteName == "Instagram")
                {
                    salary -= 100;

                    if (salary <= 0)
                    {
                        Console.WriteLine("You have lost your salary.");
                        return;
                    }
                }
                else if (siteName == "Reddit")
                {
                    salary -= 50;

                    if (salary <= 0)
                    {
                        Console.WriteLine("You have lost your salary.");
                        return;
                    }
                }
            }
            Console.WriteLine(salary);
        }
    }
}
