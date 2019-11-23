using System;
using System.Diagnostics;

namespace GCDLib
{
    public class GCD
    {
        /// <summary>
        /// Find GCD numbers use Euclidean algorithm.
        /// </summary>
        /// <param name="tickTime">Return spent time</param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="integers"></param>
        /// <returns></returns>
        public static int GetGCD(out int tickTime, int a, int b, params int[] integers)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int gCD = GetGCD(a, b);

            foreach (var item in integers)
            {
                gCD = GetGCD(gCD, item);
            }

            tickTime = (int)stopwatch.ElapsedTicks;
            return gCD;
        }

        /// <summary>
        /// Find GCD of two numbers use  Euclidean algorithm
        /// <summary> 
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private static int GetGCD(int a, int b)
        {
            if (a == 0)
            {
                return b;
            }

            if (b == 0)
            {
                return a;
            }

            if (a == b)
            {
                return b;
            }

            a = Math.Abs(a);
            b = Math.Abs(b);

            while (a != b)
            {
                if (a > b)
                {
                    a -= b;
                }
                else
                {
                    b -= a;
                }
            }

            return a;
        }
    }
}