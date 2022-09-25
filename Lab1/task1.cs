using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public static class Task1<T>
    {
        public static object? getZero()
        {
            T? value = default;
            if (value is double d)
            {
                d += 1;
                double tmp = 0;
                while (d != 0)
                {
                    tmp = d;
                    d /= 2;
                }
                return tmp;
            }
            else if (value is float f)
            {
                f += 1;
                float tmp = 0;
                while (f != 0)
                {
                    tmp = f;
                    f /= 2;
                }
                return tmp;
            }
            return null;
        }

        public static object? getInfinity()
        {
            T? value = default;
            if (value is double d)
            {
                d += 1;
                double tmp = 0;
                while (d < double.PositiveInfinity)
                {
                    tmp = d;
                    d *= 2;
                }
                return tmp;
            }
            else if (value is float f)
            {
                f += 1;
                float tmp = 0f;
                while (f < float.PositiveInfinity)
                {
                    tmp = f;
                    f *= 2;
                }
                return tmp;
            }
            return null;
        }
    }
}
