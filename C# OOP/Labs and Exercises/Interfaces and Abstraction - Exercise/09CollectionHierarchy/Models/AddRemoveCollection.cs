namespace _09CollectionHierarchy.Models
{
    using _09CollectionHierarchy.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class AddRemoveCollection : IAdd, IRemove
    {
        private List<string> data;

        public AddRemoveCollection()
        {
            this.data = new List<string>();
        }

        public int Add(string item)
        {
            this.data.Insert(0, item);
            return 0;
        }

        public string Remove()
        {
            string last = this.data.Last();
            int index = this.data.IndexOf(last);
            this.data.RemoveAt(index);
            return last;
        }
    }
}
