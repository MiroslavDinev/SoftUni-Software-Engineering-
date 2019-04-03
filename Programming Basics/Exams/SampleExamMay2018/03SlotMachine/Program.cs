using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            char n = char.Parse(Console.ReadLine());
            int n1 = int.Parse(Console.ReadLine());
            char m = char.Parse(Console.ReadLine());
            int m1 = int.Parse(Console.ReadLine());
            char k = char.Parse(Console.ReadLine());
            int k1 = int.Parse(Console.ReadLine());

            int symbol1 = (int)n +n1;
            char digit1 = (char)symbol1;
            int symbol2 = (int)m + m1;
            char digit2 = (char)symbol2;
            int symbol3 = (int)k + k1;
            char digit3 = (char)symbol3;

            if (digit1 == '7' && digit2 == '7' && digit3 == '7')
            {
                Console.WriteLine("*** JACKPOT ***");
            }
            else if (digit1 == '@' && digit2 == '@' && digit3 == '@')
            {
                Console.WriteLine("!!! YOU LOSE EVERYTHING !!!");
            }
            else
            {
                Console.WriteLine("{0}{1}{2}",digit1,digit2,digit3);
            }
        }
    }
}
