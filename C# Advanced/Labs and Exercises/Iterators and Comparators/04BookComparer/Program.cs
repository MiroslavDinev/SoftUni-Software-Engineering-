using System;

namespace IteratorsAndComparators
{
    public class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            Book book = new Book("Anumal farm", 2003, "Pesho");
            Book book2 = new Book("The Documents in the Case ", 2002, "Gosho");
            Book book3 = new Book("The Documents in the Case ", 1930, "Ana");

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
