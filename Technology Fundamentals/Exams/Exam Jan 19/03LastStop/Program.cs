using System;
using System.Linq;
using System.Collections.Generic;

namespace _03LastStop
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> paintings = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "END")
                {
                    break;
                }

                string[] tokens = command.Split();

                string action = tokens[0];

                if (action == "Change")
                {
                    int paintingNum = int.Parse(tokens[1]);
                    int changedNum = int.Parse(tokens[2]);

                    if (paintings.Contains(paintingNum))
                    {
                        int index = paintings.IndexOf(paintingNum);
                        paintings.Remove(paintingNum);
                        paintings.Insert(index, changedNum);
                    }
                }
                else if (action == "Hide")
                {
                    int paintingNum = int.Parse(tokens[1]);

                    if (paintings.Contains(paintingNum))
                    {
                        paintings.Remove(paintingNum);
                    }
                }
                else if (action == "Switch")
                {
                    int paintingNum = int.Parse(tokens[1]);
                    int paintingNum2 = int.Parse(tokens[2]);

                    if (paintings.Contains(paintingNum) && paintings.Contains(paintingNum2))
                    {
                        int firstIndex = paintings.IndexOf(paintingNum);
                        int secondIndex = paintings.IndexOf(paintingNum2);

                        paintings.Remove(paintingNum);
                        paintings.Insert(firstIndex, paintingNum2);

                        paintings.RemoveAt(secondIndex);
                        paintings.Insert(secondIndex, paintingNum);
                    }
                }

                else if (action == "Insert")
                {
                    int index = int.Parse(tokens[1]);
                    int place = index + 1;
                    int paintingNum = int.Parse(tokens[2]);

                    if (place<0 || place>paintings.Count-1)
                    {
                        continue;
                    }

                    paintings.Insert(place, paintingNum);
                }
                else if (action == "Reverse")
                {
                    paintings.Reverse();
                }
            }

            Console.WriteLine(string.Join(" ",paintings));
        }
    }
}
