using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLib
{
    public class BookListStorage
    {
        private List<Book> _books;

        public BookListStorage() { _books = new List<Book>(); }
        public bool SaveListToFile(string path)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
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

            return true;
        }
        public bool LoadListFromFile(string path)
        {
            _books.Clear();
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                while (reader.PeekChar() > -1)
                {
                    var ISBN = reader.ReadString();
                    var title = reader.ReadString();
                    var author = reader.ReadString();
                    var publisher = reader.ReadString();
                    var pages = reader.ReadInt32();
                    var year = reader.ReadInt32();
                    var price = reader.ReadSingle();
                    _books.Add(new Book(ISBN, title, author, publisher, pages, year, price));
                }
            }

            return true;
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
            _books.Remove(book);
            return true;
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
