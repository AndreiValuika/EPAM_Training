using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Numbers
{
    public class Numbers
    {

        private static double Pow(double a, int pow)
        {
            double result = 1;
            for (int i = 0; i < pow; i++)
            {
                result *= a;
            }
            return result;
        }

        private static int GetAccuracy(double eps)
        {
            int result = 0;
            while (eps < 1)
            {
                result++;
                eps *= 10;
            }
            return result;
        }
        public static double FindNthRoot(double number, int degree, double eps)
        {
            if (eps <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            double x0 = 1 + ((number - 1) / 2);
            double x1 = x0 * (1 - (1 - number / Pow(x0, degree)) / degree);

            while (Math.Abs(x1 - x0) > eps)
            {
                x0 = x1;
                x1 = x0 * (1 - (1 - number / Pow(x0, degree)) / degree);
            }

            x1 = Math.Round(x1, GetAccuracy(eps));
            return x1;
        }


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

        private static bool HasDigit(int number, int digit)
        {
            if (number < 0)
            {
                number *= (-1);
            }
            do
            {
                if (number % 10 == digit)
                {
                    return true;
                }
                number /= 10;
            } while (number > 0);
            return false;
        }
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
            return tempList.ToArray();
        }
        public static int FindNextBiggerNumber(int number, out int workTimeWatch,out int workTimeSystem)
        {
            Stopwatch watch = Stopwatch.StartNew();
            DateTime startTime = DateTime.Now;
            TimeSpan endTime;




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
                watch.Stop();
                workTimeWatch = (int)watch.ElapsedMilliseconds;
                workTimeSystem = (int)DateTime.Now.Subtract(startTime).TotalMilliseconds;
                return -1;
            }

            SwapNumber(ref digitArray[poviteIndex], ref digitArray[poviteIndex - 1]);
            Array.Sort(digitArray, poviteIndex, digitCount - poviteIndex);

            watch.Stop();
            workTimeWatch = (int)watch.ElapsedMilliseconds;
            workTimeSystem = (int)DateTime.Now.Subtract(startTime).TotalMilliseconds;

            return ArrayToNumber(digitArray);
        }

        public static Int32 InsertNumber(int numberSource, int numberIn, int shift, int startIndex)
        {
            if (shift > startIndex)
            {
                throw new ArgumentOutOfRangeException();
            }

            int size = startIndex - shift + 1;
            int result;
            CutNumber(ref numberIn, shift, size);
            int mask = ~PreSource(size, shift);
            result = (numberSource & mask) | numberIn;
            return result;
        }

        private static void CutNumber(ref int numberIn, int shift, int size)
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
