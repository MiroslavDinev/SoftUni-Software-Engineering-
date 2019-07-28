namespace _02BookShop
{
    using System;
    using System.Text;

    public class Book
    {
        private string author;
        private string title;
        private decimal price;

        public Book(string author, string title, decimal price)
        {
            this.Title = title;
            this.Author = author;
            this.Price = price;
        }

        public string Author
        {
            get
            {
                return this.author;
            }

            private set
            {
                string[] tokens = value.Split();

                string secondName = tokens[1];

                if(string.IsNullOrEmpty(secondName)==false && string.IsNullOrWhiteSpace(secondName))
                {
                    if (char.IsDigit(secondName[0]))
                    {
                        throw new ArgumentException("Author not valid!");
                    }
                }               

                this.author = value;
            }
        }

        public string Title
        {
            get
            {
                return this.title;
            }

            private set
            {
                if(value.Length<3)
                {
                    throw new ArgumentException("Title not valid!");
                }

                this.title = value;
            }
        }

        public virtual decimal Price
        {
            get
            {
                return this.price;
            }

            protected set
            {
                if(value<=0)
                {
                    throw new ArgumentException("Price not valid!");
                }

                this.price = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Type: {this.GetType().Name}");
            result.AppendLine($"Title: {this.Title}");
            result.AppendLine($"Author: {this.Author}");
            result.AppendLine($"Price: {this.Price:f2}");

            return result.ToString().TrimEnd();
        }
    }
}
