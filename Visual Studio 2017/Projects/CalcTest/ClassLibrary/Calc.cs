using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ClassLibrary
{
    public class Calc
    {
        public List<string> TypeOperation;
        public Calc()
        {
            TypeOperation = new List<string>();
            operations = new List<IOperation>();
            DictionaryOperations = new Dictionary<string, IOperation>();
            //var assem = Assembly.GetAssembly(typeof(IOperation));
            var types = new List<Type>();
            //найти длл рядом с экзе
            var dlls = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.dll");
            foreach (var dll in dlls)
            {
                //загрузить её как сборку
                var assem = Assembly.LoadFrom(dll);
                //добавить типы
                types.AddRange(assem.GetTypes());
            }
            foreach (var type in types)
            {
                var interfaces = type.GetInterfaces();
                if (interfaces.Contains(typeof(IOperation)))
                {
                    if (type.IsInterface)
                        continue;
                    var oper = Activator.CreateInstance(type) as IOperation;
                    
                    if (oper != null)
                    {
                        var nameProject = type.FullName.Split('.').First()+ "." + type.FullName.Split('.').Last();
                        TypeOperation.Add(nameProject);
                        operations.Add(oper);
                        DictionaryOperations.Add(nameProject,oper);
                    }
                }
            }
        }

        public Dictionary<string, IOperation> DictionaryOperations;
        /// <summary>
        /// Список доступных операций
        /// </summary>
        public IList<IOperation> operations { get; set; }
        /// <summary>
        /// Выполнить операцию
        /// </summary>
        /// <param name="operation">Название операции</param>
        /// <param name="args">Аргументы операции</param>
        /// <returns></returns>
        public object Execute(IOperation operation,object[] args)
        {
            double result, z, y;
            double.TryParse(args[0].ToString(), out z);
            double.TryParse(args[1].ToString(), out y);
                
            var operArgs = operation as IOperationArgs;
            if (operArgs != null)
            {
                result = operArgs.Calc(args.Select(x=>double.Parse(x.ToString())));
            }
            else
            {
                result = operation.Calc(z, y);
            }
            return result;
        }

        //[Obsolete ("Не используйте")]
        //public double Sum(double x,double y)
        //{
        //    return (double) Execute("sum", new object[]  {x, y});
        //}
        //[Obsolete("Не используйте")]
        //public double Divide(double x, double y)
        //{
        //    return (double) Execute("divide", new object[] {x, y});
        //}
    }
}
