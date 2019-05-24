namespace _08RawData
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Tire
    {
        public int Year { get; set; }

        public double Pressure { get; set; }

        public Tire(double pressure, int year)
        {
            this.Pressure = pressure;
            this.Year = year;
        }
    }
}
