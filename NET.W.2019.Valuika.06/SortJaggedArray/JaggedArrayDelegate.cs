using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortJaggedArray
{
   public class JaggedArrayDelegate
    {

        private static void SwapRows(ref int[] first, ref int[] second)
        {
            int[] temp = first;
            first = second;
            second = temp;
        }
       
        //public static void SortFirst(int[][] array, bool invert, Func<int[], int[], bool> Comp)
        //{
        //    for (int i = 0; i < array.Length; i++)
        //    {
        //        for (int j = 0; j < array.Length - 1; j++)
        //        {
        //            if (Comp(array[j], array[j + 1]) ^ invert)
        //            {
        //                SwapRows(ref array[j], ref array[j + 1]);
        //            }
        //        }
        //    }
        //}

        public static void SortDelegate(int[][] array, bool invert, Comparison<int[]> comparison)
        {
            TempClass tempClass = new TempClass();
            tempClass.SetM(comparison);
            SortInterface(array, invert, tempClass);
            //for (int i = 0; i < array.Length; i++)
            //{
            //    for (int j = 0; j < array.Length - 1; j++)
            //    {
            //        if ((comparison(array[j], array[j + 1]) > 0) ^ invert)
            //        {
            //            SwapRows(ref array[j], ref array[j + 1]);
            //        }
            //    }
            //}
        }

        public static void SortInterface(int[][] array, bool invert, IComparer<int[]> Comp)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if ((Comp.Compare(array[j], array[j + 1]) > 0) ^ invert)
                    {
                        SwapRows(ref array[j], ref array[j + 1]);
                    }
                }
            }
        }
    }
}
