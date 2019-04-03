using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07Scholarship
{
    class Program
    {
        static void Main(string[] args)
        {
            double income = double.Parse(Console.ReadLine());
            double grade = double.Parse(Console.ReadLine());
            double minWorkSalary = double.Parse(Console.ReadLine());

            double socialScholarship = 0;
            double gradeScholarship = 0;

            if (income > minWorkSalary && grade < 5.50)
            {
                Console.WriteLine("You cannot get a scholarship!");
            }
            else if (income > minWorkSalary && grade >= 5.50)
            {
                gradeScholarship = 25 * grade;
                Console.WriteLine("You get a scholarship for excellent results {0} BGN",Math.Floor(gradeScholarship));
            }
            else if (income < minWorkSalary && (grade > 4.50 && grade < 5.50))
            {
                socialScholarship = minWorkSalary * 0.35;
                Console.WriteLine("You get a Social scholarship {0} BGN",Math.Floor(socialScholarship));
            }
            else if (income < minWorkSalary && grade >=5.50)
            {
                socialScholarship = minWorkSalary * 0.35;
                gradeScholarship = 25 * grade;

                if (socialScholarship > gradeScholarship)
                {
                    Console.WriteLine("You get a Social scholarship {0} BGN",Math.Floor(socialScholarship));
                }
                else if (socialScholarship <= gradeScholarship)
                {
                    Console.WriteLine("You get a scholarship for excellent results {0} BGN", Math.Floor(gradeScholarship));
                }

            }
            else if (grade < 4.50)
            {
                Console.WriteLine("You cannot get a scholarship!");
            }
            else if (grade >= 5.50)
            {
                gradeScholarship = 25 * grade;
                Console.WriteLine("You get a scholarship for excellent results {0} BGN", Math.Floor(gradeScholarship));
            }

        }
    }
}
