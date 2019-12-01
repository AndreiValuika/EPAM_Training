using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLib
{
    public class Book:IEquatable<Book>,IComparable,IComparer<Book>
    {
        public Book(string iSBN, string title, string author, string publisher, int pages, int year, float price)
        {
            ISBN = iSBN;
            Title = title;
            Author = author;
            Publisher = publisher;
            Pages = pages;
            Year = year;
            Price = price;
        }

        public string ISBN { get; set; }
        public string  Author { get; set; }
        public string  Title { get; set; }
        public string Publisher { get; set; }
        public int Year { get; set; }
        public int Pages { get; set; }
        public float Price { get; set; }

        public int Compare(Book x, Book y)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(object obj)
        {
            Book second = obj as Book;
            if (this.Equals(second))
            {
                return 0;
            }

            return this.ISBN.CompareTo(second.ISBN);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (obj.GetType() == GetType())
            {
                Book book = obj as Book;
                return this.Equals(book);
            }

            return false;
        }

        public bool Equals(Book other)
        {
            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (this.ISBN.Equals(other.ISBN)&&
                this.Author.Equals(other.Author)&&
                this.Publisher.Equals(other.Publisher)&&
                this.Pages==other.Pages&&
                this.Price.Equals(other.Price))
            {
                return true;
            }

            return false;
        }

        public override int GetHashCode() 
        {
          return  ISBN.GetHashCode() + Author.GetHashCode() + Title.GetHashCode();
        }
        public override string ToString()
        {
            return $"ISBN : {ISBN}, " +
                   $"AuthorName: {Author}," +
                   $" Title: {Title}," +
                   $" Publisher: {Publisher}," +
                   $" Year: {Year}, " +
                   $"Number of pages: {Pages}" +
                   $", Price: {Price}"; 
                   
        }
    }
}
