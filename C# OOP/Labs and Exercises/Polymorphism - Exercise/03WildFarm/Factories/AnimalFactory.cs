namespace WildFarmEdited.Factories
{
    using WildFarmEdited.Animals;
    using WildFarmEdited.Animals.Birds;
    using WildFarmEdited.Animals.Mammals;
    using WildFarmEdited.Animals.Mammals.Felines;

    public static class AnimalFactory
    {
        public static Animal Create(string[] animalArgs)
        {
            string animalType = animalArgs[0];
            string animalName = animalArgs[1];
            double animalWeight = double.Parse(animalArgs[2]);

            if(animalType == "Owl")
            {
                double wingSize = double.Parse(animalArgs[3]);

                Owl owl = new Owl(animalName, animalWeight, wingSize);
                return owl;
            }
            else if (animalType == "Hen")
            {
                double wingSize = double.Parse(animalArgs[3]);

                Hen hen = new Hen(animalName, animalWeight, wingSize);
                return hen;
            }
            else if (animalType == "Mouse")
            {
                string livingRegion = animalArgs[3];

                Mouse mouse = new Mouse(animalName, animalWeight, livingRegion);
                return mouse;
            }
            else if (animalType == "Dog")
            {
                string livingRegion = animalArgs[3];

                Dog dog = new Dog(animalName, animalWeight, livingRegion);
                return dog;
            }
            else if (animalType == "Cat")
            {
                string livingRegion = animalArgs[3];
                string breed = animalArgs[4];

                Cat cat = new Cat(animalName, animalWeight, livingRegion, breed);
                return cat;
            }
            else if (animalType == "Tiger")
            {
                string livingRegion = animalArgs[3];
                string breed = animalArgs[4];

                Tiger tiger = new Tiger(animalName, animalWeight, livingRegion, breed);
                return tiger;
            }

            return null;
        }
    }
}
