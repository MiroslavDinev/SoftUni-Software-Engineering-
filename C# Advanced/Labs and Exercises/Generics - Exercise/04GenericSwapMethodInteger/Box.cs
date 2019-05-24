namespace _04GenericSwapMethodInteger
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Box<T>
    {
        private List<T> data;

        public List<T> Data
        {
            get
            {
                return this.data;
            }
        }

        public Box()
        {
            this.data = new List<T>();
        }

        public void Add(T element)
        {
            this.data.Add(element);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var item in this.data)
            {
                stringBuilder.AppendLine($"{item.GetType()}: {item}");
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
