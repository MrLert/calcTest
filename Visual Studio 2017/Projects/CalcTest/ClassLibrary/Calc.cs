using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;

namespace ClassLibrary
{
    public class Calc
    {
        private string ExtendDLLDirectory { get; set; }
        public class OperationB
        {
            public OperationB(IOperation operation)
            {
                Operation = operation;

                var type = operation.GetType();
                Name = $"{type.Name}.{operation.Name}";
            }
            public IOperation Operation { get; set; }
            public string Name { get; set; }
        }

        public Calc() : this("")
        {
            
        }
        public Calc(string ExtendDLLDirectory)
        {
            
            operations = new List<IOperation>();
            DictionaryOperations = new Dictionary<string, IOperation>();
            //var assem = Assembly.GetAssembly(typeof(IOperation));
            var types = new List<Type>();
            var path = string.IsNullOrWhiteSpace(ExtendDLLDirectory)
                ? Directory.GetCurrentDirectory()
                : ExtendDLLDirectory;
            //найти длл рядом с экзе
            var dlls = Directory.GetFiles(path, "*.dll");
            foreach (var dll in dlls)
            {
                //загрузить её как сборку
                var assem = Assembly.LoadFrom(dll);
                //добавить типы
                types.AddRange(assem.GetTypes());
            }
            var ioper = typeof(IOperation);
            foreach (var type in types)
            {
                var interfaces = type.GetInterfaces();
                if (interfaces.Any(x=>x.FullName == ioper.FullName))
                {
                    if (type.IsInterface)
                        continue;
                    var oper = (IOperation) Activator.CreateInstance(type);
                    
                    if (oper != null)
                    {
                        var nameProject = type.FullName.Split('.').First()+ "." + type.FullName.Split('.').Last();
                       
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
        /// 
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


        public object Execute(string operation, object[] args)
        {
            var oper = operations.FirstOrDefault(x => x.Name == operation);
            return Execute(oper, args);
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
