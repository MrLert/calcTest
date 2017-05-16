using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary.DefaultOperations
{
    public class SumOperations : IOperationArgs
    {
        public string Name => "sum";
        public double Calc(double x, double y)
        {
            return x + y;
        }

        public double Calc(IEnumerable<double> args)
        {
            return args.Sum();
        }
    }
}