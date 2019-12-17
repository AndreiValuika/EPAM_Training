using MatrixLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            SquareMatrix<int> squareMatrix = new SquareMatrix<int>(5);
            squareMatrix.Set(1, 2, 3);
            SymmetrixMatrix<int> symmetrixMatrix = new SymmetrixMatrix<int>(5);
            symmetrixMatrix.Set(1, 2, 3);

            Console.WriteLine(squareMatrix.ToString());
            Console.WriteLine();
            Console.WriteLine(symmetrixMatrix.ToString());
            DiagonalMatrix<int> diagonalMatrix = new DiagonalMatrix<int>(3);

            int[,] vs = {
                          { 1, 0, 0 },
                          { 0, 4, 0 },
                          { 0, 0, 5} 
                        };
            diagonalMatrix.ChengeValue += delegate (object obj, string msg) { Console.WriteLine(msg); };

            if (diagonalMatrix.SetMatrix(vs)) Console.WriteLine("OK");
            diagonalMatrix.Set(2, 4);
            Console.WriteLine(diagonalMatrix.Get(2));
            Console.WriteLine(diagonalMatrix.ToString());
            Console.ReadKey();

        }
    }
}
