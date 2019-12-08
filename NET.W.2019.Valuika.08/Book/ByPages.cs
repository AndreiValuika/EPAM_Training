using System.Collections.Generic;

namespace BookLib
{
    public class ByPages : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            return x.Pages.CompareTo(y.Pages);
        }
    }
}
