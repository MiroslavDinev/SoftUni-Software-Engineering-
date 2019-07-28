using System;
using System.Collections.Generic;
using System.Text;

namespace _03Ferrari
{
    public class Ferrari : ICar
    {
        private string model; 
        private string driver;

        public Ferrari(string driver)
        {
            this.model = "488-Spider";
            this.Driver = driver;
        }

        public string Driver { get => driver; private set => this.driver = value; }

        public string Brakes()
        {
            return "Brakes!";
        }

        public string GasPedal()
        {
            return "Gas!";
        }

        public override string ToString()
        {
            return $"{this.model}/{this.Brakes()}/{this.GasPedal()}/{this.Driver}";
        }
    }
}
