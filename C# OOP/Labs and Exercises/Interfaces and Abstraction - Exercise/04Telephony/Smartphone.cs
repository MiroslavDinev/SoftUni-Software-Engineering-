namespace _04Telephony
{
    using System;
    using System.Linq;
    public class Smartphone : ICall, IWeb
    {
        public string Browse(string site)
        {
            if(site.Any(x=>char.IsDigit(x)))
            {
                throw new ArgumentException("Invalid URL!");
            }

            return $"Browsing: {site}!";
        }

        public string Call(string number)
        {
            if(number.Any(x=>!char.IsDigit(x)))
            {
                throw new ArgumentException("Invalid number!");
            }

            return $"Calling... {number}";
        }
    }
}
