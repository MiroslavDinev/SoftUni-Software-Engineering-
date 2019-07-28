using System;

namespace Shapes
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int raidus = int.Parse(Console.ReadLine());
            Circle circle = new Circle(raidus);

            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            Rectangle rectangle = new Rectangle(width, height);

            circle.Draw();
            rectangle.Draw();
        }
    }
}
