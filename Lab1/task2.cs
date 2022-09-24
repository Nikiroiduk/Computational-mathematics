using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public static class task2<T>
    {
        public static object? erfX(int x, bool showCalculations = false)
        {
            T? value = default;

            if (value is double)
            {
                return calcErfXDouble(x, showCalculations);
            }
            else if (value is float)
            {
                return calcErfXFloat(x, showCalculations);
            }
            return null;
        }

        public static object? convertedErfX(int x, bool showCalculations = false)
        {
            T? value = default;

            if (value is double)
            {
                return calcConvertedErfXDouble(x, showCalculations);
            }
            else if (value is float)
            {
                return calcConvertedErfXFloat(x, showCalculations);
            }
            return null;
        }

        private static double calcConvertedErfXDouble(int x, bool showCalculations)
        {
            double a = x;
            double result = x;
            int i = 1;
            double prev;

            do
            {
                prev = result;
                a *= -x * x * (2 * i - 1) / (i * (2 * i + 1));
                result += a;
                i++;
                if (showCalculations)
                    Console.WriteLine($"result: {result} \t a: {a}");
            } while (prev != result);

            return result * (2 / Math.Sqrt(Math.PI));

            //double res = 1;
            //double term = 1;

            //for (int i = 1; i < 100; i++)
            //{
            //    term *= -x * x / i;
            //    res += term / (2 * i + 1);
            //}

            //return 2 / Math.Sqrt(Math.PI) * res;
        }

        private static double calcConvertedErfXFloat(int x, bool showCalculations)
        {


            return 0;
        }

        private static double calcErfXDouble(int x, bool showCalculations)
        {
            if (showCalculations)
                Console.WriteLine($"erf({x}):");
            double result = 0;
            int i = 0;
            double prev;

            do
            {
                prev = result;
                result += Math.Pow(-1, i) * Math.Pow(x, 2 * i + 1) / 
                                (Factorial(i) * (2 * i + 1));
                i++;
                if (showCalculations)
                    Console.WriteLine($"{i}) sum = {result}");

            } while (prev != result);

            result *= 2 / Math.Sqrt(Math.PI);
            if (showCalculations)
                Console.WriteLine($"{++i}) Result: {result}");

            return result;
        }

        private static float calcErfXFloat(int x, bool showCalculations)
        {
            if (showCalculations)
                Console.WriteLine($"erf({x}):");
            float result = 0f;
            int i = 0;
            float prev;

            do
            {
                prev = result;
                result += (float)(Math.Pow(-1, i) * Math.Pow(x, 2 * i + 1) / 
                                    (Factorial(i) * (2 * i + 1)));
                i++;
                if (showCalculations)
                    Console.WriteLine($"{i}) sum = {result}");

            } while (prev != result);

            result *= (float)(2 / Math.Sqrt(Math.PI));
            if (showCalculations)
                Console.WriteLine($"{++i}) Result: {result}");

            return result;
        }
        private static double Factorial(int number)
        {
            if (number == 0)
                return 1;
            else
                return number * Factorial(number - 1);
        }
    }
}
