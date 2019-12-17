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
            SquareMatrix<int> squareMatrix = new SquareMatrix<int>(3);
            squareMatrix.Set(1, 2, 3);
            SymmetrixMatrix<int> symmetrixMatrix = new SymmetrixMatrix<int>(3);
            symmetrixMatrix.Set(1, 2, 3);

            Console.WriteLine(squareMatrix.ToString());
            Console.WriteLine();
            
            DiagonalMatrix<int> diagonalMatrix = new DiagonalMatrix<int>(3);

            int[,] diagMatrix = {
                          { 1, 0, 0 },
                          { 0, 4, 0 },
                          { 0, 0, 5 } 
                        };

            int[,] symmMatrix = {
                          { 1, 2, 3 },
                          { 0, 4, 0 },
                          { 0, 0, 5 }
                        };

            diagonalMatrix.ChengeValue += delegate (object obj, string msg) { Console.WriteLine(msg); };

            if (diagonalMatrix.SetMatrix(diagMatrix)) Console.WriteLine("OK");
            symmetrixMatrix.SetMatrix(symmMatrix);
            Console.WriteLine(symmetrixMatrix.ToString());
            Console.WriteLine();
            var sumMatrix=symmetrixMatrix.Add(diagonalMatrix);

          
            Console.WriteLine(sumMatrix.ToString());
            Console.ReadKey();

        }
    }
}
