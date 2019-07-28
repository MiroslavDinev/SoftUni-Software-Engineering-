namespace _2PointInRectangle
{
    public class Rectangle
    {
        public Rectangle(int topLeftX, int topLeftY, int bottomRightX, int bottomRightY)
        {
            this.TopLeft.X = topLeftX;
            this.TopLeft.Y = topLeftY;
            this.BottomRight.X = bottomRightX;
            this.BottomRight.Y = bottomRightY;
        }

        public Point TopLeft { get; set; } = new Point();

        public Point BottomRight { get; set; } = new Point();

        public bool Contains(Point point)
        {
            bool isInHorizontal = this.TopLeft.X <= point.X
                && this.BottomRight.X >= point.X;

            bool isInVertical = this.TopLeft.Y <= point.Y
                && this.BottomRight.Y >= point.Y;

            bool isInRectangle = isInHorizontal && isInVertical;

            return isInRectangle;
        }
    }
}
