namespace _03GenericSwapMethodString
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class GenericBoxList<T>
    {
        private List<T> data;

        public GenericBoxList()
        {
            this.data = new List<T>();
        }

        public List<T> Data => this.data;

        public void Add (T element)
        {
            this.data.Add(element);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            foreach (var item in data)
            {
                result.AppendLine($"{item.GetType()}: {item}");
            }

            return result.ToString().TrimEnd();
        }
    }
}
