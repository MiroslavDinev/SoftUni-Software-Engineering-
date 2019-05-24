namespace _05ComparingObjects
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Person : IComparable<Person>
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Town { get; set; }

        public Person(string name, int age, string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }

        public int CompareTo(Person other)
        {
            int nameResult = this.Name.CompareTo(other.Name);

            if(nameResult == 0)
            {
                int ageResult = this.Age - other.Age;

                if(ageResult == 0)
                {
                    return this.Town.CompareTo(other.Town);
                }

                return ageResult;
            }

            return nameResult;
        }
    }
}
