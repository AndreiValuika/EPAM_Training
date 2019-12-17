using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLib
{
    public class SymmetrixMatrix<T> : SquareMatrix<T> where T:IComparable,IComparable<T>
    {
        public SymmetrixMatrix(int size) : base(size)
        {
        }

        public override bool SetMatrix(T[,] matrix)
        {
            if (!base.SetMatrix(matrix)) 
            {
                return false;
            }

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    var first = Get(i, j);
                    var second = Get(j, i);
                    if (!first.Equals(second))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public override void Set(int n, int m, T item)
        {
            base.Set(n, m, item);
            base.Set(m, n, item);
        }

    }
}
