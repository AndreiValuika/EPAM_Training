using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLib
{
    interface IBookService
    {
        bool AddBook(Book book);
        bool RemoveBook(Book book);
        Book FindBookByTag(string tag);
        IList<Book> SortBooksByTag(string tag);
        IList<Book> SortByISBN();
    }
}
