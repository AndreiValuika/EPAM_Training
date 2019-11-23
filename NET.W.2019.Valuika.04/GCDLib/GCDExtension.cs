using System;
using System.Diagnostics;

namespace GCDLib
{
    public static class GCDExtension
    {
        /// <summary>
        /// Find GCD numbers use Stein algorithm.
        /// </summary>
        /// <param name="tickTime">Return spent time</param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="integers"></param>
        /// <returns></returns>
        public static int GetMultipleGCDBinnary(this GCD obj, out int tickTime, int a, int b, params int[] integers)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int gCD = GetGCDBinnary(a, b);

            foreach (var item in integers)
            {
                gCD = GetGCDBinnary(gCD, item);
            }

            tickTime = (int)stopwatch.ElapsedTicks;
            return gCD;
        }

        /// <summary>
        /// Find GCD two numbers use Stein algorithm.
        /// </summary>
        /// <param name="tickTime">Return spent time</param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="integers"></param>
        /// <returns></returns>
        /// 
        private static int GetGCDBinnary(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);

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
                return a;
            }

            if (a == 1 || b == 1)
            {
                return 1;
            }

            if ((a % 2 == 0) && (b % 2 == 0))
            {
                return GetGCDBinnary(a >> 1, b >> 1) << 1;
            }

            if ((a % 2 == 0) && (b % 2 != 0))
            {
                return GetGCDBinnary(a >> 1, b);
            }

            if ((a % 2 != 0) && (b % 2 == 0))
            {
                return GetGCDBinnary(a, b >> 1);
            }

            return GetGCDBinnary(b, Math.Abs(a - b));
        }
    }
}
