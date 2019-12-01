using System.Collections.Generic;

namespace BookLib
{
    public class ByISBN : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            return x.ISBN.CompareTo(y.ISBN);
        }
    }

    public class ByTitle : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            return x.Title.CompareTo(y.Title);
        }
    }
    public class ByPublisher : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            return x.Publisher.CompareTo(y.Publisher);
        }
    }

    public class ByAuthor : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            return x.Author.CompareTo(y.Author);
        }
    }

    public class ByPages : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            return x.Pages.CompareTo(y.Pages);
        }
    }

    public class ByYear : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            return x.Year.CompareTo(y.Year);
        }
    }

    public class ByPrice : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            return x.Price.CompareTo(y.Price);
        }
    }

}
