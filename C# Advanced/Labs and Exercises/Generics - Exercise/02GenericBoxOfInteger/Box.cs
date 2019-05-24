namespace _01GenericBoxOfString
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Box<T>
    {
        private T value;

        public Box(T element)
        {
            this.value = element;
        }

        public override string ToString()
        {
            return $"{value.GetType()}: {value}";    
        }
    }
}
