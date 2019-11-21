using System.Collections.Generic;

namespace Numbers
{
    public partial class Numbers
    {
        /// <summary>
        /// Delete all numbers in array, except number which involves current digit
        /// </summary>
        /// <param name="array"></param>
        /// <param name="filterDigit"></param>
        /// <returns></returns>
        public static int[] FilterDigit(int[] array, int filterDigit)
        {
            IList<int> tempList = new List<int>();
            foreach (int item in array)
            {
                if (HasDigit(item, filterDigit))
                {
                    tempList.Add(item);
                }
            }

            int[] resultArray = new int[tempList.Count];
            for (int i = 0; i < tempList.Count; i++)
            {
                resultArray[i] = tempList[i];
            }

            return resultArray;
        }

        /// <summary>
        /// Check numbers to involves digit
        /// </summary>
        /// <param name="number">Number</param>
        /// <param name="digit">Digit</param>
        /// 
        /// <returns>"True" if number involves digit</returns>
        private static bool HasDigit(int number, int digit)
        {
            if (number < 0)
            {
                number *= -1;
            }

            do
            {
                if (number % 10 == digit)
                {
                    return true;
                }

                number /= 10;
            }
            while (number > 0);

            return false;
        }
    }
}
