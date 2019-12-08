using System.Collections.Generic;

namespace SortJaggedArray
{
    public class CompRowsMax : IComparer<int[]>
    {
        public int Compare(int[] first, int[] second)
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

            return maxFirst > maxSecond ? 1 : -1;
        }
    }
}
