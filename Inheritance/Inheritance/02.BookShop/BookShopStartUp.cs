using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.BookShop
{

    class BookShopStartUp
    {
        static void Main(string[] args)
        {
            try
            {
                string author = Console.ReadLine();
                string title = Console.ReadLine();
                double price = double.Parse(Console.ReadLine());

                Book book = new Book(author, title, price);
                GoldenEditionBook goldenEditionBook = new GoldenEditionBook(author, title, price);

                Console.WriteLine(book);
                Console.WriteLine(goldenEditionBook);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }

    public class Book
    {
        private string title;

        private string author;

        private double price;

        public Book(string author, string title, double price)
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

           protected set
            {
                var splittedInput = value
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (splittedInput.Length > 1)
                {
                    if (char.IsDigit(value.Split()[1][0]))
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
            protected set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Title not valid!");
                }
                this.title = value;
            }
        }

        public virtual double Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Price not valid!");
                }
                this.price = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Type: ").Append(this.GetType().Name)
                    .Append(Environment.NewLine)
                    .Append("Title: ").Append(this.Title)
                    .Append(Environment.NewLine)
                    .Append("Author: ").Append(this.Author)
                    .Append(Environment.NewLine)
                    .Append($"Price: {this.Price:F1}")
                    .Append(Environment.NewLine);

            return sb.ToString();
        }

    }

    public class GoldenEditionBook : Book
    {

        public GoldenEditionBook(string author, string title, double price)
            : base(author, title, price)
        {
        }
        public override double Price
        {
            get
            {
                return base.Price * 1.3;
            }
        }

    }
}
