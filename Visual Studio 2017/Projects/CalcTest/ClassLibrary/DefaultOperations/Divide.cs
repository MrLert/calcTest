using System;

namespace ClassLibrary.DefaultOperations
{
    public class Divide : IOperation
    {
        public string Name => "divide";
        public double Calc(double x, double y)
        {
            return y == 0 ? Double.NaN : x / y;
        }
    }
}