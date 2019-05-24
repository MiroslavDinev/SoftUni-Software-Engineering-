namespace _01ListyIterator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class ListyIterator<T>
    {
        private List<T> data;
        private int index;

        public ListyIterator(List<T> data)
        {
            this.data = data;
            this.index = 0;
        }

        public bool Move()
        {
            if(HasNext())
            {
                this.index++;
                return true;
            }

            return false;
        }

        public bool HasNext()
        {
            if(this.index+1<this.data.Count)
            {
                return true;
            }

            return false;
        }

        public void Print()
        {
            if(data.Any())
            {
                Console.WriteLine(data[index]);
            }
            else
            {
                throw new Exception("Invalid Operation!");
            }
        }
    }
}
