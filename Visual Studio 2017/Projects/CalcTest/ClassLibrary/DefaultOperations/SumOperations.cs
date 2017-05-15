namespace ClassLibrary.DefaultOperations
{
    public class SumOperations : IOperation
    {
        public string Name => "sum";

        public double Calc(double x, double y)
        {
            return x + y;
        }
    }
}