using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Lab2
{
    public static class GaussMethod
    {
        public static double[]? SolveCustomMatrix(bool showCalculations = false, bool useMainElement = false)
        {
            Console.Write("Matrix size: ");
            var MatrixSize = int.Parse(Console.ReadLine());
            var A = new double[MatrixSize, MatrixSize];
            var b = new double[MatrixSize];

            for (int i = 0; i < MatrixSize; i++)
            {
                for (int j = 0; j < MatrixSize; j++)
                {
                    Console.Write($"A[{i}][{j}] = ");
                    A[i, j] = double.Parse(Console.ReadLine());
                }
                Console.Write($"b[{i}] = ");
                b[i] = double.Parse(Console.ReadLine());
                Console.WriteLine();
            }
            return Solve(A, b, showCalculations: showCalculations, useMainElement: useMainElement);
        }

        public static double[]? SolveHilbertMatrix(uint size, bool showCalculations = false, bool useMainElement = false)
        {
            var A = new double[size, size];
            var b = new double[size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    A[i, j] = 1.0 / (i + j + 1); 
                }
                b[i] = (double)size / ((i + 1) * (i + 1));
            }
            return Solve(A, b, showCalculations: showCalculations, useMainElement: useMainElement);
        }

        private static void SequentialExclusion(ref double[,] A, ref double[] b, ref double[] result, ref int MatrixSize) {
            double Multi1, Multi2;
            for (int k = 0; k < MatrixSize; k++)
            {
                for (int j = k + 1; j < MatrixSize; j++)
                {
                    Multi1 = A[j, k] / A[k, k];
                    for (int i = k; i < MatrixSize; i++)
                    {
                        A[j, i] = A[j, i] - Multi1 * A[k, i];
                    }
                    b[j] = b[j] - Multi1 * b[k];
                }
            }
            for (int k = MatrixSize - 1; k >= 0; k--)
            {
                Multi1 = 0;
                for (int j = k; j < MatrixSize; j++)
                {
                    Multi2 = A[k, j] * result[j];
                    Multi1 += Multi2;
                }
                result[k] = (b[k] - Multi1) / A[k, k];
            }
        }

        private static void MainElement(ref double[,] A, ref double[] b, ref double[] result, ref int MatrixSize)
        {

        }

        public static double[]? Solve(double[,] A, double[] b, bool showCalculations = false, bool useMainElement = false)
        {
            if (A.GetLength(0) != A.GetLength(1))
                return null;
            if (A.GetLength(0) != b.Length)
                return null;

            var MatrixSize = A.GetLength(0);
            var Result = new double[MatrixSize];

            if (showCalculations)
            {
                Console.WriteLine("Augmented matrix:");
                for (int i = 0; i < MatrixSize; i++)
                {
                    for (int j = 0; j < MatrixSize; j++)
                    {
                        Console.Write($"{A[i, j]}\t");
                    }
                    Console.WriteLine($"|\t{b[i]}");
                }
                Console.WriteLine();
            }

            if (useMainElement)
                MainElement(ref A, ref b, ref Result, ref MatrixSize);
            else
                SequentialExclusion(ref A, ref b, ref Result, ref MatrixSize);

            if (showCalculations)
            {
                Console.WriteLine("Solved augmented matrix:");
                for (int i = 0; i < MatrixSize; i++)
                {
                    for (int j = 0; j < MatrixSize; j++)
                    {
                        Console.Write($"{A[i, j]}\t");
                    }
                    Console.WriteLine($"|\t{b[i]}");
                }
                Console.WriteLine();

                Console.WriteLine("Results:");
                for (int i = 0; i < MatrixSize; i++)
                {
                    Console.WriteLine($"{Result[i]}");
                }
                Console.WriteLine();
            }

            return Result;
        }
    }
}
