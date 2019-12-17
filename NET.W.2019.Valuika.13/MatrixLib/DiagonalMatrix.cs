using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLib
{
    public class DiagonalMatrix<T> : SymmetrixMatrix<T> where T: IComparable, IComparable<T>
    {
        public DiagonalMatrix(int size) : base(size)
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
                    if (i!=j && !Get(i, j).Equals(default(T)))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public   T Get(int n)
        {
            return Matrix[n, n];
        }
        public override T Get(int n, int m)
        {
            return Matrix[n, m];
        }
        public override void Set(int n, int m, T item)
        {
            Matrix[n, n] = item;
        }
        public  void Set(int n, T item)
        {
            base.Set(n, n, item);
        }
    }

}
