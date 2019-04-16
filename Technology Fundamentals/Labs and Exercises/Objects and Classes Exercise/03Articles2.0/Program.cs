using System;
using System.Collections.Generic;
using System.Linq;

namespace _03Articles2._0
{
    public class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}".ToString();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Article> articles = new List<Article>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(", ");

                string title = input[0];
                string content = input[1];
                string author = input[2];

                Article article = new Article
                {
                    Title = title,
                    Content = content,
                    Author = author
                };

                articles.Add(article);
            }

            string condition = Console.ReadLine();

            if (condition == "title")
            {
                var filtered = articles.OrderBy(x => x.Title);
                Console.WriteLine(string.Join(Environment.NewLine,filtered));
            }
            else if (condition == "content")
            {
                var filtered = articles.OrderBy(x => x.Content);
                Console.WriteLine(string.Join(Environment.NewLine,filtered));
            }
            else
            {
                var filtered = articles.OrderBy(x => x.Author);
                Console.WriteLine(string.Join(Environment.NewLine,filtered));
            }
        }
    }
}
