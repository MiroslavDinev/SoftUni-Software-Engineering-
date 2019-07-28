﻿namespace _08MilitaryElite.Models.Privates
{
    using _08MilitaryElite.Contracts.Privates;
    using System;
    using System.Text;

    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {

        private string corps;
        public SpecialisedSoldier(string id,string firstName, string lastName, decimal salary, string corps) 
            : base(id, firstName , lastName , salary)
        {
            this.Corps = corps;
        }
        public string Corps
        {
            get
            {
                return this.corps;
            }

            private set
            {
                if(value!= "Airforces" && value!= "Marines")
                {
                    throw new ArgumentException();
                }

                this.corps = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Corps: {this.Corps}");
            return sb.ToString().TrimEnd();
        }
    }
}
