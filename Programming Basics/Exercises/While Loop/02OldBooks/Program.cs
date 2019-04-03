using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02OldBooks
{
    class Program
    {
        static void Main(string[] args)
        {
            string bookName = Console.ReadLine();
            int capacity = int.Parse(Console.ReadLine());

            int counter = 0;

            while (capacity>0)
            {
                string currBook = Console.ReadLine();

                counter++;
                capacity--;

                if (currBook == bookName)
                {
                    Console.WriteLine("You checked {0} books and found it.",counter-1);
                    return;
                }
            }
            Console.WriteLine("The book you search is not here!");
            Console.WriteLine("You checked {0} books.",counter);
        }
    }
}
