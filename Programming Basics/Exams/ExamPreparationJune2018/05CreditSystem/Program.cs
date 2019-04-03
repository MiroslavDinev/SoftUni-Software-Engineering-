using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            int courses = int.Parse(Console.ReadLine());

            double avgCredits = 0;
            double avgGrade = 0;

            for (int i = 1; i <= courses; i++)
            {
                int mark = int.Parse(Console.ReadLine());

                int grade = mark % 10;
                int credits = mark / 10;

                if (grade == 2)
                {
                    avgGrade += grade;
                    avgCredits += 0;
                }
                else if (grade == 3)
                {
                    avgGrade += grade;
                    avgCredits += credits * 0.5;
                }
                else if (grade == 4)
                {
                    avgGrade += grade;
                    avgCredits += credits * 0.7;
                }
                else if (grade == 5)
                {
                    avgGrade += grade;
                    avgCredits += credits * 0.85;
                }
                else if (grade == 6)
                {
                    avgGrade += grade;
                    avgCredits += credits * 1;
                }
            }
            Console.WriteLine("{0:f2}",avgCredits);
            Console.WriteLine("{0:f2}",avgGrade/courses);
        }
    }
}
