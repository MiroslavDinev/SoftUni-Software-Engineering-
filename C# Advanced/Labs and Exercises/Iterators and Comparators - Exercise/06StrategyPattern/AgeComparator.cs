namespace _06StrategyPattern
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class AgeComparator : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            return x.Age - y.Age;
        }
    }
}
