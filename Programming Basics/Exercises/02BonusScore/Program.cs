using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02BonusScore
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            double bonus = 0;
            int addBonus = 0;
            double total = 0;

            if (num <=100)
            {
                bonus += 5;
            }
            else if (num >100 && num <=1000)
            {
                bonus = bonus + (num * 0.20);
            }
            else if (num >1000)
            {
                bonus = bonus + (num * 0.10);
            }
            if (num %2==0)
            {
                addBonus += 1;
            }
            else if (num %10 ==5)
            {
                addBonus += 2;
            }
            total = num + bonus + addBonus;
            double bonusSum = bonus + addBonus;
            Console.WriteLine(bonusSum);
            Console.WriteLine(total);

        }
    }
}
