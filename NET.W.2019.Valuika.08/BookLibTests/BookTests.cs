using NUnit.Framework;
using System;
using System.Globalization;

namespace BookLib.Tests
{
    [TestFixture]
    public class BookTests
    {
        private Book _book;
        [OneTimeSetUp]
        public void Init() 
        {
            _book = new Book()
            {
                Author = "Author",
                ISBN = "123456",
                Publisher = "Publisher",
                Pages = 23,
                Price = 100,
                Title = "Title",
                Year = 1967
            };
        }

        [TestCase("AT", ExpectedResult = "Author: Author, Title: Title")]
        [TestCase("ATPY", ExpectedResult = "Author: Author, Title: Title, Publisher: Publisher, Year: 1967")]
        [TestCase("IATPYС", ExpectedResult = "ISBN: 123456, Author: Author, Title: Title, Publisher: Publisher, Year: 1967, Price: 100")]
        [TestCase("ATPYС", ExpectedResult = "Author: Author, Title: Title, Publisher: Publisher, Year: 1967, Price: 100")]
        [TestCase("Full", ExpectedResult = "ISBN: 123456, Author: Author, Title: Title, Publisher: Publisher, Year: 1967, Number of pages: 23, Price: 100")]
        
        public string ToStringTest(string format)
        {
            return _book.ToString(format,CultureInfo.InvariantCulture);
        }
      
        [Test]
        public void FormatTest()
        {
           string expect = "ISBN: 123456, Author: Author, Title: Title";
            Assert.AreEqual(expect, string.Format(new BookFormat(), "{0:IAT}", _book));
        }
        [Test]
        public void ExpectException() 
        {
            Assert.Throws<FormatException>(()=>_book.ToString("535", CultureInfo.InvariantCulture));
        }

    }
}