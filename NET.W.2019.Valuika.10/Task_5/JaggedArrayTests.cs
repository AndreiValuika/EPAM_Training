using NUnit.Framework;

namespace SortJaggedArray.Tests
{
    [TestFixture]
    public class JaggedArrayTests
    {
        private int[][] _test1;
        private int[][] _test2;
        [SetUp]
        public void Init()
        {
            _test1 = new int[4][]
            {
                new int[] { 10, 20, 30, 40, 50, 60 },
                new int[] { 11, 21, 31 },
                new int[] { 12, 22, 32, 42, 52, 62 },
                new int[] { 100 }
            };
            _test2 = (int[][])_test1.Clone();
        }

        [Test]
        public void SortSumTest()
        {
            int[][] expend = new int[4][]
            {
               new int[] { 11, 21, 31 },
               new int[] { 100 },
               new int[] { 10, 20, 30, 40, 50, 60 },
               new int[] { 12, 22, 32, 42, 52, 62 },
            };

            JaggedArrayInterface.SortInterface(_test1, false, new CompRowsSum());
            JaggedArrayDelegate.SortDelegate(_test2, false, new CompRowsSum().Compare);
            Assert.AreEqual(_test1, _test2);
            Assert.AreEqual(_test1, expend);
        }

        [Test]
        public void SortSumTestInvert()
        {
            int[][] expend = new int[4][]
            {
               new int[] { 12, 22, 32, 42, 52, 62 },
               new int[] { 10, 20, 30, 40, 50, 60 },
               new int[] { 100 },
               new int[] { 11, 21, 31 },
            };
            JaggedArrayInterface.SortInterface(_test1, true, new CompRowsSum());
            JaggedArrayDelegate.SortDelegate(_test2, true, new CompRowsSum().Compare);
            Assert.AreEqual(_test1, _test2);
            Assert.AreEqual(_test1, expend);
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

            JaggedArrayInterface.SortInterface(_test1, false, new CompRowsMin());
            JaggedArrayDelegate.SortDelegate(_test2, false, new CompRowsMin().Compare);
            Assert.AreEqual(_test1, _test2);
            Assert.AreEqual(_test1, expend);
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

            JaggedArrayDelegate.SortDelegate(_test2, true, new CompRowsMin().Compare);
            JaggedArrayInterface.SortInterface(_test1, true, new CompRowsMin());
            Assert.AreEqual(_test1, _test2);
            Assert.AreEqual(_test1, expend);
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
            JaggedArrayInterface.SortInterface(_test1, false, new CompRowsMax());
            JaggedArrayDelegate.SortDelegate(_test2, false, new CompRowsMax().Compare);
            Assert.AreEqual(_test1, _test2);
            Assert.AreEqual(_test1, expend);
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
            JaggedArrayInterface.SortInterface(_test2, true, new CompRowsMax());
            JaggedArrayDelegate.SortDelegate(_test1, true, new CompRowsMax().Compare);
            Assert.AreEqual(_test1, _test2);
            Assert.AreEqual(_test1, expend);
        }
    }
}