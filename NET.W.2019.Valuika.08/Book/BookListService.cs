using System;
using System.Collections.Generic;

namespace BookLib
{
    public class BookListService
    {
        private BookListStorage _bookStorage;
        private ICollection<Book> _books;

        public BookListService(BookListStorage bookListStorage)
        {
            _bookStorage = bookListStorage;
            _books = bookListStorage.GetAll();
        }

        public void AddBook(Book book)
        {
            foreach (var item in _books)
            {
                if (item.Equals(book))
                {
                    throw new ArgumentException("Already exists");
                }
            }

            _bookStorage.Add(book);
        }

        public void RemoveBook(Book book)
        {
            if (!_bookStorage.Remove(book))
            {
                throw new ArgumentException("Not found");
            }
        }

        public ICollection<Book> Sort(IComparer<Book> comparer)
        {
            ((List<Book>)_books).Sort(comparer);
            return _books;
        }

        public Book FindByTag(Filter filter)
        {
            foreach (var item in _bookStorage.GetAll())
            {
                if (filter.IsEquals(item))
                {
                    return item;
                }
            }

            throw new ArgumentException("Not found");
        }

        public ICollection<Book> GetAll()
        {
            return _books;
        }

        public void Save()
        {
            _bookStorage.Save();
        }

        public void Load()
        {
            _bookStorage.Load();
        }
    }
}
