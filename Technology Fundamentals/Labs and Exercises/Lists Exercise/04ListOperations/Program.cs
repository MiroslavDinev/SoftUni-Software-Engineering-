using System;
using System.Linq;
using System.Collections.Generic;

namespace _04ListOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (true)
            {
                string operations = Console.ReadLine();

                if (operations=="End")
                {
                    break;
                }

                string[] tokens = operations.Split();

                string command = tokens[0];

                if (command=="Add")
                {
                    int number = int.Parse(tokens[1]);
                    numbers.Add(number);
                }
                else if (command == "Insert")
                {
                    int number = int.Parse(tokens[1]);
                    int index = int.Parse(tokens[2]);

                    if (index<0 || index>numbers.Count-1)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }

                    numbers.Insert(index, number);
                }
                else if (command=="Remove")
                {
                    int index = int.Parse(tokens[1]);

                    if (index < 0 || index > numbers.Count - 1)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }

                    numbers.RemoveAt(index);
                }
                else if (command=="Shift")
                {
                    string direction = tokens[1];
                    int count = int.Parse(tokens[2]);

                    if (direction=="left")
                    {
                        for (int i = 0; i < count; i++)
                        {
                            int firstNum = numbers[0];

                            for (int j = 0; j < numbers.Count-1; j++)
                            {
                                numbers[j] = numbers[j + 1];
                            }

                            numbers[numbers.Count - 1] = firstNum;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < count; i++)
                        {
                            int lastNum = numbers[numbers.Count - 1];

                            for (int j = numbers.Count - 1; j > 0; j--)
                            {
                                numbers[j] = numbers[j - 1];
                            }

                            numbers[0] = lastNum;
                        }
                    }
                }
            }
            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
