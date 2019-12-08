using System.Collections.Generic;

namespace BookLib
{
    public class ByPrice : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            return x.Price.CompareTo(y.Price);
        }
    }
}
