namespace _03Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class Stack<T> : IEnumerable<T>
    {
        private List<T> data;

        public List<T> Data { get; set; } = new List<T>();

        public Stack()
        {
            this.data = Data;
        }

        public void Push(T element)
        {
            this.data.Add(element);
        }

        public void Pop()
        {
            if (this.data.Any())
            {
                T last = this.data.Last();
                int indexOfLast = this.data.IndexOf(last);
                this.data.RemoveAt(indexOfLast);
            }
            else
            {
                throw new Exception("No elements");
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.data.Count - 1; i >= 0; i--)
            {
                yield return this.data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
