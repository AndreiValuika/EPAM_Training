using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers
{
    public class Numbers
    {

        private static int ArrayToNumber(int[] array)
        {
            StringBuilder tempString = new StringBuilder();
            foreach (var item in array)
            {
                tempString.Append(item.ToString());
            }

            int result = Convert.ToInt32(tempString.ToString());
            return result;
        }

        private static void SwapNumber(ref int x, ref int y) 
        {
            int temp = x;
            x = y;
            y = temp;
        }

        public static int FindNextBiggerNumber(int number) 
        {
            string digitString = number.ToString();
            int digitCount = digitString.Length;
            int[] digitArray = new int[digitCount];
            int index = 0;

            foreach (var item in digitString)
            {
                digitArray[index++] = Convert.ToInt32(item.ToString());
            }
            int poviteIndex=0;

            for (int i = digitCount-1; i>=1; i--)
            {
                if (digitArray[i]>digitArray[i-1])
                {
                    poviteIndex = i;
                    break;
                }
            }

            if (poviteIndex == 0)
            {
                return -1;
            }

            SwapNumber(ref digitArray[poviteIndex], ref digitArray[poviteIndex - 1]);
            Array.Sort(digitArray, poviteIndex, digitCount - poviteIndex);

            return ArrayToNumber(digitArray); 
        }

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
