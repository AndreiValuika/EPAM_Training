using System;

namespace Numbers
{
    public partial class Numbers
    {
        /// <summary>
        /// Insert one number to second
        /// </summary>
        /// <param name="numberSource">Target number</param>
        /// <param name="numberIn">Inserted number </param>
        /// <param name="shift">Start point</param>
        /// <param name="startIndex">Finish point</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">Wrong Start-Finish point</exception>
        public static int InsertNumber(int numberSource, int numberIn, int shift, int startIndex)
        {
            if (shift > startIndex)
            {
                throw new ArgumentOutOfRangeException();
            }

            int size = startIndex - shift + 1;
            CutNumber(ref numberIn, shift, size);
            int mask = GetMask(size, shift);

            return numberSource & mask | numberIn;
        }

        private static void CutNumber(ref int numberIn, int shift, int size)
        {
            int mask = ~0;
            mask <<= size;
            numberIn &= ~mask;
            numberIn <<= shift;
        }

        private static int GetMask(int size, int shift)
        {
            int mask = ~0;
            mask <<= size;
            mask = (~mask) << shift;
            return ~mask;
        }
    }
}
