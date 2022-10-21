using Lab2;
using System.Drawing;
using System.Runtime.ExceptionServices;

GaussMethod.SolveHilbertMatrix(3, showCalculations: true, useMainElement: true);
GaussMethod.SolveHilbertMatrix(3, showCalculations: true, useMainElement: false);

//GaussMethod.SolveCustomMatrix(showCalculations: true, useMainElement: true);
//GaussMethod.SolveCustomMatrix(showCalculations: true, useMainElement: false);

GaussMethod.Solve(new double[,] { { 1, 2, 3 }, { 4, 3, 4 }, { 3, 5, 1 }, }, new double[] { -1, 9, 4 }, showCalculations: true);
GaussMethod.Solve(new double[,] { { 1, 2, 3 }, { 4, 3, 4 }, { 3, 5, 1 }, }, new double[] { -1, 9, 4 }, showCalculations: true, useMainElement: true);

//for (int i = 0; i < MatrixSize; i++)
//{
//    Console.WriteLine($"X[{i + 1}] = {Result[i]}");
//}