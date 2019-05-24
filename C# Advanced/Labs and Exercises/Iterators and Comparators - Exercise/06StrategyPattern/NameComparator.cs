using System.Collections.Generic;

namespace _06StrategyPattern
{
    public class NameComparator : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            int nameLen = x.Name.Length.CompareTo(y.Name.Length);

            if(nameLen==0)
            {
                return x.Name.ToLower()[0].CompareTo(y.Name.ToLower()[0]);
            }

            return nameLen;
        }
    }
}
