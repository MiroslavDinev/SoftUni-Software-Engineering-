namespace _04Froggy
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    public class Lake : IEnumerable<int>
    {
        private List<int> data;
        public List<int> Data { get; set; } = new List<int>();

        public Lake()
        {
            this.data = Data;
        }

        public void Add(int element)
        {
            this.data.Add(element);
        }
        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this.data.Count; i++)
            {
                if(i%2==0)
                {
                    yield return this.data[i];
                }
                
            }

            int reversedIndexToStart = 0;

            if(this.data.Count%2==0)
            {
                reversedIndexToStart = this.data.Count - 1;
            }
            else
            {
                reversedIndexToStart = this.data.Count - 2;
            }

            for (int i = reversedIndexToStart; i >= 0; i-=2)
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
