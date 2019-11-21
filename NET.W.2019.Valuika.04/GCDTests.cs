using NUnit.Framework;

namespace GCDLib.Tests
{
    [TestFixture]
    public class GCDTests
    {
        [TestCase(5, 10, 15, 25, ExpectedResult = 5)]
        [TestCase(12, 18, 36, ExpectedResult = 6)]
        [TestCase(1044, -1512, 2436, ExpectedResult = 12)]
        [TestCase(10, 4, ExpectedResult = 2)]
        [TestCase(12, 0, 36, ExpectedResult = 12)]
        public int GCD_Test(int a, int b, params int[] array)
        {
            int actual = GCD.GetGCD(out int time, a, b, array);
            Assert.Positive(time);
            return actual;
        }

        [TestCase(5, 10, 15, 25, ExpectedResult = 5)]
        [TestCase(12, 18, 36, ExpectedResult = 6)]
        [TestCase(1044, -1512, 2436, ExpectedResult = 12)]
        [TestCase(10, 4, ExpectedResult = 2)]
        [TestCase(12, 0, 36, ExpectedResult = 12)]
        public int GCD_Binnary_Test(int a, int b, params int[] array)
        {
            int actual = new GCD().GetMultipleGCDBinnary(out int time, a, b, array);
            Assert.Positive(time);
            return actual;
        }
    }
}