namespace WildFarmEdited.Animals.Birds
{
    using System.Collections.Generic;
    using WildFarmEdited.Foods;
    public class Hen : Bird
    {
        private const double gainWeight = 0.35;
        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override string AskFood()
        {
            return "Cluck";
        }

        public override void Eat(Food food)
        {
            base.BaseEat(food, new List<string> { nameof(Fruit), nameof(Meat), nameof(Seeds), nameof(Vegetable)}, gainWeight);
        }
    }
}
