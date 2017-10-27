using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using uCookApp.ApplicationSettings;
using uCookApp.Interfaces;
using uCookApp.Models;

namespace uCookApp.DbConnection
{
    public class BaseDal<TItem> : IBaseDal<TItem>
    {
        //I would usually use stored procedures (large writes) or LINQ quries (complex reads and Updates) to do these data calls, 
        //but doing things like this allows me to demonstrate the use of generics and interfaces 
        private string _connectionString;
        private string _tableName;
        IDalWriteParameters<TItem> _parameterGenerator;
        public BaseDal(string tableName, IDalWriteParameters<TItem> parameterGenerator)
        {
            _connectionString = AppSettings.GetDBConnectionString();
            _tableName = tableName;
            _parameterGenerator = parameterGenerator;
        }

        public SqlDataReader ReadFromDB(int id)
        {
            //Only want the first row for this example
            string commandText = "SELECT TOP 1 * FROM @TableName WHERE Id = @ID AND IsDeleted = false";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(commandText, connection);

                command.Parameters.Add("@ID", SqlDbType.Int);
                command.Parameters["@ID"].Value = id;

                command.Parameters.Add("@TableName", SqlDbType.VarChar);
                command.Parameters["@TableName"].Value = _tableName;
                try
                {
                    connection.Open();
                    return command.ExecuteReader();
                }
                catch (Exception)
                {
                    return null;
                    //I would log exception message here (ERROR level)
                }
            }
            //connection automatically disposed of
        }

        public SqlDataReader ReadAllRowsFromDB()
        {
            //Only want the first row for this example
            string commandText = "SELECT * FROM @TableName;";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(commandText, connection);
                
                command.Parameters.Add("@TableName", SqlDbType.VarChar);
                command.Parameters["@TableName"].Value = _tableName;
                try
                {
                    connection.Open();
                    return command.ExecuteReader();
                }
                catch (Exception)
                {
                    return null;
                    //I would log exception message here (ERROR level)
                }
            }
            //connection automatically disposed of
        }

        public void WriteToDB(TItem obj)
        {
            string commandText = "INTSERT INTO @TableName VALUES @dataString";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(commandText, connection);

                command.Parameters.Add("@TableName", SqlDbType.VarChar);
                command.Parameters["@TableName"].Value = _tableName;

                command.Parameters.Add("@dataString", SqlDbType.VarChar);
                command.Parameters["@dataString"].Value = _parameterGenerator.GenerateParameters(obj);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    //I would log exception message here (ERROR level)
                }
            }
            //connection automatically disposed of
        }

        public void MarkAsDeleted(int id)
        {
            //Only want the first row for this example
            string commandText = "UPDATE @TableName SET IsDeleted = 1 WHERE Id = @ID";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(commandText, connection);

                command.Parameters.Add("@ID", SqlDbType.Int);
                command.Parameters["@ID"].Value = id;

                command.Parameters.Add("@TableName", SqlDbType.VarChar);
                command.Parameters["@TableName"].Value = _tableName;
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    //I would log exception message here (ERROR level)
                }
            }
        }

    }
}