using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public static class task2<T>
    {
        public static object? erfX(int x, bool showCalculations = false, bool useDoubleFactorial = false)
        {
            T? value = default;

            if (value is double)
            {
                return calcErfXDouble(x, showCalculations, useDoubleFactorial);
            }
            else if (value is float)
            {
                return calcErfXFloat(x, showCalculations, useDoubleFactorial);
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
            int i = 0;
            double sum = x;
            double prev;

            do
            {
                prev = sum;
                if (showCalculations)
                    Console.WriteLine($"{i}) sum = {sum}");
                i++;
                double tmp = a * (-x * x);
                double k = tmp * (2 * i - 1) / (i * (2 * i + 1));
                a = k;
                sum += a;
            } while (sum != prev);

            double result = 2 / Math.Sqrt(Math.PI) * sum;
            if (showCalculations)
                Console.WriteLine($"{++i}) Result: {result}");

            return result;
        }

        private static float calcConvertedErfXFloat(int x, bool showCalculations)
        {
            float a = x;
            int i = 0;
            float sum = x;
            double prev;

            do
            {
                prev = sum;
                if (showCalculations)
                    Console.WriteLine($"{i}) sum = {sum}");
                i++;
                float tmp = a * (-x * x);
                float k = tmp * (2 * i - 1) / (i * (2 * i + 1));
                a = k;
                sum += a;
            } while (sum != prev);

            float result = (float)(2 / Math.Sqrt(Math.PI) * sum);
            if (showCalculations)
                Console.WriteLine($"{++i}) Result: {result}");

            return result;
        }

        private static double calcErfXDouble(int x, bool showCalculations, bool useDoubleFactorial)
        {
            double result = 0;
            int i = 0;
            double prev;

            do
            {
                prev = result;
                result += Math.Pow(-1, i) * Math.Pow(x, 2 * i + 1) / 
                ((useDoubleFactorial ? FactorialDouble(Convert.ToDouble(i)) : FactorialInt(i)) * (2 * i + 1));
                i++;
                if (showCalculations)
                    Console.WriteLine($"{i}) sum = {result}");

            } while (prev != result);

            result *= 2 / Math.Sqrt(Math.PI);
            if (showCalculations)
                Console.WriteLine($"{++i}) Result: {result}");

            return result;
        }

        private static float calcErfXFloat(int x, bool showCalculations, bool useDoubleFactorial)
        {
            float result = 0f;
            int i = 0;
            float prev;

            do
            {
                prev = result;
                result += (float)(Math.Pow(-1, i) * Math.Pow(x, 2 * i + 1) / 
                ((useDoubleFactorial ? FactorialDouble(Convert.ToDouble(i)) : FactorialInt(i)) * (2 * i + 1)));
                i++;
                if (showCalculations)
                    Console.WriteLine($"{i}) sum = {result}");

            } while (prev != result);

            result *= (float)(2 / Math.Sqrt(Math.PI));
            if (showCalculations)
                Console.WriteLine($"{++i}) Result: {result}");

            return result;
        }
        private static double FactorialInt(int number)
        {
            if (number == 0)
                return 1;
            else
                return number * FactorialInt(number - 1);
        }

        private static double FactorialDouble(double number)
        {
            if (number == 0)
                return 1;
            else
                return number * FactorialDouble(number - 1);
        }
    }
}
