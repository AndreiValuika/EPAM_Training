using System.Collections.Generic;

namespace BookLib
{
    public class ByYear : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            return x.Year.CompareTo(y.Year);
        }
    }
}
