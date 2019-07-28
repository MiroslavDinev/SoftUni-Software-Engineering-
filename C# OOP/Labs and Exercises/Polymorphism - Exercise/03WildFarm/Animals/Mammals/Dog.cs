namespace WildFarmEdited.Animals.Mammals
{
    using System.Collections.Generic;
    using WildFarmEdited.Foods;
    public class Dog : Mammal
    {
        private const double gainWeight = 0.40;
        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override string AskFood()
        {
            return "Woof!";
        }

        public override void Eat(Food food)
        {
            base.BaseEat(food, new List<string> { nameof(Meat) }, gainWeight);
        }
    }
}
