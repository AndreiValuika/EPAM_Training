using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLib
{
    class BookListService:IBookService
    {
        private readonly BookListStorage bookList;

        public bool AddBook(Book book) 
        {
            bookList.Add(book);
            return true; 
        }

        public bool RemoveBook(Book book) 
        {
            bookList.Remove(book);
            return true;
        }

        public Book FindBookByTag(string tag) 
        {
            return null;
        }

        public IList<Book> SortBooksByTag(string tag) 
        {
            return null;
        }

        public IList<Book> SortByISBN()
        {
            throw new NotImplementedException();
        }
    }
}
