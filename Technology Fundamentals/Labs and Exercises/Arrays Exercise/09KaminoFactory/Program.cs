using System;
using System.Linq;

namespace _09KaminoFactorySecondTry
{
    class Program
    {
        static void Main(string[] args)
        {
            int DNALength = int.Parse(Console.ReadLine());

            int length = 0;
            int startIndex = -1;
            int row = 0;
            int currRow = 0;
            int sum = 0;

            int[] DNA = new int[DNALength];

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Clone them!")
                {
                    break;
                }

                int[] currentDNA = line.Split("!", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                currRow++;
                int currSum = 0;

                for (int i = 0; i < currentDNA.Length; i++)
                {
                    if (currentDNA[i]==1)
                    {
                        currSum++;
                    }
                }

                if (currRow ==1)
                {
                    DNA = currentDNA;
                    row = currRow;
                    sum = currSum;
                }

                int currStartIndex = -1;
                int currLength = 0;

                

                for (int i = 0; i < currentDNA.Length; i++)
                {
                    if (currentDNA[i]==1)
                    {
                        currStartIndex = i;
                        currLength++;

                        if (currLength > length)
                        {
                            length = currLength;
                            startIndex = currStartIndex;
                            sum = currSum;
                            row = currRow;
                            DNA = currentDNA;
                        }
                        else if (currLength == length)
                        {
                            if (currStartIndex < startIndex)
                            {
                                length = currLength;
                                startIndex = currStartIndex;
                                sum = currSum;
                                row = currRow;
                                DNA = currentDNA;
                            }
                            else if (currSum > sum)
                            {
                                length = currLength;
                                startIndex = currStartIndex;
                                sum = currSum;
                                row = currRow;
                                DNA = currentDNA;
                            }
                        }
                    }

                    else
                    {
                        currStartIndex = -1;
                        currLength = 0;
                        
                    }
                }
                
            }

            Console.WriteLine($"Best DNA sample {row} with sum: {sum}.");
            Console.WriteLine(string.Join(" ",DNA));
        }
    } // ot videoto dava 100 ot 100
}
