using Lab1;

Console.WriteLine($"Double zero ≈ {task1<double>.getZero()}");
Console.WriteLine($"Float zero ≈ {task1<float>.getZero()}");

Console.WriteLine($"Double infinity ≈ {task1<double>.getInfinity()}");
Console.WriteLine($"Float infinity ≈ {task1<float>.getInfinity()}");

Console.WriteLine($"erf(3) double = {task2<double>.erfX(3)}");
Console.WriteLine($"erf(3) float = {task2<float>.erfX(3)}");

Console.WriteLine($"converted erf(3) double = {task2<double>.convertedErfX(3, showCalculations: true)}");
Console.WriteLine($"converted erf(3) float = {task2<float>.convertedErfX(3, showCalculations: true)}");
