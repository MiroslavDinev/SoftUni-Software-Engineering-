namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                //DbInitializer.ResetDatabase(db);
                var result = RemoveBooks(db);
                Console.WriteLine(result);

            }
        }
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var ageRestriction = Enum.Parse<AgeRestriction>(command, true);

            var books = context.Books
                .Where(x => x.AgeRestriction == ageRestriction)
                .Select(x => x.Title)
                .OrderBy(x=>x)
                .ToList();

            string result = string.Join(Environment.NewLine, books);
            return result;
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var goldenType = Enum.Parse<EditionType>("Gold");

            var books = context.Books
                .Where(x => x.EditionType == goldenType && x.Copies < 5000)
                .OrderBy(x => x.BookId)
                .Select(x => x.Title)
                .ToList();

            string result = string.Join(Environment.NewLine, books);
            return result;
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Price > 40)
                .Select(x => new
                {
                    Title = x.Title,
                    Price = x.Price
                })
                .OrderByDescending(x => x.Price)
                .ToList();

            string result = string.Join(Environment.NewLine, books.Select(x => $"{x.Title} - ${x.Price:f2}"));
            return result;
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            string result = string.Join(Environment.NewLine, books);
            return result;
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input.ToLower().Split(" ",StringSplitOptions.RemoveEmptyEntries);

            var books = context.Books
                .Where(b => b.BookCategories.Any(c => categories.Contains(c.Category.Name.ToLower())))
                .Select(x => x.Title)
                .OrderBy(x=>x)
                .ToList();

            string result = string.Join(Environment.NewLine, books);
            return result;               
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var dateNeeded = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(b => b.ReleaseDate.Value < dateNeeded)
                .OrderByDescending(x => x.ReleaseDate)
                .Select(x => new
                {
                    x.Title,
                    x.EditionType,
                    x.Price
                })
                .ToList();

            string result = string.Join(Environment.NewLine, books.Select(x => $"{x.Title} - {x.EditionType} - ${x.Price:f2}"));
            return result;
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .Where(x => x.FirstName.EndsWith(input.ToLower()))
                .Select(x => new
                {
                    FullName = x.FirstName + " " + x.LastName
                })
                .OrderBy(x=>x.FullName)
                .ToList();

            string result = string.Join(Environment.NewLine, authors.Select(x=>x.FullName));
            return result;
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(x => x.Title.ToLower().Contains(input.ToLower()))
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToList();

            string result = string.Join(Environment.NewLine, books);
            return result;
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(x => x.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(x => new
                {
                    Title = x.Title,
                    AuthorNames = x.Author.FirstName + " " + x.Author.LastName
                })
                .ToList();

            string result = string.Join(Environment.NewLine, books.Select(x => $"{x.Title} ({x.AuthorNames})"));
            return result;
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var books = context.Books
                .Where(x => x.Title.Length > lengthCheck)
                .ToList();

            int result = books.Count;
            return result;
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context.Authors
                .Select(x => new
                {
                    FullName = x.FirstName + " " + x.LastName,
                    BooksCount = x.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(c => c.BooksCount)
                .ToList();

            string result = string.Join(Environment.NewLine, authors.Select(x => $"{x.FullName} - {x.BooksCount}"));

            return result;               
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categories = context.Categories
                .Select(x => new
                {
                    CategoryName = x.Name,
                    TotalProfit = x.CategoryBooks.Sum(e=>e.Book.Price * e.Book.Copies)
                })
                .OrderByDescending(x=>x.TotalProfit)
                .ThenBy(x => x.CategoryName)
                .ToList();

            string result = string.Join(Environment.NewLine, categories.Select(x => $"{x.CategoryName} ${x.TotalProfit:f2}"));

            return result;
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categories = context.Categories
                .Select(x => new
                {
                    CategoryName = x.Name,
                    Books = x.CategoryBooks
                    .Select(b => new
                    {
                        Title = b.Book.Title,
                        ReleaseDate = b.Book.ReleaseDate
                    })
                    .OrderByDescending(b => b.ReleaseDate)
                    .Take(3)
                    .ToList()
                })
                .OrderBy(c=>c.CategoryName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var category in categories)
            {
                sb.AppendLine($"--{category.CategoryName}");

                foreach (var book in category.Books)
                {
                    sb.AppendLine($"{book.Title} ({book.ReleaseDate.Value.Year})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(x => x.ReleaseDate.Value.Year < 2010)
                .ToList();

            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Copies < 4200)
                .ToArray();

            context.Books.RemoveRange(books);
            var rowsAffected = context.SaveChanges();

            return books.Length;
        }
    }
}
