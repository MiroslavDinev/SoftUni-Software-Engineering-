using System.Collections.Generic;
using WildFarmEdited.Foods;

namespace WildFarmEdited.Animals.Mammals.Felines
{
    public class Cat : Feline
    {

        private const double gainWeight = 0.30;
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override string AskFood()
        {
            return "Meow";
        }

        public override void Eat(Food food)
        {
            base.BaseEat(food, new List<string> { nameof(Meat), nameof(Vegetable) }, gainWeight);
        }
    }
}
