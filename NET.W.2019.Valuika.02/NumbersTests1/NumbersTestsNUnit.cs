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
            return Numbers.InsertNumber(numberSource, numberIn, i, j);
        }

        [Test]
        public void InsertNumberTest_Ex()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Numbers.InsertNumber(11, 11, 10, 1));
        }

        [TestCase(12, ExpectedResult = 21)]
        [TestCase(513, ExpectedResult = 531)]
        [TestCase(2017, ExpectedResult = 2071)]
        [TestCase(414, ExpectedResult = 441)]
        [TestCase(144, ExpectedResult = 414)]
        [TestCase(1234321, ExpectedResult = 1241233)]
        [TestCase(1234126, ExpectedResult = 1234162)]
        [TestCase(3456432, ExpectedResult = 3462345)]
        [TestCase(10, ExpectedResult = -1)]
        [TestCase(20, ExpectedResult = -1)]

        public int FindNextBiggerNumberTest(int startNumber)
        {
            int result = Numbers.FindNextBiggerNumber(startNumber, out int workTimeWatch,out int workTimeSystem);
            return result;
        }

        [TestCase(new int[] { 67, 12, 95, 56, 85, 1, 100, 23, 60, 9 }, 6,
            Result = new int[] { 67, 56, 60 })]
        [TestCase(new int[] { 67, 19, 95, 56, 85, 1, -79, 99, 60, 9 }, 9,
            Result = new int[] { 19, 95, -79, 99, 9 })]
        [TestCase(new int[] { 67, 12, 95, 56, 85, 1, 100, 23, 60, 9 }, 4,
            Result = new int[] { })]
        public int[] FilterDigitTest(int[] array, int digit)
        {
            return Numbers.FilterDigit(array, digit);
        }

        [TestCase(1, 5, 0.0001, Result = 1)]
        [TestCase(8, 3, 0.0001, Result = 2)]
        [TestCase(0.001, 3, 0.0001, ExpectedResult = 0.1)]
        [TestCase(0.04100625, 4, 0.0001, ExpectedResult = 0.45)]
        [TestCase(8, 3, 0.0001, ExpectedResult = 2)]
        [TestCase(0.0279936, 7, 0.0001, ExpectedResult = 0.6)]
        [TestCase(0.0081, 4, 0.1, ExpectedResult = 0.3)]
        [TestCase(-0.008, 3, 0.1, ExpectedResult = -0.2)]
        [TestCase(0.004241979, 9, 0.00000001, ExpectedResult = 0.545)]

        public double FindNthRootTest(double number, int degree, double precision)
        {
            return Numbers.FindNthRoot(number,degree,precision);
        }
        [Test]
        public void FindNthRoot_Number_Degree_Precision_ArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Numbers.FindNthRoot(1, -1, -1));
        }

    }
}