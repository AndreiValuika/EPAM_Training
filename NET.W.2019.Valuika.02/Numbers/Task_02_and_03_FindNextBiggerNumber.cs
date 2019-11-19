using System;
using System.Diagnostics;
using System.Text;

namespace Numbers
{
    public partial class Numbers
    {
        /// <summary>
        /// Find first biggest number with equaled digit. Additionally execution time in millisecond.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="workTimeWatch"></param>
        /// <param name="workTimeSystem"></param>
        /// <returns>Desired number or "-1" if desired number non-existent</returns>
        public static int FindNextBiggerNumber(int number, out int workTimeWatch, out long workTimeSystem)
        {
            Stopwatch watch = Stopwatch.StartNew();
            long startTime = DateTime.Now.Ticks;

            int result = FindNextBiggerNumber(number);

            watch.Stop();
            workTimeWatch = (int)watch.ElapsedTicks;
            workTimeSystem = DateTime.Now.Ticks - startTime;
            return result;
        }

        /// <summary>
        /// Find first biggest number with equaled digit
        /// </summary>
        /// <param name="number"></param>
        /// <param name="workTimeWatch"></param>
        /// <param name="workTimeSystem"></param>
        /// <returns>Desired number or "-1" if desired number non-existent</returns>
        public static int FindNextBiggerNumber(int number)
        {
            if (number <= 0)
            {
                throw new ArgumentException("Number must be positive");
            }

            string digitString = number.ToString();
            int digitCount = digitString.Length;
            int[] digitArray = new int[digitCount];
            int index = 0;

            foreach (var item in digitString)
            {
                digitArray[index++] = Convert.ToInt32(item.ToString());
            }

            int poviteIndex = 0;

            for (int i = digitCount - 1; i >= 1; i--)
            {
                if (digitArray[i] > digitArray[i - 1])
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

        /// <summary>
        /// Swap two integer number
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private static void SwapNumber(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }

        /// <summary>
        /// Parse integer number from array.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
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
    }
}
