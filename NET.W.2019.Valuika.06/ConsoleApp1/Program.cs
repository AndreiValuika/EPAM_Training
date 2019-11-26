using System;

namespace ConsoleApp1
{
    class Program
    {
       public static void Main(string[] args)
        {
            int[][] test = new int[4][]
            {
                new int[] { 10, 20, 30, 40, 50, 60 },
                new int[] { 11, 21, 31 },
                new int[] { 12, 22, 32, 42, 52, 62 },
                new int[] { 100 }
            };

            //SortJaggedArray.JaggedArray.SortF(test, false);
            //SortJaggedArray.JaggedArray.SortF(test, true);
            //SortJaggedArray.JaggedArray.SortS(test, false);
            //SortJaggedArray.JaggedArray.SortS(test, true);
            //SortJaggedArray.JaggedArray.SortT(test, false);
            //SortJaggedArray.JaggedArray.SortT(test, true);
            Console.WriteLine(test);
        }
    }
}
