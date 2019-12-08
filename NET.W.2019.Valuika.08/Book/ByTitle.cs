using System.Collections.Generic;

namespace BookLib
{
    public class ByTitle : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            return x.Title.CompareTo(y.Title);
        }
    }
}
