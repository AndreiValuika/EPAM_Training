using System.Collections.Generic;

namespace BookLib
{
    public class ByPublisher : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            return x.Publisher.CompareTo(y.Publisher);
        }
    }
}
