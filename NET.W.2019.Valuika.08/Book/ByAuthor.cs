using System.Collections.Generic;

namespace BookLib
{
    public class ByAuthor : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            return x.Author.CompareTo(y.Author);
        }
    }
}
