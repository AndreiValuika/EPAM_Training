using NUnit.Framework;
using SortJaggedArray;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortJaggedArray.Tests
{
    [TestFixture()]
    public class JaggedArrayTests
    {
        int[][] _test; 
        [SetUp]
        public void Init() 
        {
            _test = new int[4][]
            {
                new int[] { 10, 20, 30, 40, 50, 60 },
                new int[] { 11, 21, 31 },
                new int[] { 12, 22, 32, 42, 52, 62 },
                new int[] { 100 }
            };
        }
        [Test]
        public void SortFTest()
        {
           int[][]  expend = new int[4][]
           {
               new int[] { 11, 21, 31 },
               new int[] { 100 },
               new int[] { 10, 20, 30, 40, 50, 60 },
               new int[] { 12, 22, 32, 42, 52, 62 },
           };
           JaggedArray.SortF(_test, false);
           Assert.AreEqual(_test,expend);
        }
        [Test]
        public void SortFTestInvert()
        {
            int[][] expend = new int[4][]
            {
               new int[] { 12, 22, 32, 42, 52, 62 },
               new int[] { 10, 20, 30, 40, 50, 60 },
               new int[] { 100 },
               new int[] { 11, 21, 31 },
            };
            JaggedArray.SortF(_test, true);
            Assert.AreEqual(_test, expend);
        }

        [Test]
        public void SortMinTest()
        {
            int[][] expend = new int[4][]
            {
               new int[] { 10, 20, 30, 40, 50, 60 },
               new int[] { 11, 21, 31 },
               new int[] { 12, 22, 32, 42, 52, 62 },
               new int[] { 100 },
            };
            JaggedArray.SortMin(_test, false);
            Assert.AreEqual(_test, expend);
        }

        [Test]
        public void SortMinTestInvert()
        {
            int[][] expend = new int[4][]
            {
               new int[] { 100 },
               new int[] { 12, 22, 32, 42, 52, 62 },
               new int[] { 11, 21, 31 },
               new int[] { 10, 20, 30, 40, 50, 60 },
            };

            JaggedArray.SortMin(_test, true);
            Assert.AreEqual(_test, expend);
        }

        [Test]
        public void SortMaxTest()
        {
            int[][] expend = new int[4][]
            {
               new int[] { 11, 21, 31 },
               new int[] { 10, 20, 30, 40, 50, 60 },
               new int[] { 12, 22, 32, 42, 52, 62 },
               new int[] { 100 },
            };
            JaggedArray.SortMax(_test, false);
            Assert.AreEqual(_test, expend);
        }

        [Test]
        public void SortMaxTestInvert()
        {
            int[][] expend = new int[4][]
            {
               new int[] { 100 },
               new int[] { 12, 22, 32, 42, 52, 62 },
               new int[] { 10, 20, 30, 40, 50, 60 },
               new int[] { 11, 21, 31 },
            };
            JaggedArray.SortMax(_test, true);
            Assert.AreEqual(_test, expend);
        }
    }
}