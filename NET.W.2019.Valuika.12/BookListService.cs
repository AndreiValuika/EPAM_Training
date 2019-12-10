using System;
using System.Collections.Generic;

namespace BookLib
{
    public class BookListService
    {
        private readonly BookListStorage _bookStorage;
        private readonly ICollection<Book> _books;
        private readonly ILogger _logger;

        public BookListService(BookListStorage bookListStorage, ILogger logger)
        {
            _bookStorage = bookListStorage;
            _books = bookListStorage.GetAll();
            _logger = logger;
        }

        public void AddBook(Book book)
        {
            _logger.Debug($"Try AddBook {book}");
            foreach (var item in _books)
            {
                if (item.Equals(book))
                {
                    _logger.Error($"Book ISBN : {book.ISBN} Already exists");
                    throw new ArgumentException("Already exists");
                }
            }

            _bookStorage.Add(book);
            _logger.Info($"Book ISBN : {book.ISBN} added");
        }

        public void RemoveBook(Book book)
        {
            _logger.Debug($"Try RemoveBook {book}");
            if (!_bookStorage.Remove(book))
            {
                _logger.Error($"ISBN {book.ISBN} not found");
                throw new ArgumentException("Not found");
            }

            _logger.Info($"Book ISBN : {book.ISBN} removed");
        }

        public ICollection<Book> Sort(IComparer<Book> comparer)
        {
            _logger.Debug($"Try Sort book with {comparer}");
            ((List<Book>)_books).Sort(comparer);
            return _books;
        }

        public Book FindByTag(Filter filter)
        {
            foreach (var item in _bookStorage.GetAll())
            {
                if (filter.IsEquals(item))
                {
                    _logger.Info($"Book found");
                    return item;
                }
            }

            _logger.Error($"ISBN {filter} not found");
            throw new ArgumentException("Not found");
        }

        public ICollection<Book> GetAll()
        {
            return _books;
        }

        public void Save()
        {
            _logger.Debug($"Try Save books. ");
            _bookStorage.Save();
            _logger.Info("Save books - Ok.");
        }

        public void Load()
        {
            _logger.Debug($"Try Load books. ");
            _bookStorage.Load();
            _logger.Info("Load books  - Ok.");
        }
    }
}
