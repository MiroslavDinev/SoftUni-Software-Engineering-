namespace MXGP.Models.Motorcycles
{
    using System;
    public class SpeedMotorcycle : Motorcycle
    {
        private const double InitialCubicCentimeters = 125;
        private int horsePower;
        public SpeedMotorcycle(string model, int horsePower) 
            : base(model, horsePower, InitialCubicCentimeters)
        {
        }

        public override int HorsePower
        {
            get
            {
                return this.horsePower;
            }
            protected set
            {
                if(value<50 || value>69)
                {
                    throw new ArgumentException($"Invalid horse power: {value}.");
                }

                this.horsePower = value;
            }
        }
    }
}
