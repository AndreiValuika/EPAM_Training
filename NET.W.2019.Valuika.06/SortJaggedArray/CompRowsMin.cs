using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortJaggedArray
{
   public class CompRowsMin : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
           
                int minFirst = x[0];
                int minSecond = y[0];

                foreach (var item in x)
                {
                    if (minFirst > item)
                    {
                        minFirst = item;
                    }
                }

                foreach (var item in y)
                {
                    if (minSecond > item)
                    {
                        minSecond = item;
                    }
                }

                return minFirst > minSecond ? 1 : -1;
            
        }
    }
}
