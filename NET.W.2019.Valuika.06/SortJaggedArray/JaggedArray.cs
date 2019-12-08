using System;
using System.Collections.Generic;

namespace SortJaggedArray
{
    public static class JaggedArrayInterface
    {

        public static void SortInterface(int[][] array, bool invert, IComparer<int[]> Comp)
        {
            SortDelegate(array, invert, Comp.Compare);
        }

        private static void SortDelegate(int[][] array, bool invert, Comparison<int[]> comparison)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if ((comparison(array[j], array[j + 1]) > 0) ^ invert)
                    {
                        SwapRows(ref array[j], ref array[j + 1]);
                    }
                }
            }
        }

        private static void SwapRows(ref int[] first, ref int[] second)
        {
            int[] temp = first;
            first = second;
            second = temp;
        }

    }
}
