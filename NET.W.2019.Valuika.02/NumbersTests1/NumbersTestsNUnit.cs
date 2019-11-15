using NUnit.Framework;
using Numbers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers.Tests
{
    [TestFixture()]
    public class NumbersTestsNUnit
    {
        [TestCase(15, 15, 0, 0, ExpectedResult = 15)]
        [TestCase(8, 15, 0, 0, ExpectedResult = 9)]
        [TestCase(8, 15, 3, 8, ExpectedResult = 120)]
        [TestCase(568, 53, 8, 11, ExpectedResult = 1336)]
        public int InsertNumberTest(int numberSource, int numberIn, int i, int j)
        {
            return  Numbers.InsertNumber(numberSource, numberIn, i, j);
        }

        [Test]
        public void InsertNumberTest_Ex()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Numbers.InsertNumber(11, 11, 10, 1));
        }
    }
}