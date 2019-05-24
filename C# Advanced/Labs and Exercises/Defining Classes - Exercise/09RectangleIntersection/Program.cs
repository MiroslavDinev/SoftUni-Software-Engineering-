using System;
using System.Linq;
using System.Collections.Generic;

namespace _09RectangleIntersection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int numRectangles = input[0];
            int numChecks = input[1];

            List<Rectangle> rectangles = new List<Rectangle>();

            for (int i = 0; i < numRectangles; i++)
            {
                string[] data = Console.ReadLine().Split();
                string id = data[0];
                int width = int.Parse(data[1]);
                int height = int.Parse(data[2]);
                double[] topLeft = new double[] { double.Parse(data[3]), double.Parse(data[4]) };

                Rectangle rectangle = new Rectangle(id, width, height, topLeft);

                rectangles.Add(rectangle);
            }

            for (int i = 0; i < numChecks; i++)
            {
                string[] ids = Console.ReadLine().Split();
                string id1 = ids[0];
                string id2 = ids[1];

                Rectangle first = rectangles.Where(x => x.Id == id1).FirstOrDefault();
                Rectangle second = rectangles.Where(x => x.Id == id2).FirstOrDefault();

                bool intersect=first.Intersect(first, second);

                if (intersect)
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
            }
        }
    }
}
