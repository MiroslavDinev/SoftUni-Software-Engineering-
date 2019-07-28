namespace P01_RawData
{
    public class Tire
    {
        private int age;

        public Tire(double pressure,int age)
        {
            this.age = age;
            this.Pressure = pressure;
        }

        public double Pressure { get; private set; }
    }
}
