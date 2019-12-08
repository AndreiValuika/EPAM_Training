using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortJaggedArray
{
    public class TempClass : IComparer<int[]>
    {
        private Comparison<int[]> delegateForm;
        public void SetM(Comparison<int[]> @delegate) 
        {
            this.delegateForm = @delegate;
        }
        public int Compare(int[] x, int[] y)
        {
            return delegateForm(x,y);
        }
    }
}
