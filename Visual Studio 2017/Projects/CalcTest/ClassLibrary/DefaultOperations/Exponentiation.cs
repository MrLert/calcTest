using System;

namespace ClassLibrary.DefaultOperations
{
    public class Exponentiation : IOperation
    {
        public string Name => "exponent";
        public double Calc(double x, double y)
        {
            return Math.Pow(x, y);
        }
    }
}