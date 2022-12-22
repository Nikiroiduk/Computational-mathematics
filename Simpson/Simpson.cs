
static double Simpson(Func<double, double> f, double a, double b, int n)
{
    var h = (b - a) / n;
    var sum1 = 0d;
    var sum2 = 0d;
    for (var k = 1; k <= n; k++)
    {
        var xk = a + k * h;
        if (k <= n - 1)
        {
            sum1 += f(xk);
        }

        var xk_1 = a + (k - 1) * h;
        sum2 += f((xk + xk_1) / 2);
    }

    var result = h / 3d * (1d / 2d * f(a) + sum1 + 2 * sum2 + 1d / 2d * f(b));
    return result;
}

static double Simpson2(Func<double, double> f, double a, double b, int n)
{
    var h = (b - a) / (2 * n);
    var sum1 = 0d;
    var sum2 = 0d;
    for (var k = 1; k < n; k++)
    {
        if (k % 2 == 0)
        {
            sum1 += f(a + k * 2 * h);
        }
        else
        {
            sum2 += f(a + k * 2 * h);
        }
    }

    var result = h / 3d * (f(a) + 2 * sum1 + 4 * sum2 + f(b));
    return result * 2;
}

double Runge(double fun1, double fun2, int n)
{
    var runge = Math.Abs(fun1 - fun2) / (Math.Pow(2, n) - 1);
    Console.WriteLine($"runge: {runge}");
    return runge;
}
double f(double x) => Math.Exp(x) + Math.Sin(x * 15);

double accuracy = .0001;
var n = 1;
while (true)
{
    double sim1 = Simpson(f, .5, .8, n);
    double sim2 = Simpson(f, .5, .8, n * 2);
    Console.WriteLine($"n = {n * 2}\tsimpson = {sim1}");
    if (Runge(sim1, sim2, n) <= accuracy || n > int.MaxValue)
    {
        Console.WriteLine($"{accuracy} accuracy: S = {sim1}");
        break;
    }
    n *= 2;
}

n = 1;
while (true)
{
    double sim1 = Simpson2(f, .5, .8, n);
    double sim2 = Simpson2(f, .5, .8, n * 2);
    Console.WriteLine($"n = {n * 2}\tsimpson = {sim1}");
    if (Runge(sim1, sim2, n) <= accuracy || n > int.MaxValue)
    {
        Console.WriteLine($"{accuracy} accuracy: S = {sim1}");
        break;
    }
    n *= 2;
}