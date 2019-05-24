namespace _09RectangleIntersection
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Rectangle
    {
        public string Id { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }

        public double[] TopLeft { get; set; }

        public Rectangle(string id, double width, double height, double[]topleft)
        {
            this.Id = id;
            this.Width = width;
            this.Height = height;
            this.TopLeft = new double[] { topleft[0], topleft[1] };
        }

        public bool Intersect (Rectangle rectangle1, Rectangle rectangle2)
        {
            bool intersect = false;

            if (Math.Abs(rectangle1.TopLeft[0])<Math.Abs(rectangle2.TopLeft[0]+rectangle2.Width))
            {
                if (Math.Abs(rectangle1.TopLeft[0] + rectangle1.Width) >= Math.Abs(rectangle2.TopLeft[0]))
                {
                    if (rectangle1.TopLeft[1]<Math.Abs(rectangle2.TopLeft[1]-rectangle2.Height))
                    {
                        if (Math.Abs(rectangle1.TopLeft[1]+rectangle1.Height)>= Math.Abs(rectangle2.TopLeft[1]))
                        {
                            intersect = true;
                        }
                    }
                }
            }

            return intersect;
        }
    }
}
