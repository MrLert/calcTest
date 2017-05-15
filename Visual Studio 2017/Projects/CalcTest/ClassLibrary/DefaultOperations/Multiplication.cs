namespace ClassLibrary.DefaultOperations
{
    public class Multiplication : IOperation
    {
        public string Name => "mult";
        public double Calc(double x, double y)
        {
            return y * x;
        }
    }
}