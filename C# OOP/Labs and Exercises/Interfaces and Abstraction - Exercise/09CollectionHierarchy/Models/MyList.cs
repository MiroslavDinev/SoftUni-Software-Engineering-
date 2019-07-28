namespace _09CollectionHierarchy.Models
{
    using _09CollectionHierarchy.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class MyList : IAdd, IRemove
    {
        private List<string> data;

        public MyList()
        {
            this.data = new List<string>();
        }

        public int Used
        {
            get
            {
                return this.data.Count;
            }
        }

        public int Add(string item)
        {
            this.data.Insert(0, item);
            return 0;
        }

        public string Remove()
        {
            string first = this.data.First();
            int index = this.data.IndexOf(first);
            this.data.RemoveAt(index);
            return first;
        }
    }
}
