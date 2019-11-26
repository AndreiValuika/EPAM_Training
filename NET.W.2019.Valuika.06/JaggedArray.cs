using System;

namespace SortJaggedArray
{
    public static class JaggedArray
    {
        private static void SwapRows(ref int[] first, ref int[] second)
        {
            int[] temp = first;
            first = second;
            second = temp;
        }

        private static int SumRow(int[] row)
        {
            int sum = 0;
            foreach (var item in row)
            {
                sum += item;
            }

            return sum;
        }

        private static bool CompRowsSum(int[] first, int[] second)
        {
            return SumRow(first) > SumRow(second) ? true : false;
        }

        private static bool CompRowsMin(int[] first, int[] second)
        {
            int minFirst = first[0];
            int minSecond = second[0];

            foreach (var item in first)
            {
                if (minFirst > item)
                {
                    minFirst = item;
                }
            }

            foreach (var item in second)
            {
                if (minSecond > item)
                {
                    minSecond = item;
                }
            }

            return minFirst > minSecond ? true : false;
        }

        static bool CompRowsMax(int[] first, int[] second)
        {
            int maxFirst = first[0];
            int maxSecond = second[0];

            foreach (var item in first)
            {
                if (maxFirst < item)
                {
                    maxFirst = item;
                }
            }

            foreach (var item in second)
            {
                if (maxSecond < item)
                {
                    maxSecond = item;
                }
            }

            return maxFirst > maxSecond ? true : false;
        }

        public static void SortF(int[][] array, bool invert)
        {
            SortFirst(array, invert, CompRowsSum);
        }
        public static void SortMin(int[][] array, bool invert)
        {
            SortFirst(array, invert, CompRowsMin);
        }
        public static void SortMax(int[][] array, bool invert)
        {
            SortFirst(array, invert, CompRowsMax);
        }
        public static void SortFirst(int[][] array, bool invert, Func<int[], int[], bool> Comp)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (Comp(array[j], array[j + 1]) ^ invert)
                    {
                        SwapRows(ref array[j], ref array[j + 1]);
                    }
                }
            }
        }
    }
}
