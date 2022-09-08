using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public static class task2
    {
        public static float erfXOrig(int x)
        {
            float tmp = (float)(2 / Math.Sqrt(Math.PI));
            float sum = 0f;
            int n = 0;
            while (sum != float.NaN)
            {
                sum += (float)(Math.Pow(-1, n) * Math.Pow(x, 2 * n + 1) / (Factorial(n) * (2 * n + 1)));
                n++;
                Console.WriteLine(tmp * sum);
            }
            return 0f;
        } 

        private static int Factorial(int f)
        {
            if (f == 0)
                return 1;
            else
                return f * Factorial(f - 1);
        }
    }
}
