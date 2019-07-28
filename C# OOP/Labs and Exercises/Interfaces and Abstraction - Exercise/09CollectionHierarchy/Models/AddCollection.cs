namespace _09CollectionHierarchy.Models
{
    using _09CollectionHierarchy.Contracts;
    using System.Collections.Generic;
    public class AddCollection : IAdd
    {
        private List<string> data;

        public AddCollection()
        {
            this.data = new List<string>();
        }

        public int Add(string item)
        {
            this.data.Add(item);
            return this.data.Count - 1;
        }
    }
}
