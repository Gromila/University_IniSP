using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Lab
{
    class Program
    {
        static void Main(string[] args)
        {
                   if ((args.Length < 12) && (args.Length > 0))
                   {
                        double x;
                        if (Double.TryParse(args[0], out x))
                        {
                            string type = "std";
                            double low = 1.0;
                            double high = 2.0;
                            double step = 0.5;
                            double e = 0.001;
                            for (int i = 1; i < args.Length; i++)
                            {
                                switch (args[i])
                                {
                                    case "/type":
                                        type = args[i+1];
                                        i++;
                                        break;
                                    case "/low":
                                        low = Double.Parse(args[i+1]);
                                        i++;
                                        break;
                                    case "/high":
                                        high = Double.Parse(args[i+1]);
                                        i++;
                                        break;
                                    case "/step":
                                        step = Double.Parse(args[i+1]);
                                        i++;
                                        break;
                                    case "/e":
                                        e = Double.Parse(args[i+1]);
                                        i++;
                                        break;
                                    default:
                                        Console.WriteLine("Incorrect parameter {0}", args[i]);
                                        break;
                                }
                            }
                            Console.WriteLine("Parameters: type: {0}, x: {1}, low: {2}, high: {3}, step: {4}, e: {5}",type,x,low,high,step,e);
                            if (type.Equals("std")) Calculation.Standart(x, low, high, step);
                            if (type.Equals("taylor")) Calculation.Taylor(x, low, high, step, e);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Failure input");
                    }
                    Console.WriteLine("");
        }
    }
}
