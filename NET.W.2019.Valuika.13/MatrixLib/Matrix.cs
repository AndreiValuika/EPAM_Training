using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLib
{
    public class SquareMatrix<T> where T :IComparable,IComparable<T>
    {
        public T[,] Matrix { get; set; }

        protected int Size{ get; set; }

        public SquareMatrix(int size)
        {
            Size = size;
            Matrix = new T[Size, Size];
        }

        public virtual bool SetMatrix(T[,] matrix) 
        {
            if (matrix==null)
            {
                return false;
            }

            if (matrix.Rank!=2)
            {
                return false;
            }

            if (Math.Sqrt(matrix.Length) % 1 != 0) 
            {
                return false;
            }

            Matrix = matrix;
            return true;
        }


        public virtual void Set(int n, int m, T item) 
        {
            Matrix[n, m] = item;
            ChangeValueInMatrix(n, m, item.ToString());
        }

        public virtual T Get(int n, int m) 
        {
            return Matrix[n, m];
        }

        public bool Equals(SquareMatrix<T> other)
        {
            if (other == null)
                return false;

            if (this.Size != other.Size)
                return false;

            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    if (!this.Get(i, j).Equals(other.Get(i, j)))
                        return false;

            return true;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    stringBuilder.Append(Matrix[i, j].ToString());
                    stringBuilder.Append(" ");
                }
                stringBuilder.Append("\r\n");
            }
            return stringBuilder.ToString();
        }

        public override bool Equals(object obj) => Equals(obj as SquareMatrix<T>);

        public override int GetHashCode()
        {
            int sum = 0;
            for (int i = 0; i < Size; i++)
            {
                sum += Matrix[i, i].GetHashCode();
            }
            return sum * Size;
        }
        public event EventHandler<string> ChengeValue;
        protected void OnChangeValue(string msg)
        {
            
            ChengeValue?.Invoke(this, msg);
        }

        protected void ChangeValueInMatrix(int rowIndex, int columnIndex, string message)
        {
            string eventMessage = $"The value in row index {rowIndex} and {columnIndex}  - {message}.";
            
            OnChangeValue(eventMessage);
        }

        public class MatrixArgs : EventArgs
        {
            private string message;

            public string Message { get => message; }

            public MatrixArgs(string message)
            {
                this.message = message;
            }
        }


    }
}
