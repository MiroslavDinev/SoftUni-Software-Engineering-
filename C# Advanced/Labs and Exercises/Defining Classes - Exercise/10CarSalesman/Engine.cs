namespace _10CarSalesman
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Engine
    {
        public string Model { get; set; }

        public int Power { get; set; }

        public int Displacement { get; set; }

        public string Efficinecy { get; set; }

        public Engine(string model, int power, int displacement, string efficiency)
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = displacement;
            this.Efficinecy = efficiency;
        }

        public Engine(string model, int power, int displacement)
            : this(model,power,displacement,"n/a")
        {
        }

        public Engine(string model, int power, string efficiency)
            : this(model,power,-1,efficiency)
        {
        }

        public Engine(string model, int power) : this(model,power,-1,"n/a")
        {
        }
    }
}
