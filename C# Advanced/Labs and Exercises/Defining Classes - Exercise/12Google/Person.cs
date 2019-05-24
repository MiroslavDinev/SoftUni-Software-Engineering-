namespace _12Google
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Person
    {
        public string Name { get; set; }

        public Company Company { get; set; }

        public Car Car { get; set; }

        public List<Parent> Parents { get; set; } = new List<Parent>();

        public List<Children> Childrens { get; set; } = new List<Children>();

        public List<Pokemon> Pokemons { get; set; } = new List<Pokemon>();

        public Person(string name)
        {
            this.Name = name;
        }

        //public override string ToString()
        //{
        //    StringBuilder result = new StringBuilder();

        //    result.AppendLine(this.Name);
        //    result.AppendLine("Company:");
        //    if (this.CompanyName!=null)
        //    {
        //        result.AppendLine($"{this.CompanyName} {this.Department} {this.Salary:f2}");
        //    }            
        //    result.AppendLine("Car:");
        //    if (this.Car.Model!=null)
        //    {
        //        result.AppendLine($"{this.Car.Model} {this.Car.Speed}");
        //    }           
        //    result.AppendLine("Pokemon:");
        //    if (this.Pokemons.Count>0)
        //    {
        //        result.AppendLine($"{string.Join(Environment.NewLine, Pokemons)}");
        //    }           
        //    result.AppendLine("Parents:");
        //    if (this.Parents.Count>0)
        //    {
        //        result.AppendLine($"{string.Join(Environment.NewLine, Parents)}");
        //    }          
        //    result.AppendLine("Children:");
        //    if (this.Childrens.Count>0)
        //    {
        //        result.AppendLine($"{string.Join(Environment.NewLine, Childrens)}");
        //    }
            
        //    return result.ToString();
        //}
    }
}
