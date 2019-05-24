namespace _10CarSalesman
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Car
    {
        public string Model { get; set; }

        public Engine Engine { get; set; }

        public double Weight { get; set; }

        public string Color { get; set; }

        public Car(string model, Engine engine, double weight, string color)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = weight;
            this.Color = color;
        }

        public Car(string model, Engine engine, double weight) : this (model,engine,weight,"n/a")
        {
        }

        public Car(string model, Engine engine, string color) : this (model, engine,-1,color)
        {
        }

        public Car(string model, Engine engine) : this (model,engine,-1,"n/a")
        {
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(this.Model + ":");
            result.AppendLine($"  {this.Engine.Model}:");
            result.AppendLine($"    Power: {this.Engine.Power}");
            result.AppendLine($"    Displacement: {(this.Engine.Displacement == -1 ? "n/a" : this.Engine.Displacement.ToString())}");
            result.AppendLine($"    Efficiency: {this.Engine.Efficinecy}");
            result.AppendLine($"  Weight: {(this.Weight == -1 ? "n/a" : this.Weight.ToString())}");
            result.Append($"  Color: {this.Color}");

            return result.ToString();
        }
    }
}
