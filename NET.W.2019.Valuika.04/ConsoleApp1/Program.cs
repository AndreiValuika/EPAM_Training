using System;
using DoubleLibrary;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            double d = 255.255d;
            Console.WriteLine(d.ToBitString());
            //unsafe
            //{
            //    double f = -0.0d;
            //    double* fadr;


                
            //    fadr = &f;
            //    long* adr = (long*)fadr;
            //    int j = 0;
            //    char[] result = new char[64];
            //    //result[0] = *adr < 0 ? '1' : '0';
            //    for (int i = 64 - 1; i >= 0; i--)
            //    {
            //        result[j++] = (*adr & (1L << i)) != 0 ? '1' : '0';
            //    }
            //    Console.WriteLine(result);
            //    // long zadr = *adr;


            //}
            

            //Console.WriteLine(DoubleLibrary.FloatToBit.GetBinFraction(0.02d));
            //Console.WriteLine(DoubleLibrary.FloatToBit.GetBinInt(11));
            //double d = double.NegativeInfinity;
            //Console.WriteLine(DoubleLibrary.FloatToBit.ToBitString(255.255d));
            //Console.WriteLine(d.DoubleToBinaryString()); 

        }
    }
}
