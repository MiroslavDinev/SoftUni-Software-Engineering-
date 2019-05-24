namespace _13FamilyTreeEdited
{
    public class Connection
    {
        public Person Parent { get; set; }
        public Person Children { get; set; }

        public Connection(Person parent, Person children)
        {
            this.Parent = parent;
            this.Children = children;
        }
    }
}
