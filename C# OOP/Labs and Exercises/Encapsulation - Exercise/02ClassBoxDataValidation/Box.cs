using System;

namespace _02ClassBoxDataValidation
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get
            {
                return this.length;
            }
            private set
            {
                if(value<=0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }

                this.length = value;
            }
        }

        public double Width
        {
            get => this.width;

            private set
            {
                if(value<=0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get => this.height;

            private set
            {
                if(value<=0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }

                this.height = value;
            }
        }

        public double CalculateSurfaceArea ()
        {
            return 2 * (this.length * this.Width + this.length * this.Height + this.Width * this.Height);
        }

        public double CalculateLateralSurfaceArea()
        {
            return 2 * (this.length * this.Height + this.Width * this.Height);
        }

        public double CalculateVolume()
        {
            return this.length * this.Width * this.Height;
        }
    }
}
