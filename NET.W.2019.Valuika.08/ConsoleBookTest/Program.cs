using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLib;

namespace ConsoleBookTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book("1111", "Title1", "Author1", "Publisher1", 20, 1975, 15f);
            var storage = new BookListStorage();
            storage.Add(book);
            storage.Add(new Book("3333", "Title2", "Author2", "Publisher2", 200, 1975, 18f));
            storage.Add(new Book("5555", "Title3", "Author2", "Publisher2", 254, 1975, 18f));
            storage.Add(new Book("4444", "Title5", "Author2", "Publisher2", 2, 1975, 18f));
            storage.Add(new Book("55554", "Title2", "Author2", "Publisher2", 299, 1975, 18f));
            storage.Add(new Book("34534", "Title6", "Author2", "Publisher2", 2000, 1975, 18f));
            storage.Add(new Book("3333", "Title2", "Author6", "Publisher45", 200, 1975, 14f));
            storage.Add(new Book("5555", "Title3", "Author2", "Publisher2", 254, 1975, 18f));
            storage.Add(new Book("4444", "Title5", "Author34", "Publisher2", 2, 1975, 187f));
            storage.Add(new Book("55554", "Title2", "Author65", "Publisher453", 299, 1975, 148f));
            storage.Add(new Book("34534", "Title6", "Author211", "Publisher2", 2000, 1975, 78f));


            Filter filterPage = new Filter(pages:2);
            Console.WriteLine("Find book Pages = 2 : \n\r"+storage.FindByTag(filterPage) );

            Filter filterTitle = new Filter(title:"Title3");
            Console.WriteLine("Find book Title = Title3 : \n\r" + storage.FindByTag(filterTitle));


            Console.WriteLine("Unsort : ");
            var storageList = storage.GetAll();
            storage.SaveListToFile("test.dat");
            storage.LoadListFromFile("test.dat");
            foreach (var item in storageList)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Sort by ISNB:");
            storage.Sort(new ByISBN());

            foreach (var item in storageList)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Sort by price:");
            storage.Sort(new ByPrice());

            foreach (var item in storageList)
            {
                Console.WriteLine(item);
            }




            Console.ReadKey();
            
            
            
            
           
                
        }
    }
}
