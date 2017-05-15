using ClassLibrary;
using Output = System.Console;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var operation = args[2];
            var test = new Calc();
            var result = test.Execute(operation, args);
            Output.WriteLine($"{args[0]} {operation} {args[1]} = {result}");
            Output.ReadKey();
        }
    }
}
