using System;

namespace Numbers
{
    public partial class Numbers
    {
        /// <summary>
        /// Return root N degree with predetermined accuracy 
        /// </summary>
        /// <param name="number"></param>
        /// <param name="degree"></param>
        /// <param name="eps"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">When predetermined accuracy less then zero </exception>
        public static double FindNthRoot(double number, int degree, double eps)
        {
            if (eps <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            double x0 = 1 + ((number - 1) / 2);
            double x1 = x0 * (1 - ((1 - (number / Pow(x0, degree))) / degree));

            while (Math.Abs(x1 - x0) > eps)
            {
                x0 = x1;
                x1 = x0 * (1 - ((1 - (number / Pow(x0, degree))) / degree));
            }

            x1 = Math.Round(x1, GetAccuracy(eps));
            return x1;
        }

        /// <summary>
        /// Calculates the power of a number.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="pow"></param>
        /// <returns></returns>
        private static double Pow(double a, int pow)
        {
            double result = 1;
            for (int i = 0; i < pow; i++)
            {
                result *= a;
            }

            return result;
        }

        /// <summary>
        /// Return accuracy format "digit after dot"
        /// </summary>
        /// <param name="eps"></param>
        /// <returns></returns>
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
    }
}
