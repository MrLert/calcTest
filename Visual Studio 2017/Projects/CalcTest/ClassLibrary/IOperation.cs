using System.Collections;
using System.Collections.Generic;

namespace ClassLibrary
{
    public interface IOperation
    {
        string Name { get; }
        double Calc(double x, double y);
    }

    public interface IOperationArgs : IOperation
    {
        double Calc(IEnumerable<double> args);
    }
}