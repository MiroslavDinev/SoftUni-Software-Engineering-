using System;

namespace IteratorsAndComparators
{
    public class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            Book book = new Book("First", 1989, "Author1");
            Book book2 = new Book("Second", 1999, "Gosho");

            library.Add(book);
            library.Add(book2);

            foreach (var currBook in library)
            {
                Console.WriteLine(currBook.Title);
            }
        }
    }
}
