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
}
