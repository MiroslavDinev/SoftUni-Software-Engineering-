namespace CustomRandomList
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class RandomList : List<string>
    {
        private Random rand;

        public RandomList() 
        {
            this.rand = new Random();
        }
        public string RandomString()
        {
            int index = this.rand.Next(0, this.Count);
            string element = this[index];
            this.RemoveAt(index);
            return element;
        }
    }
}
