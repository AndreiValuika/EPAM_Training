using System;
using System.Collections.Generic;

namespace SortJaggedArray
{
    public class JaggedArrayDelegate
    {
        public static void SortDelegate(int[][] array, bool invert, Comparison<int[]> comparison)
        {
            TempClass tempClass = new TempClass(comparison);
            SortInterface(array, invert, tempClass);
        }

        public static void SortInterface(int[][] array, bool invert, IComparer<int[]> comp)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if ((comp.Compare(array[j], array[j + 1]) > 0) ^ invert)
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
