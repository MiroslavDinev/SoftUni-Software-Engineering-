using System;

namespace _04Telephony
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Smartphone smartphone = new Smartphone();

            string[] phoneNums = Console.ReadLine().Split();

            foreach (var num in phoneNums)
            {
                try
                {
                    Console.WriteLine(smartphone.Call(num));
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }

            string[] urls = Console.ReadLine().Split();

            foreach (var url in urls)
            {
                try
                {
                    Console.WriteLine(smartphone.Browse(url));
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
