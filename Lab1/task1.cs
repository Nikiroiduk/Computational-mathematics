using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public static class task1
    {

        public static float getMachineZeroFloat()
        {
            float x = 1.0f;
            while (x > 0)
            {
                if (x / 2 <= 0) break;
                x /= 2;
            }
            return x;
        }

        public static float getMachineInfinityFloat()
        {
            float x = 1.0f;
            while (x < float.MaxValue)
            {
                if (x * 2 > float.MaxValue) break;
                x *= 2;
            }
            return x;
        }

        public static double getMachineZeroDouble()
        {
            double x = 1.0;
            while (x > 0)
            {
                if (x / 2 <= 0) break;
                x /= 2;
            }
            return x;
        }

        public static double getMachineInfinityDouble()
        {
            double x = 1.0f;
            while (x < double.MaxValue)
            {
                if (x * 2 > double.MaxValue) break;
                x *= 2;
            }
            return x;
        }
    }
}
