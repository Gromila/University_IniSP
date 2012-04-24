using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab
{
    class Calculation
    {
        private const double eps = 1e-12;

        public static void Standart (double x, double low, double high, double step)
        {
            int k = Convert.ToInt32(Math.Floor((high - low)/step));
            double[] y = new double[k+3];
            int i = 1;
            y[0] = Math.Cos(x);
            Console.WriteLine("{0}. When x = {1}, y = {2}", 1, x, y[0]);
            x = low;
            while (x <= high)
            {
                y[i] = Math.Cos(x);
                Console.WriteLine("{0}. When x = {1}, y = {2}", i+1, x, y[i]);
                x += step;
                i++;
            }
        }

        static double Factorial (int n)
        {
            return (n == 0 ? 1 : Factorial(n - 1));
        }

        public static void Taylor (double x, double low, double high, double step, double e)
        {
            int k = Convert.ToInt32(Math.Floor((high - low) / step));
            int i;
            double a, s;
            x = low;
            do
            {
                a = 1;
                i = 0;
                s = 1;
                while (Math.Abs(a) > e)
                {
                    i++;
                    a *= -Math.Pow(x, 2*i)/Factorial(2*i);
                    s += a;
                }
                Console.WriteLine("When x = {0}, y = {1}", x, s);
                x += step;
            } while (x < (high + step/2));
        }
    }
}
