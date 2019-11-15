using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers
{
    public class Numbers
    {
        public static Int32 InsertNumber(int numberSource, int numberIn, int shift,int startIndex) 
        {
            if (shift > startIndex)
            {
                throw new ArgumentOutOfRangeException();
            }

            int size = startIndex - shift + 1;
            int result;
            CutNumber(ref numberIn, shift,size);
            int mask = ~PreSource(size, shift);
            result = (numberSource & mask) | numberIn;
            return result;
        }

        private static void CutNumber(ref int numberIn, int shift,int size) 
        {
            int mask = ~0;
            mask <<= size;
            numberIn &= (~mask);
            numberIn <<= shift;
        }

        private static int PreSource(int size, int shift) 
        {
            int mask = ~0;
            mask <<= size;
            mask = (~mask) << shift;
            return mask;
        }
    }
}
