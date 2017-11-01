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
        //I would usually use stored procedures (large writes as it is much faster) or LINQ quries ( best with complex reads and Updates) 
        //to do these data calls, but doing things like this allows me to demonstrate the use of generics and interfaces 
        private string _connectionString;
        private string _tableName;
        IDalWriteParameters<TItem> _parameterGenerator;
        IMapReader<TItem> _mapReader;
        public BaseDal(string tableName, IDalWriteParameters<TItem> parameterGenerator, IMapReader<TItem> mapReader)
        {
            _connectionString = AppSettings.GetDBConnectionString();
            _tableName = tableName;
            _parameterGenerator = parameterGenerator;
            _mapReader = mapReader;
        }

        public TItem ReadFromDB(int id)
        {
            //Only want the first row for this example
            string commandText = String.Format("SELECT TOP 1 * FROM {0} WHERE Id = @ID AND IsDeleted = 0", _tableName);

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(commandText, connection);

                command.Parameters.Add("@ID", SqlDbType.Int);
                command.Parameters["@ID"].Value = id;
                try
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        return _mapReader.MapReader(reader);
                    }
                    return _mapReader.ReturnNotFound();
                }
                catch (Exception e)
                {
                    return _mapReader.ReturnError(e.Message);
                    //I would log exception message here (ERROR level)
                }
            }
            //connection automatically disposed of
        }

        public List<TItem> ReadAllRowsFromDB()
        {
            //Only want the first row for this example
            string commandText = String.Format("SELECT * FROM {0} WHERE IsDeleted = 0;", _tableName);

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(commandText, connection);
                try
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    List<TItem> output = new List<TItem>();
                    while (reader.Read())
                    {
                        output.Add(_mapReader.MapReader(reader));
                    }
                    return output;
                }
                catch (Exception ex)
                {
                    return new List<TItem>() { _mapReader.ReturnError(ex.Message) };
                    //I would log exception message here (ERROR level)
                }
            }
            //connection automatically disposed of
        }

        public int WriteToDB(TItem obj)
        {
            //This would be simplified with a stored procedure, but doing this, this way to demonstrate generics
            string commandText = String.Format("INSERT INTO {0} {1};SELECT @@IDENTITY", _tableName, _parameterGenerator.GenerateParameters(obj));

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(commandText, connection);
                
                try
                {
                    connection.Open();
                    var response = command.ExecuteScalar();
                    return Convert.ToInt32(response);
                }
                catch (Exception e)
                {
                    return 0;
                    //I would log exception message here (ERROR level)
                }
            }
            //connection automatically disposed of
        }

        public int UpdateRowInDB(TItem obj)
        {
            //This would be simplified with a stored procedure, but doing this, this way to demonstrate generics
            string commandText = String.Format("UPDATE {0} SET {1}", _tableName, _parameterGenerator.UpdateParameters(obj));

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(commandText, connection);

                try
                {
                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
                catch (Exception e)
                {
                    return 0;
                    //I would log exception message here (ERROR level)
                }
            }
            //connection automatically disposed of
        }

        public void MarkAsDeleted(int id)
        {
            //Only want the first row for this example
            string commandText = String.Format("UPDATE {0} SET IsDeleted = 1 WHERE Id = @ID", _tableName);

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