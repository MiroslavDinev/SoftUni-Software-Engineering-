namespace WildFarmEdited.Animals.Birds
{
    using System.Collections.Generic;
    using WildFarmEdited.Foods;
    public class Owl : Bird
    {
        private const double gainWeight = 0.25;
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override string AskFood()
        {
            return "Hoot Hoot";
        }

        public override void Eat(Food food)
        {
            base.BaseEat(food, new List<string> { nameof(Meat) }, gainWeight);
        }
    }
}
