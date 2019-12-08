using BookLib;
using System;
using System.Globalization;

namespace ConsoleBookTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book("1111", "Title1", "Author1", "Publisher1", 20, 1975, 15f);

            var storage = new BookListStorage("ListBook.bin");
            var service = new BookListService(storage);
            service.AddBook(book);
            service.AddBook(new Book("3333", "Title2", "Author2", "Publisher2", 200, 1975, 18f));
            service.AddBook(new Book("5555", "Title3", "Author2", "Publisher2", 254, 1975, 18f));
            service.AddBook(new Book("4444", "Title5", "Author2", "Publisher2", 2, 1975, 18f));
            service.AddBook(new Book("55554", "Title2", "Author2", "Publisher2", 299, 1975, 18f));
            service.AddBook(new Book("34534", "Title6", "Author2", "Publisher2", 2000, 1975, 18f));
            service.AddBook(new Book("3333", "Title2", "Author6", "Publisher45", 200, 1975, 14f));
            service.AddBook(new Book("5555", "Title35", "Author2", "Publisher2", 254, 1975, 18f));
            service.AddBook(new Book("4444", "Title51", "Author34", "Publisher2", 2, 1975, 187f));
            service.AddBook(new Book("55554", "Title2", "Author65", "Publisher453", 299, 1975, 148f));
            service.AddBook(new Book("34534", "Title6", "Author211", "Publisher2", 2000, 1975, 78f));


            Filter filterPage = new Filter(pages: 2);
            Console.WriteLine("Find book Pages = 2 : \n\r" + service.FindByTag(filterPage));

            Filter filterTitle = new Filter(title: "Title3");
            Console.WriteLine("Find book Title = Title3 : \n\r" + service.FindByTag(filterTitle));


            Console.WriteLine("Unsort : ");
            var serviceList = service.GetAll();
            service.Save();
            service.Load();
            foreach (var item in serviceList)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Sort by ISNB:");
            service.Sort(new ByISBN());

            foreach (var item in serviceList)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Sort by price:");
            service.Sort(new ByPrice());

            foreach (var item in serviceList)
            {
                Console.WriteLine("--");
                Console.WriteLine(item.ToString("Full", CultureInfo.InvariantCulture));
                Console.WriteLine(item.ToString("Full", CultureInfo.CurrentCulture));
                Console.WriteLine(item.ToString("ATPY", CultureInfo.InvariantCulture));
                Console.WriteLine("--");
                Console.WriteLine(String.Format(new BookFormat(), "{0:IAT}", item));
                Console.WriteLine(String.Format(new BookFormat(), "{0:ATC}", item));
            }

            Console.ReadKey();
        }
    }
}
