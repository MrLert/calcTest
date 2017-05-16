using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace ClassLibrary.DefaultOperations
{
    public class Divide : IOperationArgs
    {
        public string Name => "divide";
        public double Calc(double x, double y)
        {
            return y == 0 ? Double.NaN : x / y;
        }

        public double Calc(IEnumerable<double> args)
        {
            var x = args.First();
            var result = x;
            foreach (var arg in args)
            {
                result /= arg;
            }
            return result*x;
        }
    }
}