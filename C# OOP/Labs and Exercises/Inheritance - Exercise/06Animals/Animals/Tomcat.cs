namespace Animals.Animals
{
    public class Tomcat : Cat
    {
        private const string tomcatGender = "Male";

        public Tomcat(string name, int age, string gender)
            : base(name,age,tomcatGender)
        {
        }

        public override string ProduceSound()
        {
            return "MEOW";
        }
    }
}
