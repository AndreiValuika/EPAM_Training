using NUnit.Framework;

namespace Sort.lib.Tests
{
    [TestFixture]
    public class SortTests
    {
        [TestCase(new int[] { 67, 12, 95, 56, 85, 1, 100, 23, 60, 9 },
            Result = new int[] { 1, 9, 12, 23, 56, 60, 67, 85, 95, 100 })]
        [TestCase(new int[] { 43, 1, 0, 56, -3, -6, 43, 10, -3, 0 },
            Result = new int[] { -6, -3, -3, 0, 0, 1, 10, 43, 43, 56 })]
        public int[] Quick_Sort_Test(int[] array)
        {
            Sort.QuickSort(array);
            return array;
        }

        [TestCase(new int[] { 67, 12, 95, 56, 85, 1, 100, 23, 60, 9 },
            Result = new int[] { 1, 9, 12, 23, 56, 60, 67, 85, 95, 100 })]
        [TestCase(new int[] { 43, 1, 0, 0, 56, -3, -6, -3, 10 },
            Result = new int[] { -6, -3, -3, 0, 0, 1, 10, 43, 56 })]
        public int[] Merge_Sort_Test(int[] array)
        {
            Sort.MergeSort(array);
            return array;
        }
    }
}