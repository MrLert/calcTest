using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebCalcNew.Helpers;

namespace WebCalcNew.Managers
{
    public class OperationManager : IOperationResultRepository
    {
        public OperationResult Load(long id)
        {
           throw new NotImplementedException();
        }

        public void Save(OperationResult entity)
        {
            var fields = new List<object>()
            {
                entity.OperationName,
                entity.Arguments,
                entity.Result,
                entity.ExecutionTime,
                entity.ExecutionDate.ToString("MM-dd-yyyy HH:mm:ss")
            };
            DBHelper.InsertTable("OperationResult", fields);
        }

        public void Update(OperationResult entity)
        {
            var fields = new List<object>()
            {
                entity.OperationName,
                entity.Arguments,
                entity.Result,
                entity.ExecutionTime,
                entity.ExecutionDate.ToString("MM-dd-yyyy HH:mm:ss")
            };
            DBHelper.ChangeOper("OperationResult", fields);
        }

        public IEnumerable<OperationResult> GetAll()
        {
            var items = new List<OperationResult>();
            //Подключиться к базе
            //Вытащить все записи
            var records = DBHelper.GetAllFromTable("OperationResult");
            //Разобрать то, что вытащили и превратить в OperationResult
            foreach (IDictionary<int,object> record in records)
            {
                items.Add(
                    new OperationResult()
                    {
                        Id = (int)record[0],
                        OperationName = record[1].ToString(),
                        Arguments =record[2].ToString(),
                        Result = record[3] as double?,
                        ExecutionTime = (long)record[4],
                        ExecutionDate = (DateTime)record[5]
                    }
                    );
            }
            //Отдать
            return items;
        }
    }
}