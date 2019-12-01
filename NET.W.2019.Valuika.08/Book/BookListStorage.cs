using System.Collections.Generic;
using System.IO;

namespace BookLib
{
    public class BookListStorage
    {
        private List<Book> _books;
        private string _path;

        public BookListStorage(string path = "")
        {
            _books = new List<Book>();
            _path = path;
        }

        public void Save()
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(_path, FileMode.OpenOrCreate)))
            {
                foreach (Book book in _books)
                {
                    writer.Write(book.ISBN);
                    writer.Write(book.Title);
                    writer.Write(book.Author);
                    writer.Write(book.Publisher);
                    writer.Write(book.Pages);
                    writer.Write(book.Year);
                    writer.Write(book.Price);
                }
            }
        }

        public void Load()
        {
            _books.Clear();
            using (BinaryReader reader = new BinaryReader(File.Open(_path, FileMode.Open)))
            {
                while (reader.PeekChar() > -1)
                {
                    var isbn = reader.ReadString();
                    var title = reader.ReadString();
                    var author = reader.ReadString();
                    var publisher = reader.ReadString();
                    var pages = reader.ReadInt32();
                    var year = reader.ReadInt32();
                    var price = reader.ReadSingle();
                    _books.Add(new Book(isbn, title, author, publisher, pages, year, price));
                }
            }
        }

        public ICollection<Book> GetAll()
        {
            return _books;
        }

        public bool Add(Book book)
        {
            _books.Add(book);
            return true;
        }

        public bool Remove(Book book)
        {
            return _books.Remove(book);
        }

        public IList<Book> Sort(IComparer<Book> comparer)
        {
            _books.Sort(comparer);
            return _books;
        }

        public Book FindByTag(Filter filter)
        {
            foreach (var item in _books)
            {
                if (filter.IsEquals(item))
                {
                    return item;
                }
            }

            return null;
        }
    }
}
