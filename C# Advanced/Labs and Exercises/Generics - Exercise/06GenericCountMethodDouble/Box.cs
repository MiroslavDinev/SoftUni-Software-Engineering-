namespace _06GenericCountMethodDouble
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Box<T>
    {
        private List<T> data;

        public List<T> Data => this.data;

        public Box()
        {
            this.data = new List<T>();
        }

        public void Add(T element)
        {
            this.data.Add(element);
        }
    }
}
