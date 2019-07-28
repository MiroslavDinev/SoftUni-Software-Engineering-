namespace Cars
{
    using System.Text;
    public class Seat : ICar
    {
        public Seat(string model, string color)
        {
            this.Model = model;
            this.Color = color;
        }

        public string Model { get; set; }
        public string Color { get; set; }

        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"{this.Color} {this.GetType().Name} {this.Model}");
            stringBuilder.AppendLine(this.Start());
            stringBuilder.Append(this.Stop());

            return stringBuilder.ToString();
        }
    }
}
