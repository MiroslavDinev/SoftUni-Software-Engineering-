namespace Repository
{
    using System.Collections.Generic;
    public class Repository
    {
        private Dictionary<int, Person> data;
        private int IdCounter = 0;

        public Repository()
        {
            this.data = new Dictionary<int, Person>();
        }

        public int Count
        {
            get
            {
                return this.data.Count;
            }
        }

        public void Add(Person person)
        {
            this.data.Add(IdCounter,person);
            IdCounter++;
        }

        public Person Get(int id)
        {
            Person person = this.data[id];
            return person;
        }

        public bool Update(int id, Person newPerson)
        {
            if(this.data.ContainsKey(id))
            {
                this.data[id] = newPerson;
                return true;
            }

            return false;
        }

        public bool Delete(int id)
        {
            if (this.data.ContainsKey(id))
            {
                this.data.Remove(id);
                return true;
            }

            return false;
        }
    }
}
