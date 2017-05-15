namespace ClassLibrary
{
    public interface IOperation
    {
        string Name { get; }
        double Calc(double x, double y);
    }
}