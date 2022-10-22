using Lab2;

GaussMethod.SolveHilbertMatrix(5, showCalculations: true);
GaussMethod.SolveHilbertMatrix(5, useMainElement: true, showCalculations: true);

//GaussMethod.SolveCustomMatrix(showCalculations: true, useMainElement: true);
//GaussMethod.SolveCustomMatrix(showCalculations: true, useMainElement: false);

foreach (var item in GaussMethod.Solve(new double[,] { { 1, 2, 3, 1, -3 }, { 4, 3, 4, -2, 7 }, { 3, 5, 1, 3, 2 }, { 1, 4, -3, 3, 6 }, { 3, 5, 1, -4, 2} }, new double[] { -1, 9, 4, -2, 4 }))
    Console.WriteLine(item);
Console.WriteLine();
foreach (var item in GaussMethod.Solve(new double[,] { { 1, 2, 3, 1, -3 }, { 4, 3, 4, -2, 7 }, { 3, 5, 1, 3, 2 }, { 1, 4, -3, 3, 6 }, { 3, 5, 1, -4, 2 } }, new double[] { -1, 9, 4, -2, 4 }, useMainElement: true))
    Console.WriteLine(item);
Console.WriteLine();
Console.WriteLine();

foreach (var item in GaussMethod.Solve(new double[,] { { 1, 2, 3, 1 }, { 4, 3, 4, -2 }, { 3, 5, 1, 3 }, { 1, 4, -3, 3 }, }, new double[] { -1, 9, 4, -2 }))
    Console.WriteLine(item);
Console.WriteLine();
foreach (var item in GaussMethod.Solve(new double[,] { { 1, 2, 3, 1 }, { 4, 3, 4, -2 }, { 3, 5, 1, 3 }, { 1, 4, -3, 3 }, }, new double[] { -1, 9, 4, -2 }, useMainElement: true))
    Console.WriteLine(item);
Console.WriteLine();
Console.WriteLine();

foreach (var item in GaussMethod.Solve(new double[,] { { 1, 3, 1 }, { 3, 4, -2 }, { 3, 5, 3 } }, new double[] { 9, 4, -2 }))
    Console.WriteLine(item);
Console.WriteLine();
foreach (var item in GaussMethod.Solve(new double[,] { { 1, 3, 1 }, { 3, 4, -2 }, { 3, 5, 3 } }, new double[] { 9, 4, -2 }, useMainElement: true))
    Console.WriteLine(item);
Console.WriteLine();
Console.WriteLine();

foreach (var item in GaussMethod.Solve(new double[,] { { 1, 2 }, { 4, 3 } }, new double[] { 9, -2 }))
    Console.WriteLine(item);
Console.WriteLine();
foreach (var item in GaussMethod.Solve(new double[,] { { 1, 2 }, { 4, 3 } }, new double[] { 9, -2 }, useMainElement: true))
    Console.WriteLine(item);
Console.WriteLine();
Console.WriteLine();

//for (int i = 0; i < MatrixSize; i++)
//{
//    Console.WriteLine($"X[{i + 1}] = {Result[i]}");
//}