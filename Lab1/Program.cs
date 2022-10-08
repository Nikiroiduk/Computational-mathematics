using Lab1;

Console.WriteLine($"Real double zero  = {double.Epsilon}");
Console.WriteLine($"Double zero       = {Task1<double>.getZero()}");
Console.WriteLine($"Real float zero   = {float.Epsilon}");
Console.WriteLine($"Float zero        = {Task1<float>.getZero()}");

Console.WriteLine();

Console.WriteLine($"Real double infinity   = {double.MaxValue}");
Console.WriteLine($"Real double infinity/2 = {double.MaxValue / 2}");
Console.WriteLine($"Double infinity        = {Task1<double>.getInfinity()}");
Console.WriteLine($"Real float infinity    = {float.MaxValue}");
Console.WriteLine($"Real float infinity/2  = {float.MaxValue / 2}");
Console.WriteLine($"Float infinity         = {Task1<float>.getInfinity()}");

Console.WriteLine();

Console.WriteLine($"erf(3) double n-int\t= {Task2<double>.erfX(3)}");
Console.WriteLine($"erf(3) float n-int\t= {Task2<float>.erfX(3)}");

Console.WriteLine($"erf(3) double n-double\t= {Task2<double>.erfX(3, useDoubleFactorial: true)}");
Console.WriteLine($"erf(3) float n-double\t= {Task2<float>.erfX(3, useDoubleFactorial: true)}");

Console.WriteLine($"converted erf(3) double\t= {Task2<double>.convertedErfX(3)}");
Console.WriteLine($"converted erf(3) float\t= {Task2<float>.convertedErfX(3, showCalculations: true)}");
