using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortJaggedArray
{
   public class CompRowsSum : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            return SumRow(x) > SumRow(y) ? 1 : -1;
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
    }
}
