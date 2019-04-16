using System;
using System.Linq;
using System.Text;

namespace _10RageQuit
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToUpper();
            string repetitions = string.Empty;
            string toRepeat = string.Empty;
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                char curr = input[i];

                if (char.IsDigit(curr))
                {
                    repetitions += curr;

                    if (i < input.Length - 1 && char.IsDigit(input[i + 1]))
                    {
                        repetitions += input[i + 1];
                    }

                    int nums = int.Parse(repetitions);

                    if (nums == 0)
                    {
                        repetitions = string.Empty;
                        toRepeat = string.Empty;
                    }


                    else
                    {
                        for (int j = 0; j < nums; j++)
                        {
                            result.Append(toRepeat);

                            if (j == nums - 1)
                            {
                                repetitions = string.Empty;
                                toRepeat = string.Empty;
                            }
                        }
                    }


                }
                else
                {
                    toRepeat += curr;

                }
            }

            int counter = result.ToString().Distinct().Count();
            Console.WriteLine("Unique symbols used: {0}", counter);
            Console.WriteLine(result);
        }
    }
}
