using System.Collections.Generic;

namespace _13FamilyTreeEdited
{
    public class Person
    {
        public string Name { get; set; }

        public string Birthday { get; set; }

        public List<Person> Parents { get; set; } = new List<Person>();

        public List<Person> Children { get; set; } = new List<Person>();

        public Person(string input)
        {
            if (input.Contains("/"))
            {
                this.Birthday = input;
            }
            else
            {
                this.Name = input;
            }
        }

        public Person(string name, string birthday)
        {
            this.Name = name;
            this.Birthday = birthday;
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Birthday}";
        }
    }
}
