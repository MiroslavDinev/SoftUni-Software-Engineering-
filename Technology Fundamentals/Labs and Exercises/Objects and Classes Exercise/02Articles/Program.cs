using System;
using System.Linq;

namespace _02Articles
{
    public class Article
    {
        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public void Edit (string newContent)
        {
            Content = newContent;
        }

        public void ChangeAuthor (string newAuthor)
        {
            Author = newAuthor;
        }

        public void Rename (string newTitle)
        {
            Title = newTitle;
        }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}".ToString();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");
            string title = input[0];
            string content = input[1];
            string author = input[2];

            int n = int.Parse(Console.ReadLine());

            Article article = new Article(title, content, author);

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(": ");
                string action = command[0];

                if (action == "Edit")
                {
                    string newContent = command[1];

                    article.Edit(newContent);
                }
                else if (action == "ChangeAuthor")
                {
                    string newAuthor = command[1];
                    article.ChangeAuthor(newAuthor);
                }
                else if (action == "Rename")
                {
                    string newTitle = command[1];
                    article.Rename(newTitle);
                }
            }

            Console.WriteLine(article);
        }
    }
}
