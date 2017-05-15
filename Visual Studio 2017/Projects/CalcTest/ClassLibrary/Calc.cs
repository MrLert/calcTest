using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ClassLibrary
{
    public class Calc
    {
        public Calc()
        {
            operations = new List<IOperation>();
            var assem = Assembly.GetAssembly(typeof(IOperation));
            var types = assem.GetTypes();
            foreach (var type in types)
            {
                var interfaces = type.GetInterfaces();
                if (interfaces.Contains(typeof(IOperation)))
                {
                    var oper = Activator.CreateInstance(type) as IOperation;
                    if (oper != null)
                    {
                        operations.Add(oper);
                    }
                }
            }
        }
        /// <summary>
        /// Список доступных операций
        /// </summary>
        private IList<IOperation> operations { get; set; }

        /// <summary>
        /// Выполнить операцию
        /// </summary>
        /// <param name="operation">Название операции</param>
        /// <param name="args">Аргументы операции</param>
        /// <returns></returns>
        public object Execute(string operation,object[] args)
        {
            double result;
            var oper = operations.FirstOrDefault(x => x.Name == operation);
            if (oper == null)
            {
                return "Error";
            }
            {
                double x;
                double.TryParse(args[0].ToString(), out x);
                double y;
                double.TryParse(args[1].ToString(), out y);
                result = oper.Calc(x, y);
            }
            return result;
        }

        [Obsolete ("Не используйте")]
        public double Sum(double x,double y)
        {
            return (double) Execute("sum", new object[]  {x, y});
        }
        [Obsolete("Не используйте")]
        public double Divide(double x, double y)
        {
            return (double) Execute("divide", new object[] {x, y});
        }
    }
}
