using Lab1;

Console.WriteLine($"Double zero\t ≈ {task1<double>.getZero()}");
Console.WriteLine($"Float zero\t ≈ {task1<float>.getZero()}");

Console.WriteLine($"Double infinity\t ≈ {task1<double>.getInfinity()}");
Console.WriteLine($"Float infinity\t ≈ {task1<float>.getInfinity()}");

Console.WriteLine($"erf(3) double n-int\t = {task2<double>.erfX(3, showCalculations: false)}");
Console.WriteLine($"erf(3) float n-int\t = {task2<float>.erfX(3)}");

Console.WriteLine($"erf(3) double n-double\t = {task2<double>.erfX(3, useDoubleFactorial: true)}");
Console.WriteLine($"erf(3) float n-double\t = {task2<float>.erfX(3, useDoubleFactorial: true)}");

Console.WriteLine($"converted erf(3) double\t = {task2<double>.convertedErfX(3, showCalculations: false)}");
Console.WriteLine($"converted erf(3) float\t = {task2<float>.convertedErfX(3)}");
