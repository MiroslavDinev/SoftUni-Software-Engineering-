using System;

namespace IteratorsAndComparators
{
    public class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            Book book = new Book("Amazing", 2005, "Pesho");
            Book book2 = new Book("Blazing", 2005, "Gosho");
            Book book3 = new Book("Whatever", 2018, "Ana");

            library.Add(book);
            library.Add(book2);
            library.Add(book3);

            foreach (var currBook in library)
            {
                Console.WriteLine(currBook);
            }
        }
    }
}
