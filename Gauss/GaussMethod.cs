

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

        private static void SequentialExclusion(ref double[,] A, ref double[] b, ref double[] result, ref int MatrixSize, bool showCalculations = false) {
            double Multi1;
            for (int k = 0; k < MatrixSize; k++)
            {
                if (showCalculations)
                {
                    string calculations = k == 0 ? "\nGaussian elimination\n" +
                        "Augmented matrix:\n" : $"Step #{k}:\n";
                    for (int i = 0; i < MatrixSize; i++)
                    {
                        for (int j = 0; j < MatrixSize; j++)
                        {
                            calculations += string.Format("{0, 23}", A[i, j]);
                        }
                        calculations += string.Format("  |  {0, 23}\n", b[i]);
                    }
                    Console.WriteLine(calculations);
                }
                for (int j = k + 1; j < MatrixSize; j++)
                {
                    Multi1 = A[j, k] / A[k, k];
                    for (int i = k; i < MatrixSize; i++)
                    {
                        A[j, i] -= Multi1 * A[k, i];
                    }
                    b[j] -= Multi1 * b[k];
                }
            }

            if (showCalculations)
            {
                string calculations = "Solved augmented matrix:\n";
                for (int i = 0; i < MatrixSize; i++)
                {
                    for (int j = 0; j < MatrixSize; j++)
                    {
                        calculations += string.Format("{0, 23}", A[i, j]);
                    }
                    calculations += string.Format("  |  {0, 23}\n", b[i]);
                }
                Console.WriteLine(calculations);
            }

            if (showCalculations)
                Console.WriteLine("Solving:");
            for (int k = MatrixSize - 1; k >= 0; k--)
            {
                Multi1 = 0;
                for (int j = k + 1; j < MatrixSize; j++)
                {
                    if (showCalculations)
                        Console.WriteLine($"{A[k, j]} * {result[j]} = {A[k, j] * result[j]}");
                    Multi1 += A[k, j] * result[j];
                }
                if (showCalculations)
                {
                    Console.WriteLine($"{b[k]} - {Multi1} = {b[k] - Multi1}");
                    Console.WriteLine();
                }
                result[k] = (b[k] - Multi1) / A[k, k];
            }

            if (showCalculations)
            {
                string calculations = "Results:\n";
                for (int i = 0; i < MatrixSize; i++)
                {
                    calculations += string.Format("{0, 23}\n", result[i]);
                }
                Console.WriteLine(calculations);
            }
        }

        private static void MainElement(ref double[,] A, ref double[] b, ref double[] result, ref int MatrixSize, bool showCalculations = false)
        {
            double Multi1;

            for (int k = 0; k < MatrixSize; k++)
            {
                SearchMainElement(k, ref A, ref b, ref MatrixSize);
                if (showCalculations)
                {
                    string calculations = k == 0 ? "\nGaussian elimination with main element selection\n" +
                        "Augmented matrix:\n" : $"Step #{k}:\n";
                    for (int i = 0; i < MatrixSize; i++)
                    {
                        for (int j = 0; j < MatrixSize; j++)
                        {
                            calculations += string.Format("{0, 23}", A[i, j]);
                        }
                        calculations += string.Format("  |  {0, 23}\n", b[i]);
                    }
                    Console.WriteLine(calculations);
                }

                var tmp = A[k, k];
                for (int j = k; j < MatrixSize; j++)
                {
                    A[k, j] /= tmp;
                }
                b[k] /= tmp;

                for (int j = k + 1; j < MatrixSize; j++)
                {
                    Multi1 = A[j, k] / A[k, k];
                    for (int i = k; i < MatrixSize; i++)
                    {
                        A[j, i] -= Multi1 * A[k, i];
                    }
                    b[j] -= Multi1 * b[k];
                }

            }

            if (showCalculations)
            {
                string calculations = "Solved augmented matrix:\n";
                for (int i = 0; i < MatrixSize; i++)
                {
                    for (int j = 0; j < MatrixSize; j++)
                    {
                        calculations += string.Format("{0, 23}", A[i, j]);
                    }
                    calculations += string.Format("  |  {0, 23}\n", b[i]);
                }
                Console.WriteLine(calculations);
            }

            if (showCalculations)
                Console.WriteLine("Solving:");
            for (int k = MatrixSize - 1; k >= 0; k--)
            {
                Multi1 = 0;
                for (int j = k + 1; j < MatrixSize; j++)
                {
                    if (showCalculations)
                        Console.WriteLine($"{A[k, j]} * {result[j]} = {A[k, j] * result[j]}");
                    Multi1 += A[k, j] * result[j];
                }
                if (showCalculations)
                {
                    Console.WriteLine($"{b[k]} - {Multi1} = {b[k] - Multi1}");
                    Console.WriteLine();
                }
                result[k] = b[k] - Multi1;
            }

            //TODO: Restore result positions

            if (showCalculations)
            {
                string calculations = "Results:\n";
                for (int i = 0; i < MatrixSize; i++)
                {
                    calculations += string.Format("{0, 23}\n", result[i]);
                }
                Console.WriteLine(calculations);
            }
        }

        private static void SearchMainElement(int curPosition, ref double[,] A, ref double[] b, ref int MatrixSize)
        {
            double max = A[curPosition, curPosition];
            int maxRow = curPosition, maxCol = curPosition;

            for (int row = curPosition; row < MatrixSize; row++)
            {
                for (int col = curPosition; col < MatrixSize; col++)
                {
                    if (max < Math.Abs(A[row, col]))
                    {
                        max = Math.Abs(A[row, col]);
                        maxRow = row;
                        maxCol = col;
                    }
                }
            }

            for (int col = curPosition; col < MatrixSize; col++)
            {
                var tmp = A[curPosition, col];
                A[curPosition, col] = A[maxRow, col];
                A[maxRow, col] = tmp;
            }

            for (int row = curPosition; row < MatrixSize; row++)
            {
                var tmp = A[row, curPosition];
                A[row, curPosition] = A[row, maxCol];
                A[row, maxCol] = tmp;
            }

            var meh = b[curPosition];
            b[curPosition] = b[maxRow];
            b[maxRow] = meh;
        }

        public static double[]? Solve(double[,] A, double[] b, bool showCalculations = false, bool useMainElement = false)
        {
            if (A.GetLength(0) != A.GetLength(1))
                return null;
            if (A.GetLength(0) != b.Length)
                return null;

            var MatrixSize = A.GetLength(0);
            var Result = new double[MatrixSize];

            if (useMainElement)
                MainElement(ref A, ref b, ref Result, ref MatrixSize, showCalculations: showCalculations);
            if (!useMainElement)
                SequentialExclusion(ref A, ref b, ref Result, ref MatrixSize, showCalculations: showCalculations);

            return Result;
        }
    }
}
