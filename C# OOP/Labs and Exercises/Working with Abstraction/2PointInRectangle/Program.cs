using System;
using System.Linq;

namespace _2PointInRectangle
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] sides = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int topLeftX = sides[0];
            int topLeftY = sides[1];
            int bottomRightX = sides[2];
            int bottomRightY = sides[3];

            Rectangle rectangle = new Rectangle(topLeftX, topLeftY, bottomRightX, bottomRightY);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int[] pointCoords = Console.ReadLine().Split().Select(int.Parse).ToArray();

                int x = pointCoords[0];
                int y = pointCoords[1];

                Point point = new Point(x,y);

                Console.WriteLine(rectangle.Contains(point));
            }
        }
    }
}
