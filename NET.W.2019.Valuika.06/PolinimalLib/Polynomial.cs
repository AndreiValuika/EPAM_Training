using System;
using System.Text;

namespace PolinomialLib
{
    public class Polynomial
    {
        private double[] _coefficients;

        /// <summary>
        /// Constructor
        /// </summary>
       
        public Polynomial(double[] coff)
        {
            _coefficients = new double[coff.Length];
            for (int i = 0; i < _coefficients.Length; i++)
            {
                _coefficients[i] = coff[i];
            }
        }
        /// <summary>
        /// Return order of polynomial
        /// </summary>
        
        public int GetOrder()
        {
            return this._coefficients.Length;
        }

        /// <summary>
        /// Return array of coefficients
        /// </summary>
        /// <returns></returns>
        public double[] GetCoefficients()
        {
            return (double[])_coefficients.Clone();
        }

        /// <summary>
        /// Overload of "=="
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static bool operator ==(Polynomial first, Polynomial second)
        {
            if (first._coefficients.Length != second._coefficients.Length)
            {
                return false;
            }
            for (int i = 0; i < first._coefficients.Length; i++)
            {
                if (Math.Abs(first._coefficients[i] - second._coefficients[i]) > double.Epsilon)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Overload of "!="
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static bool operator !=(Polynomial first, Polynomial second)
        {
            return !(first == second);
        }
        /// <summary>
        /// Overload "+" two polynomial;
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static Polynomial operator +(Polynomial first, Polynomial second)
        {
            int resultOrder = first.GetOrder() > second.GetOrder() ? first.GetOrder() : second.GetOrder();
            int minOrder = first.GetOrder() < second.GetOrder() ? first.GetOrder() : second.GetOrder();

            double[] resultCoff = new double[resultOrder];
            var firstCoef = first.GetCoefficients();
            var secondCoef = second.GetCoefficients();

            for (int i = 0; i < minOrder; i++)
            {

                resultCoff[i] = firstCoef[i] + secondCoef[i];
            }

            if (first.GetOrder() > second.GetOrder())
                Array.Copy(firstCoef, minOrder, resultCoff, minOrder, resultOrder - minOrder);
            else
                Array.Copy(secondCoef, minOrder, resultCoff, minOrder, resultOrder - minOrder);

            return new Polynomial(resultCoff);
        }
        /// <summary>
        /// Overload "-" two polynomial;
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static Polynomial operator -(Polynomial first, Polynomial second)
        {

            return first + (-1) * second;
        }

        /// <summary>
        /// Overload "*"  polynomial and int;
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static Polynomial operator *(Polynomial first, int second)
        {

            var firstCoef = first.GetCoefficients();

            for (int i = 0; i < firstCoef.Length; i++)
            {
                firstCoef[i] *= second;
            }

            return new Polynomial(firstCoef);
        }

        /// <summary>
        /// Overload "*"  polynomial and int;
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static Polynomial operator *(int second, Polynomial first)
        {
            return first * second;
        }

        /// <summary>
        /// Overload "*"  polynomial and double;
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static Polynomial operator *(Polynomial first, double second)
        {

            var firstCoef = first.GetCoefficients();

            for (int i = 0; i < firstCoef.Length; i++)
            {
                firstCoef[i] *= second;
            }

            return new Polynomial(firstCoef);
        }

        /// <summary>
        /// Overload "*"  polynomial and double;
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static Polynomial operator *(double second, Polynomial first)
        {
            return first * second;
        }

        /// <summary>
        /// Overload "+"  polynomial and double;
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static Polynomial operator +(Polynomial first, double second)
        {
            var firstCoef = first.GetCoefficients();
            firstCoef[0] += second;

            return new Polynomial(firstCoef);
        }

        /// <summary>
        /// Overload "+"  polynomial and double;
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static Polynomial operator +(double second, Polynomial first)
        {
            return first + second;
        }

        /// <summary>
        /// Overload "+"  polynomial and int;
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static Polynomial operator +(Polynomial first, int second)
        {
            var firstCoef = first.GetCoefficients();
            firstCoef[0] += second;

            return new Polynomial(firstCoef);
        }

        /// <summary>
        /// Overload "+"  polynomial and int;
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static Polynomial operator +(int second, Polynomial first)
        {
            return first + second;
        }

        /// <summary>
        /// Overload "/"  polynomial and double;
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static Polynomial operator /(Polynomial first, double second)
        {
            return first * (double)(1 / second);
        }

        /// <summary>
        /// Overload "/"  polynomial and double;
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static Polynomial operator /(double second, Polynomial first)
        {
            var firstCoef = first.GetCoefficients();

            for (int i = 0; i < firstCoef.Length; i++)
            {
                firstCoef[i] = second / firstCoef[i];
            }

            return new Polynomial(firstCoef);
        }


        public override string ToString()
        {
            StringBuilder tempString = new StringBuilder();
            double[] tempArray = this.GetCoefficients();
            int index = this.GetOrder();
            for (int i = index - 1; i > 0; i--)
            {
                if (tempArray[i] > double.Epsilon)
                {
                    tempString.Append($"{tempArray[i]}*x^{i} + ");
                }
            }
            if (Math.Abs(tempArray[0]) > double.Epsilon)
            {
                tempString.Append($"{tempArray[0]}");
            }

            return tempString.ToString();
        }
        public override bool Equals(object obj)
        {
            Polynomial p = obj as Polynomial;
            if (p != this)
            {
                return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            int hash = 1;
            var hashArray = this.GetCoefficients();
            foreach (var item in hashArray)
            {
                hash *= (int)item;
            }
            return hash;
        }



    }
}
