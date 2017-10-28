using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using uCookApp.Interfaces;
using uCookApp.Models;

namespace uCookApp.Converters
{
    public class ToDoMapper : IMapReader<ToDo>
    {
        public ToDo MapReader(SqlDataReader reader)
        {
            var output = new ToDo();
            output.Id = Convert.ToInt32(reader["Id"]);
            output.Summary = reader["Summary"].ToString();
            output.Title = reader["Title"].ToString();
            var date = reader["DateCompleted"];
            try
            {
                output.DateCompleted = Convert.ToDateTime(date);
            }
            catch (Exception)
            { }
            return output;
        }

        public ToDo ReturnNotFound()
        {
            return new ToDoNotFound();
        }

        public ToDo ReturnError(string ex)
        {
            return new ToDoError() { Message = ex };
        }
    }
}