namespace ClassLibrary.DefaultOperations
{
    public class Difference : IOperation
    {
        public string Name => "dif";
        public double Calc(double x, double y)
        {
            return x - y;
        }
    }
}