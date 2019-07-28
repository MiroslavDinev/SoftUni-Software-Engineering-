namespace _06BirthdayCelebrations
{
    public class Citizen : IId,IBirthdate
    {
        public Citizen(string name,int age, string id, string birthday)
        {
            this.Name = name;
            this.Age = age;
            this.ID = id;
            this.Birthday = birthday;
        }

        public string ID  {get; private set;}

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Birthday { get; private set; }
    }
}
