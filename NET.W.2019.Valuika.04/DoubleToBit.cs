using System.Text;

namespace DoubleLibrary
{
    public static class DoubleToBit
    {
        public static string ToBitString(this double d)
        {
            const long MASK = 1;
            const int BIT_IN_DOUBLE = 64;

            unsafe
            {
                double* ptrDouble = &d;
                long* ptrLong = (long*)ptrDouble;

                StringBuilder result = new StringBuilder();

                for (int i = BIT_IN_DOUBLE - 1; i >= 0; i--)
                {
                    result.Append((*ptrLong & (MASK << i)) != 0 ? '1' : '0');
                }

                return result.ToString();
            }
        }
    }
}
