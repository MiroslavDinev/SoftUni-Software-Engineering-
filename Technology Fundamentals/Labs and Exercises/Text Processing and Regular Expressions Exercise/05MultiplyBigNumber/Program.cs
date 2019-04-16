using System;
using System.Text;

namespace _05MultiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            if (text.Length > 1)
            {
                text = text.TrimStart('0');
            }
            else if (text.Length==1)
            {
                int firstNum = int.Parse(text);
                if (firstNum == 0)
                {
                    Console.WriteLine(0);
                    return;
                }
            }
            int multiplyer = int.Parse(Console.ReadLine());

            if (multiplyer==0)
            {
                Console.WriteLine(0);
                return;
            }
            

            StringBuilder result = new StringBuilder();
            int onMind = 0;

            for (int i = text.Length - 1; i >= 0; i--)
            {
                char currSymbol = text[i];
                int symbolAsInt = int.Parse(currSymbol.ToString());

                int multResult = symbolAsInt * multiplyer + onMind;
              
                int lastDigit = multResult % 10;
                int firstDigit = multResult / 10;
                result.Append(lastDigit);
                onMind = firstDigit;
    
            }

            if (onMind>0)
            {
                result.Append(onMind);
            }


            StringBuilder answer = new StringBuilder();

            for (int i = result.Length - 1; i >= 0; i--)
            {
                answer.Append(result[i]);
            }

            Console.WriteLine(answer.ToString());
        }
    }
}
