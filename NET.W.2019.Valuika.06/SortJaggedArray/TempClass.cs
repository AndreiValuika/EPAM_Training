using System;
using System.Collections.Generic;

namespace SortJaggedArray
{
    public class TempClass : IComparer<int[]>
    {
        private Comparison<int[]> delegateForm;

        public TempClass(Comparison<int[]> delegateForm)
        {
            this.delegateForm = delegateForm;
        }

        public int Compare(int[] x, int[] y)
        {
            return delegateForm(x, y);
        }
    }
}
