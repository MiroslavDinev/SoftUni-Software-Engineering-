using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace _08MatchPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string reg = @"(\+359([ -])2(\2)(\d{3})(\2)(\d{4}))\b";

            string phones = Console.ReadLine();

            var phoneMatches = Regex.Matches(phones, reg);

            var matchedPhones = phoneMatches.Cast<Match>().Select(x => x.Value.Trim()).ToArray();

            Console.WriteLine(string.Join(", ",matchedPhones));

            //string phoneString = Console.ReadLine();
            //Regex validPhonesPatter = new Regex(@"(\+359([ -])2(\2)(\d{3})(\2)(\d{4}))\b");

            //MatchCollection phoneCollection = validPhonesPatter.Matches(phoneString);
            //List<string> phoneList = new List<string>();

            //foreach (var phone in phoneCollection)
            //{
            //    phoneList.Add(phone.ToString());
            //}

            //Console.WriteLine(string.Join(", ", phoneList))
        }
    }
}
