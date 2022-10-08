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
    public static class Task2<T>
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
                i++;
                double tmp = a * (-x * x);
                double k = tmp * (2 * i - 1) / (i * (2 * i + 1));
                a = k;
                if (showCalculations)
                    Console.WriteLine($"{i}) sum = {sum}\t a: {a}");
                sum += k;
            } while (sum != prev);

            double result = 2 / Math.Sqrt(Math.PI) * sum;
            if (showCalculations)
                Console.WriteLine($"{i}) Result: {result}");

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
                i++;
                float tmp = a * (-x * x);
                float k = tmp * (2 * i - 1) / (i * (2 * i + 1));
                a = k;
                if (showCalculations)
                    Console.WriteLine($"{i}) sum = {sum}\t a: {a}");
                sum += k;
            } while (sum != prev);

            float result = (float)(2 / Math.Sqrt(Math.PI) * sum);
            if (showCalculations)
                Console.WriteLine($"{i}) Result: {result}");

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



//sum,3               //a,3
//sum,6               //a,9
//sum,18.3            //a,24.3
//sum,33.77143        //a,52.07143 
//sum,57.353577       //a,91.12501 
//sum,76.84871        //a,134.20229 
//sum,93.484955       //a,170.33366 
//sum,96.315414       //a,189.80037 
//sum,92.08937        //a,188.40479 
//sum,76.48332        //a,168.5727
//sum,60.78302        //a,137.26634 
//sum,41.759827       //a,102.54285 
//sum,28.994736       //a,70.75456
//sum,16.360756       //a,45.35549
//sum,10.785513       //a,27.146269 
//sum,4.4514256       //a,15.236938 
//sum,3.5999117       //a,8.051337
//sum,0.4189911       //a,4.018903
//sum,1.4818412       //a,1.9008323 
//sum,0.627621        //a,0.8542202 
//sum,0.9932689       //a,0.3656479 
//sum,0.8438513       //a,0.1494175 8
//sum,0.90226         //a,0.0584086 92
//sum,0.880377        //a,0.0218829 96
//sum,0.8882481 5     //a,0.0078711 79
//sum,0.8855256 4     //a,0.0027225 02
//sum,0.8864324 7     //a,0.0009068 421
//sum,0.8861412       //a,0.0002912 8868
//sum,0.8862315 4     //a,0.0000903 43296
//sum,0.8862045       //a,0.0000270 87148
//sum,0.8862123 5     //a,0.0000078 59714
//sum,0.8862101 4     //a,0.0000022 094127
//sum,0.8862107 4     //a,0.0000006 0227745
//sum,0.8862105 6     //a,0.0000001 5935427
//sum,0.8862106       //a,0.0000000 40959346


//sum,3                       //a,3                                    
//sum,6                       //a,9                                    
//sum,18.3                    //a,24.3                                 
//sum,33.77142857142857       //a,52.07142857142857                    
//sum,57.35357142857143       //a,91.125                               
//sum,76.84870129870129       //a,134.2022727272727                    
//sum,93.48495254745254       //a,170.33365384615382                   
//sum,96.31540459540454       //a,189.80035714285708                   
//sum,92.08936168610802       //a,188.40476628151256                   
//sum,76.4833239341927        //a,168.57268562030072                   
//sum,60.78300578519503       //a,137.26632971938773                   
//sum,41.75982550715389       //a,102.54283129234892                   
//sum,28.99472808456686       //a,70.75455359172075                    
//sum,16.360754987049006      //a,45.355483071615865                   
//sum,10.785507048425515      //a,27.14626203547452                    
//sum,4.4514271263247025      //a,15.236934174750218                   
//sum,3.599907409196719       //a,8.051334535521422                    
//sum,0.4189940312232174 3    //a,4.018901440419937                    
//sum,1.4818377311375635      //a,1.9008317623607809                   
//sum,0.6276177893479008      //a,0.8542199417896627                   
//sum,0.9932655936993295      //a,0.3656478043514288                   
//sum,0.8438480523862872      //a,0.1494175413130423 3                 
//sum,0.9022567276268402      //a,0.0584086752405529 04                
//sum,0.8803737364405091      //a,0.0218829911863311 08                
//sum,0.8882449143927353      //a,0.0078711779522262 4                 
//sum,0.8855224128422006      //a,0.0027225015505347 23                
//sum,0.8864292547955355      //a,0.0009068419533348 605               
//sum,0.8861379661681006      //a,0.0002912886274348 34                
//sum,0.8862283094454065      //a,0.0000903432773059 1655              
//sum,0.8862012223026491      //a,0.0000270871427574 13902             
//sum,0.8862090820145639      //a,0.0000078597119148 56165             
//sum,0.8862068726024589      //a,0.0000022094121050 97816             
//sum,0.886207474879701       //a,0.0000006022772421 107989            
//sum,0.8862073155254782      //a,0.0000001593542228 1086268           
//sum,0.8862073564848116      //a,0.0000000409593334 846335            
//sum,0.8862073462490989      //a,0.0000000102357127 13866157          
//sum,0.8862073487379195      //a,0.0000000024888205 57138689          
//sum,0.8862073481486744      //a,0.0000000005892450 832577004         
//sum,0.8862073482846076      //a,0.0000000001359331 6172212844        
//sum,0.8862073482540326      //a,0.0000000000305750 3442824895        
//sum,0.8862073482607421      //a,0.0000000000067095 21443976852       
//sum,0.8862073482593048      //a,0.0000000000014373 320989300985      
//sum,0.8862073482596056      //a,0.0000000000003007 5268288537357     
//sum,0.8862073482595441      //a,0.0000000000000615 0115006878129     
//sum,0.8862073482595564      //a,0.0000000000000122 9708899485591     
//sum,0.8862073482595539      //a,0.0000000000000024 053646605322548   
//sum,0.8862073482595544      //a,0.0000000000000004 604940759644499   
//sum,0.8862073482595543      //a,0.0000000000000000 86323301586169    