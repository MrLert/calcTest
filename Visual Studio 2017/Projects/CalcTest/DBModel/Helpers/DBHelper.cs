using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace WebCalcNew.Helpers
{
    public static class DBHelper
    {
        public const string ConnectionString =@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\db\CalcStorage.mdf;Integrated Security=True";
            

        public static IEnumerable<object> GetAllFromTable(string table)
        {
            var result = new List<object>();

            string sqlquery = $"SELECT * FROM {table}";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(sqlquery, conn);
                conn.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader != null && reader.Read())
                    {
                        var item = new Dictionary<int, object>();
                        for (var i = 0; i < reader.FieldCount; i++)
                        {
                            item.Add(i, reader[i]);
                        }
                        result.Add(item);
                    }
                }
            }
            return result;
        }
       
        public static void InsertTable(string table, IEnumerable<object> item)
        {
            var values = item.Select(i => i is string || i is DateTime
                ? $"'{i}'"
                : i 
            );
            var sqlquery = $"INSERT INTO {table} VALUES ({string.Join(", ", values)})";
            //var sqlq = $"INSERT INTO {table} VALUES ({item[0]}, {item[1]}, {item[2]}, {item[3] as double?}, {item[4]})";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(sqlquery, conn);
                conn.Open();
                command.ExecuteNonQuery();
            }
        }

        public static void ChangeOper(string table, IList<object> item)
        {
            var sqlquery = $"UPDATE {table} SET Result = @Result, " +
                           "ExecutionTime = @ExecutionTime, " +
                           "ExecutionDate = @ExecutionDate " +
                           "WHERE OperationName = @OperationName AND Arguments = @Arguments;";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(sqlquery, conn);
                command.Parameters.AddWithValue("@OperationName", item[0]);
                command.Parameters.AddWithValue("@Arguments", item[1]);
                command.Parameters.AddWithValue("@Result", item[2]);
                command.Parameters.AddWithValue("@ExecutionTime", item[3]);
                command.Parameters.AddWithValue("@ExecutionDate", item[4]);
                conn.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}