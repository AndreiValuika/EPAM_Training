using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLib
{
    public class Filter
    {
        public Filter(string iSBN="", string author="", string title="", string publisher="",
                      int year=-1, int pages=-1, float price=-1)
        {
            ISBN = iSBN;
            Author = author;
            Title = title;
            Publisher = publisher;
            Year = year;
            Pages = pages;
            Price = price;
        }

        public string ISBN { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public int Year { get; set; }
        public int Pages { get; set; }
        public float Price { get; set; }

        public bool IsEquals(Book book) 
        {
            if (!string.IsNullOrEmpty(this.ISBN) &&
                !this.ISBN.Equals(book.ISBN))
            {
                return false;
            }

            if (!string.IsNullOrEmpty(this.Author) &&
                !this.Author.Equals(book.Author))
            {
                return false;
            }

            if (!string.IsNullOrEmpty(this.Title) &&
                !this.Title.Equals(book.Title))
            {
                return false;
            }

            if (!string.IsNullOrEmpty(this.Publisher) && 
                !this.Publisher.Equals(book.Publisher))
            {
                return false;
            }

            if ((this.Year>0) && this.Year!=book.Year)
            {
                return false;
            }

            if ((this.Pages>0) && this.Pages!=book.Pages)
            {
                return false;
            }

            if ((this.Price > 0) && this.Price != book.Price)
            {
                return false;
            }

            return true;
        }
    }
}
