namespace MXGP.Models.Motorcycles
{
    using System;
    public class PowerMotorcycle : Motorcycle
    {
        private const double InitialCubicCentimeters = 450;
        private int horsePower;
        public PowerMotorcycle(string model, int horsePower) 
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
                if(value<70 || value>100)
                {
                    throw new ArgumentException($"Invalid horse power: {value}.");
                }

                this.horsePower = value;
            }
        }
    }
}
